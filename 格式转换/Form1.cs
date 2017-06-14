using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 格式转换
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string openfilepath = "";   //头文件 .hdr
        private string savefilepath = "";   //格式转换后的保存文件 .img    
        private string orginFilePath = "";  //格式转换前的文件    .img
        /// <summary>      
        /// 读取头文件信息      
        ///  </summary> 
        /// <param name="strFileName"></param>头文件路径和名称     
        /// <param name="iColumnsCount"></param>像素列数 
        /// <param name="iLinesCount"></param>像素行数     
        ///  <param name="iBandsCount"></param>波段数      
        /// <param name="iType"></param>基本数据类型代码     
        ///  <param name="strInterLeave"></param>文件组织格式     
        ///  <returns></returns>返回是否读取成功 
        public static bool ReadHDR(String strFileName, out int iColumnsCount, out int iLinesCount, out int iBandsCount,
            out int iType, out String strInterLeave)
        {
            bool blnSuccess = false;
            iColumnsCount = -1;
            iLinesCount = -1;
            iBandsCount = -1;
            iType = -1;
            strInterLeave = ""; //初始化各个变量 
            StreamReader hdrfile = null;
            try
            {
                hdrfile = new StreamReader(strFileName);
                string content = "";
                while (hdrfile.EndOfStream != true)
                {
                    //获取像素列数 
                    content = hdrfile.ReadLine();
                    if (content.Contains("samples"))
                    {
                        String samples =
                            content.Substring(content.IndexOf("=") + 1, content.Length - content.IndexOf("=") - 1)
                                .Trim();
                        iColumnsCount = Convert.ToInt32(samples);
                        Console.WriteLine(samples);
                        break;
                    }
                }
                while (hdrfile.EndOfStream != true)
                {
                    //获取像素行数 
                    content = hdrfile.ReadLine();
                    if (content.Contains("lines"))
                    {
                        String lines =
                            content.Substring(content.IndexOf("=") + 1, content.Length - content.IndexOf("=") - 1)
                                .Trim();
                        iLinesCount = Convert.ToInt32(lines);
                        System.Console.WriteLine(lines);
                        break;
                    }
                }
                while (hdrfile.EndOfStream != true)
                {
                    //获取波段个数 
                    content = hdrfile.ReadLine();
                    if (content.Contains("bands"))
                    {
                        String bands =
                            content.Substring(content.IndexOf("=") + 1, content.Length - content.IndexOf("=") - 1)
                                .Trim();
                        iBandsCount = Convert.ToInt32(bands);


                        System.Console.WriteLine(bands);
                        break;
                    }
                }
                while (hdrfile.EndOfStream != true)
                {
                    //获取数据种类 
                    content = hdrfile.ReadLine();
                    if (content.Contains("data type"))
                    {
                        String type =
                            content.Substring(content.IndexOf("=") + 1, content.Length - content.IndexOf("=") - 1)
                                .Trim();
                        iType = Convert.ToInt32(type);
                        System.Console.WriteLine(type);
                        break;
                    }
                }
                while (hdrfile.EndOfStream != true)
                {
                    //获取数据解译方式 
                    content = hdrfile.ReadLine();
                    if (content.Contains("interleave"))
                    {
                        String interleve =
                            content.Substring(content.IndexOf("=") + 1, content.Length - content.IndexOf("=") - 1)
                                .Trim();
                        strInterLeave = interleve;
                        System.Console.WriteLine(interleve);
                        blnSuccess = true;
                        break;
                    }
                }
            }
            catch
            {
                //读取失败 
                hdrfile.Close();
                hdrfile.Dispose();
                return false;
            }
            hdrfile.Close();
            hdrfile.Dispose();
            //关闭文件流，释放内存
            return blnSuccess;
        }


        /// <summary>
        /// 另存新格式头文件
        /// </summary>
        /// <param name="origiHDRPath"></param>
        /// <param name="outHDRPath"></param>
        /// <param name="newType"></param>
        public static void SaveHDR(string origiHDRPath, string outHDRPath, string newType)
        {
            newType = newType.ToLower();


            if (newType != "bsq" && newType != "bil" && newType != "bip")
                throw new Exception("文件格式不符合要求");
            try
            {
                using (StreamReader reader = new StreamReader(origiHDRPath))
                using (FileStream fileStream = new FileStream(outHDRPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    StreamWriter writer = new StreamWriter((Stream)fileStream);
                    while (!reader.EndOfStream)
                    {
                        string rowStr = reader.ReadLine();
                        if (rowStr.Contains("interleave"))
                        {
                            string[] strArrys = rowStr.Split('=');
                            rowStr = rowStr.Replace(strArrys[1], " " + newType);
                        }
                        writer.WriteLine(rowStr);
                    }
                    writer.Close();
                    writer.Dispose();
                }
            }
            catch (IOException er)
            {
                throw new Exception("文件操作异常");
            }
            catch (Exception er)
            {
                throw new Exception();
            }
        }

         
        /// </summary> 
        ///  bip转换为bsq
        /// <param name="strInputFile"></param>源文件名称与路径     
        ///  <param name="strOutputFile"></param>目标文件名称与路径     
        ///  <param name="pixComCounts"></param>像素行数     
        /// <param name="pixLineCounts"></param>像素列数    
        ///  <param name="bands"></param>波段数 
        /// <param name="type"></param>基本数据类型代码     
        ///  <returns></returns>是否转换成功 
        public static bool BipToBsq(string strInputFile, string strOutputFile, int pixComCounts, int pixLineCounts,
            int bands, int type)
        {
            bool blnSuccess = true;
            FileStream inputF = new FileStream(strInputFile, FileMode.Open);
            FileStream outputF = new FileStream(strOutputFile, FileMode.CreateNew);
            int totalsize = pixComCounts*pixLineCounts*bands*type; //计算输入文件总字节数 
            if (totalsize != inputF.Length)
            {
                return false;
            }
            byte[] bts = new byte[totalsize];
            int num = 0, bt;
            while ((bt = inputF.ReadByte()) > -1)
            {
                //读取出全部字节数据，存储在数组中 
                bts[num] = (byte) bt;
                num++;
            }
            for (int bandnum = 0; bandnum < bands; bandnum++)
            {
                //读取波段写入 
                for (int row = 0; row < pixLineCounts; row++)
                {
                    //按行写入                      
                    for (int columnum = 0; columnum < pixComCounts; columnum++)
                    {
                        //读取列写入 
                        int startpos = pixComCounts*type*bands*row + columnum*type*bands + bandnum*type;
                        for (int typenum = 0; typenum < type; typenum++)
                        {
                            //读取数据基本单元类型输入数据 
                            outputF.WriteByte(bts[startpos + typenum]);
                        }
                    }
                }
            }


            outputF.Flush(); //保存缓存文件     
            outputF.Close(); //关闭撤销变量文件     
            outputF.Dispose();
            inputF.Close();
            inputF.Dispose();
            return blnSuccess;
        }



        public static bool BipToBil(string strInputFile, string strOutputFile, int pixComCounts, int pixLineCounts, int bands, int type)
        {
            bool blnSuccess = true;
            FileStream inputF = new FileStream(strInputFile, FileMode.Open);
            FileStream outputF = new FileStream(strOutputFile, FileMode.CreateNew);
            int totalsize = pixComCounts * pixLineCounts * bands * type;//计算输入文件总字节数
            if (totalsize != inputF.Length)
            {
                return false;
            }
            byte[] bts = new byte[totalsize];


            int num = 0, bt;
            //读取出全部字节数据，存储在数组中
            while ((bt = inputF.ReadByte()) > -1)
            {
                bts[num] = (byte)bt;
                num++;
            }
            //按行写入
            for (int row = 0; row < pixLineCounts; row++)
            {
                //按波段写入
                for (int bandnum = 0; bandnum < bands; bandnum++)
                {
                    //按列写入
                    for (int columnum = 0; columnum < pixComCounts; columnum++)
                    {
                        int startpos = pixComCounts * row * bands * type + columnum * bands * type + bandnum * type;
                        //按数据基本单元类型输入数据
                        for (int typenum = 0; typenum < type; typenum++)
                        {
                            outputF.WriteByte(bts[startpos + typenum]);
                        }
                    }
                }
            }
            outputF.Flush();//保存缓存文件
            outputF.Close();//关闭撤销变量文件
            outputF.Dispose();
            inputF.Close();
            inputF.Dispose();
            return blnSuccess;
        }


        /// <summary> 
        /// bsq转换为bil     
        ///  </summary> 
        /// <param name="strInputFile"></param>源文件名称与路径     
        ///  <param name="strOutputFile"></param>目标文件名称与路径    
        ///  <param name="pixComCounts"></param>像素行数     
        /// <param name="pixLineCounts"></param>像素列数     
        ///  <param name="bands"></param>波段数 
        /// <param name="type"></param>基本数据类型代码     
        /// <returns></returns>是否转换成功 
        public static bool BsqToBil(string strInputFile, string strOutputFile, int pixComCounts, int pixLineCounts,
            int bands, int type)
        {
            bool blnSuccess = true;
            FileStream inputF = new FileStream(strInputFile, FileMode.Open);
            FileStream outputF = new FileStream(strOutputFile, FileMode.CreateNew);
            int totalsize = pixComCounts*pixLineCounts*bands*type; //计算输入文件总字节数 
            if (totalsize != inputF.Length)
            {
                return false;
            }
            byte[] bts = new byte[totalsize];
            int num = 0, bt;
            while ((bt = inputF.ReadByte()) > -1)
            {
                //读取出全部字节数据，存储在数组中             
                bts[num] = (byte) bt;
                num++;
            }
            for (int row = 0; row < pixLineCounts; row++)
            {
                //按行写入数据 
                for (int bandnum = 0; bandnum < bands; bandnum++)
                {
                    //按波段写入数据 
                    int startpos = pixComCounts*pixLineCounts*type*bandnum + row*pixComCounts*type;
                    for (int columnum = 0; columnum < pixComCounts; columnum++)


                    {
                        //写入每一列数据 
                        for (int typenum = 0; typenum < type; typenum++)
                        {
                            //按数据基本单元类型输入数据 
                            outputF.WriteByte(bts[startpos + columnum*type + typenum]);
                        }
                    }
                }
            }
            outputF.Flush(); //保存缓存文件  
            outputF.Close(); //关闭撤销变量文件   
            outputF.Dispose();
            inputF.Close();
            inputF.Dispose();
            return blnSuccess;
        }

        public static bool BsqToBip(string strInputFile, string strOutputFile, int pixComCounts, int pixLineCounts, int bands, int type)
        {
            bool blnSuccess = true;
            FileStream inputF = new FileStream(strInputFile, FileMode.Open);
            FileStream outputF = new FileStream(strOutputFile, FileMode.CreateNew);
            int totalsize = pixComCounts * pixLineCounts * bands * type;//计算输入文件总字节数
            if (totalsize != inputF.Length)
            {
                return false;
            }
            byte[] bts = new byte[totalsize];
            int num = 0, bt = 0;
            while ((bt = inputF.ReadByte()) > -1)
            {//读取出全部字节数据，存储在数组中
                bts[num] = (byte)bt;
                num++;
            }
            //按行写入
            for (int row = 0; row < pixLineCounts; row++)
            {
                //按列写入
                for (int columnum = 0; columnum < pixComCounts; columnum++)
                {
                    //按波段写入
                    for (int bandnum = 0; bandnum < bands; bandnum++)
                    {


                        int startpos = pixComCounts * pixLineCounts * type * bandnum + row * pixComCounts * type + columnum * type;
                        //按数据基本单元类型输入数据
                        for (int typenum = 0; typenum < type; typenum++)
                        {
                            outputF.WriteByte(bts[startpos + typenum]);
                        }
                    }
                }
            }
            outputF.Flush();//保存缓存文件
            outputF.Close();//关闭撤销变量文件
            outputF.Dispose();
            inputF.Close();
            inputF.Dispose();
            return blnSuccess;
        }

        /// <summary> 
        /// bil转换为bip     
        ///  </summary> 
        /// <param name="strInputFile"></param>源文件名称与路径     
        ///  <param name="strOutputFile"></param>目标文件名称与路径
        ///  <param name="pixComCounts"></param>像素行数    
        ///  <param name="pixLineCounts"></param>像素列数    
        /// <param name="bands"></param>波段数 
        /// <param name="type"></param>基本数据类型代码     
        /// <returns></returns>是否转换成功 
        public static bool BilToBip(string strInputFile, string strOutputFile, int pixComCounts, int pixLineCounts,
            int bands, int type)
        {
            bool blnSuccess = true;
            FileStream inputF = new FileStream(strInputFile, FileMode.Open);
            FileStream outputF = new FileStream(strOutputFile, FileMode.CreateNew);
            int totalsize = pixComCounts*pixLineCounts*bands*type; //计算输入文件总字节数 
            if (totalsize != inputF.Length)
            {
                return false;
            }
            byte[] bts = new byte[totalsize];
            int num = 0, bt;
            while ((bt = inputF.ReadByte()) > -1)
            {
                //读取出全部字节数据，存储在数组中      
                bts[num] = (byte) bt;
                num++;
            }
            for (int row = 0; row < pixLineCounts; row++)
            {
                //按行写入 
                for (int columnum = 0; columnum < pixComCounts; columnum++)
                {
                    //读取列写入   
                    for (int bandnum = 0; bandnum < bands; bandnum++)
                    {
                        //读取波段写入 
                        int startpos = pixComCounts*type*row*bands + pixComCounts*type*bandnum +
                                       type*columnum; //获取基准位置 
                        for (int typenum = 0; typenum < type; typenum++)
                        {
                            //读取数据基本单元类型输入数据 
                            outputF.WriteByte(bts[startpos + typenum]);
                        }
                    }
                }
            }
            outputF.Flush(); //保存缓存文件  
            outputF.Close(); //关闭撤销变量文件    
            outputF.Dispose();
            inputF.Close();
            inputF.Dispose();
            return blnSuccess;
        }

        public static bool BilToBsq(string strInputFile, string strOutputFile, int pixComCounts, int pixLineCounts, int bands, int type)
        {
            bool blnSuccess = true;
            FileStream inputF = new FileStream(strInputFile, FileMode.Open);
            FileStream outputF = new FileStream(strOutputFile, FileMode.CreateNew);
            int totalsize = pixComCounts * pixLineCounts * bands * type;//计算输入文件总字节数
            if (totalsize != inputF.Length)
            {
                return false;
            }
            byte[] bts = new byte[totalsize];
            int num = 0, bt;
            while ((bt = inputF.ReadByte()) > -1)
            {//读取出全部字节数据，存储在数组中
                bts[num] = (byte)bt;
                num++;
            }
            //读取波段写入
            for (int bandnum = 0; bandnum < bands; bandnum++)
            {
                //按行写入
                for (int row = 0; row < pixLineCounts; row++)
                {
                    //按列写入
                    for (int columnum = 0; columnum < pixComCounts; columnum++)
                    {
                        int startpos = pixComCounts * type * row * bands + pixComCounts * type * bandnum + type * columnum;//获取基准位置
                        //按数据基本单元类型输入数据
                        for (int typenum = 0; typenum < type; typenum++)
                        {
                            outputF.WriteByte(bts[startpos + typenum]);
                        }
                    }
                }
            }
            outputF.Flush();//保存缓存文件
            outputF.Close();//关闭撤销变量文件
            outputF.Dispose();
            inputF.Close();


            inputF.Dispose();
            return blnSuccess;
        }
        
        private void SelectFileBtu_Click(object sender, EventArgs e)
        {
            //每次选择文件都将文件信息重置
            openfilepath = String.Empty;
            Txt_Column.Text = String.Empty;
            Txt_Row.Text = String.Empty;
            Txt_TM.Text = String.Empty;
            Txt_DataFormat.Text = String.Empty;
            Txt_FIleFormat.Text = String.Empty;

            openFileDialog1.Filter = "HDRfile(*.HDR)|*.HDR|All files(*.*)|*.*"; //打开文件路径
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory().Replace("bin\\Debug",null);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openfilepath = openFileDialog1.FileName;
            }
            Txt_Openfile.Text = openfilepath;
            


        }

        private void QurryInfoBtu_Click(object sender, EventArgs e)
        {
            int iColumnsCount;
            int iLinesCount;
            int iBandsCount;
            int iType;
            string strInterleave = String.Empty;
            string[] str=openfilepath.Split('.');

            if (!string.IsNullOrEmpty(openfilepath)  &&  str[1]=="hdr")
            {
                //这里用了out参数的类型
                if (ReadHDR(openfilepath, out iColumnsCount, out iLinesCount, out iBandsCount, out iType, out strInterleave))
                {
                    Txt_Column.Text = iColumnsCount.ToString();
                    Txt_Row.Text = iLinesCount.ToString();
                    Txt_TM.Text = iBandsCount.ToString();
                    Txt_DataFormat.Text = iType.ToString();
                    Txt_FIleFormat.Text = strInterleave;
                }
            }
            else
            {
                MessageBox.Show("打开文件格式不正确", "温馨提示", MessageBoxButtons.OK);
                return;
            }
            
        }

        private void SaveFileBtu_Click(object sender, EventArgs e)
        {
            savefilepath = String.Empty;
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                savefilepath = saveFileDialog1.FileName.ToString(); //获得文件路径
                if (!savefilepath.Contains(".img"))
                {
                    savefilepath = savefilepath + ".img";
                }
            }
            Txt_SaveFile.Text = savefilepath;
        }

        private void ConvertBtu_Click(object sender, EventArgs e)
        {
            string geshistr=String.Empty;
            savefilepath = Txt_SaveFile.Text.ToString();
            foreach (RadioButton chk in groupBox1.Controls)
            {
                if (chk.Checked)
                {
                    geshistr = chk.Text;
                }
            }
            if (string.IsNullOrEmpty(orginFilePath) && !orginFilePath.Contains(".img"))
            {
                MessageBox.Show("文件格式不正确", "温馨提示", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(geshistr) )
            {
                MessageBox.Show("未选择转换格式", "温馨提示", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(orginFilePath))
            {
                MessageBox.Show("未选择文件保存地址", "温馨提示", MessageBoxButtons.OK);
                return;
            }
            if (geshistr=="bsq" && Txt_FIleFormat.Text=="bip")
            {
                if (BipToBsq(orginFilePath, savefilepath, int.Parse(this.Txt_Column.Text.Trim()), int.Parse(this.Txt_Row.Text.Trim()), int.Parse(this.Txt_TM.Text.Trim()), int.Parse(this.Txt_DataFormat.Text.Trim())))
                {
                    SaveHDR(openfilepath, savefilepath.Replace(".img", ".hdr").ToString(), geshistr);
                    MessageBox.Show("bip格式到bsp格式转换成功!");
                }
            }
            else if (geshistr == "bil" && Txt_FIleFormat.Text == "bsq")
            {
                if (BsqToBil(orginFilePath, savefilepath, int.Parse(this.Txt_Column.Text.Trim()), int.Parse(this.Txt_Row.Text.Trim()), int.Parse(this.Txt_TM.Text.Trim()), int.Parse(this.Txt_DataFormat.Text.Trim())))
                {
                    SaveHDR(openfilepath, savefilepath.Replace(".img",".hdr").ToString(), geshistr);
                    MessageBox.Show("bsq格式到bil格式转换成功!");
                }
            }
            else if (geshistr == "bip" && Txt_FIleFormat.Text == "bil")
            {
                if (BilToBip(orginFilePath, savefilepath, int.Parse(this.Txt_Column.Text.Trim()), int.Parse(this.Txt_Row.Text.Trim()), int.Parse(this.Txt_TM.Text.Trim()), int.Parse(this.Txt_DataFormat.Text.Trim())))
                {
                    SaveHDR(openfilepath, savefilepath.Replace(".img", ".hdr").ToString(), geshistr);
                    MessageBox.Show("bil格式到bip格式转换成功!");
                }
            }
            else if (geshistr == "bil" && Txt_FIleFormat.Text == "bip")
            {
                if (BilToBip(orginFilePath, savefilepath, int.Parse(this.Txt_Column.Text.Trim()), int.Parse(this.Txt_Row.Text.Trim()), int.Parse(this.Txt_TM.Text.Trim()), int.Parse(this.Txt_DataFormat.Text.Trim())))
                {
                    SaveHDR(openfilepath, savefilepath.Replace(".img", ".hdr").ToString(), geshistr);
                    MessageBox.Show("bip格式到bil格式转换成功!");
                }
            }
            else if (geshistr == "bip" && Txt_FIleFormat.Text == "bsq")
            {
                if (BilToBip(orginFilePath, savefilepath, int.Parse(this.Txt_Column.Text.Trim()), int.Parse(this.Txt_Row.Text.Trim()), int.Parse(this.Txt_TM.Text.Trim()), int.Parse(this.Txt_DataFormat.Text.Trim())))
                {
                    SaveHDR(openfilepath, savefilepath.Replace(".img", ".hdr").ToString(), geshistr);
                    MessageBox.Show("bsq格式到bip格式转换成功!");
                }
            }
            else if (geshistr == "bsq" && Txt_FIleFormat.Text == "bil")
            {
                if (BilToBip(orginFilePath, savefilepath, int.Parse(this.Txt_Column.Text.Trim()), int.Parse(this.Txt_Row.Text.Trim()), int.Parse(this.Txt_TM.Text.Trim()), int.Parse(this.Txt_DataFormat.Text.Trim())))
                {
                    SaveHDR(openfilepath, savefilepath.Replace(".img", ".hdr").ToString(), geshistr);
                    MessageBox.Show("bil格式到bsq格式转换成功!");
                }
            }
        }

        //只能3远一

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked == true)
            {
                foreach (RadioButton chk in (sender as RadioButton).Parent.Controls)
                {
                    if (chk != sender)
                    {
                        chk.Checked = false;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化
            this.radioButton_bil.Checked = true;
        }

        private void DispalyBtu_Click(object sender, EventArgs e)
        {
            DisplayForm form=new DisplayForm();
            form.Show();
        }
        //格式转换的源文件
        private void OrginFile_Btu_Click(object sender, EventArgs e)
        {
            /*
            openFileDialog1.Filter = "Imgfile(*.Img)|*.img|All files(*.*)|*.*"; //打开文件路径
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory().Replace("bin\\Debug", null);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                orginFilePath = openFileDialog1.FileName;
            }
            Txt_OrginFile.Text = openfilepath;
             */
            Txt_OrginFile.Text = openfilepath.Replace(".hdr", ".img");
            orginFilePath = openfilepath.Replace(".hdr", ".img");
        }


    }
}
