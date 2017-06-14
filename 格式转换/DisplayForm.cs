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
using OSGeo.GDAL;

namespace 格式转换
{
    public partial class DisplayForm : Form
    {
        public DisplayForm()
        {
            InitializeComponent();
        }

        private void OpenFileBtu_Click(object sender, EventArgs e)
        {
            string filename=String.Empty;
            int Width = this.pictureBox1.Width;
            int Height = this.pictureBox1.Height;
            openFileDialog1.Filter = "Erdas img文件|*.img|Tiff文件|*.tif|Bmp文件|*.bmp|jpeg文件|*.jpg|所有文件|*.*";
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory().Replace("bin\\Debug", null);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
            }
            this.Txt_FileName.Text = filename;
            if (string.IsNullOrEmpty(filename) &&
                filename.Substring(filename.IndexOf(".") + 1, filename.Length - filename.IndexOf(".") - 1).Trim() !=
                "img")
            {
                MessageBox.Show("打开文件格式不正确", "温馨提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                try
                {
                    Read_Img readImg=new Read_Img();
                    pictureBox1.Image=readImg.ImageShow(filename, Width, Height);
                }
                catch (Exception)
                {
                    Read_Img readImg = new Read_Img();
                    pictureBox1.Image = readImg.ImageShow(Directory.GetCurrentDirectory().Replace("bin\\Debug", "Source\\分类数据\\can_tmr.img"), Width, Height);
                }
            }
        }
        
    }
}
