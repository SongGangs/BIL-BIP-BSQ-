﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSGeo.GDAL;

namespace 格式转换
{
    class Read_Img
    {
        /// <summary>
        /// 展现Img
        /// </summary>
        /// <param name="filename">img文件</param>
        /// <param name="Width">显示区域宽度</param>
        /// <param name="Height">需要显示高度</param>
        /// <returns>返回Bitmap对象</returns>
        public Bitmap ImageShow(string filename,int Width,int Height)
        {

            // 为了支持中文路径，请添加下面这句代码

            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "NO");

            // 为了使属性表字段支持中文，请添加下面这句

            OSGeo.GDAL.Gdal.SetConfigOption("SHAPE_ENCODING", "");
            OSGeo.GDAL.Gdal.AllRegister();

            OSGeo.GDAL.Dataset ds = Gdal.Open(filename, Access.GA_ReadOnly);
            if (ds == null)
            {
                MessageBox.Show("影像打开失败");
                return null;
            }
            Rectangle pictureRect = new Rectangle();
            pictureRect.X = 0;
            pictureRect.Y = 0;
            pictureRect.Width = Width;
            pictureRect.Height = Height;

            int[] disband = { 3, 2, 1 };

            Bitmap bitmap = GetImage(ds, pictureRect, disband);   //遥感影像构建位图
            return bitmap;
            //  pictureBox1.Image = bitmap;                   //将位图传递给PictureBox控件进行显示

        }
        /// <summary>
        /// GDAL栅格转换为位图
        /// </summary>
        /// <param name="ds">GDAL Dataset</param>
        /// <param name="showRect">显示区域</param>
        /// <param name="bandlist">需要显示的波段列表</param>
        /// <returns>返回Bitmap对象</returns>
        public Bitmap GetImage(OSGeo.GDAL.Dataset ds, Rectangle showRect, int[] bandlist)
        {
            int imgWidth = ds.RasterXSize;   //影像宽
            int imgHeight = ds.RasterYSize;  //影像高

            float ImgRatio = imgWidth / (float)imgHeight;  //影像宽高比

            //获取显示控件大小
            int BoxWidth = showRect.Width;
            int BoxHeight = showRect.Height;

            float BoxRatio = imgWidth / (float)imgHeight;  //显示控件宽高比

            //计算实际显示区域大小，防止影像畸变显示
            int BufferWidth, BufferHeight;
            if (BoxRatio >= ImgRatio)
            {
                BufferHeight = BoxHeight;
                BufferWidth = (int)(BoxHeight * ImgRatio);
            }
            else
            {
                BufferWidth = BoxWidth;
                BufferHeight = (int)(BoxWidth / ImgRatio);
            }

            //构建位图
            Bitmap bitmap = new Bitmap(BufferWidth, BufferHeight,
                                     System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            if (bandlist.Length == 3)     //RGB显示
            {
                int[] r = new int[BufferWidth * BufferHeight];
                Band band1 = ds.GetRasterBand(bandlist[0]);
                band1.ReadRaster(0, 0, imgWidth, imgHeight, r, BufferWidth, BufferHeight, 0, 0);  //读取图像到内存

                //为了显示好看，进行最大最小值拉伸显示
                double[] maxandmin1 = { 0, 0 };
                band1.ComputeRasterMinMax(maxandmin1, 0);

                int[] g = new int[BufferWidth * BufferHeight];
                Band band2 = ds.GetRasterBand(bandlist[1]);
                band2.ReadRaster(0, 0, imgWidth, imgHeight, g, BufferWidth, BufferHeight, 0, 0);

                double[] maxandmin2 = { 0, 0 };
                band2.ComputeRasterMinMax(maxandmin2, 0);

                int[] b = new int[BufferWidth * BufferHeight];
                Band band3 = ds.GetRasterBand(bandlist[2]);
                band3.ReadRaster(0, 0, imgWidth, imgHeight, b, BufferWidth, BufferHeight, 0, 0);

                double[] maxandmin3 = { 0, 0 };
                band3.ComputeRasterMinMax(maxandmin3, 0);

                int i, j;
                for (i = 0; i < BufferWidth; i++)
                {
                    for (j = 0; j < BufferHeight; j++)
                    {
                        int rVal = Convert.ToInt32(r[i + j * BufferWidth]);
                        rVal = (int)((rVal - maxandmin1[0]) / (maxandmin1[1] - maxandmin1[0]) * 255);

                        int gVal = Convert.ToInt32(g[i + j * BufferWidth]);
                        gVal = (int)((gVal - maxandmin2[0]) / (maxandmin2[1] - maxandmin2[0]) * 255);

                        int bVal = Convert.ToInt32(b[i + j * BufferWidth]);
                        bVal = (int)((bVal - maxandmin3[0]) / (maxandmin3[1] - maxandmin3[0]) * 255);

                        Color newColor = Color.FromArgb(rVal, gVal, bVal);
                        bitmap.SetPixel(i, j, newColor);
                    }
                }
            }
            else               //灰度显示
            {
                int[] r = new int[BufferWidth * BufferHeight];
                Band band1 = ds.GetRasterBand(bandlist[0]);
                band1.ReadRaster(0, 0, imgWidth, imgHeight, r, BufferWidth, BufferHeight, 0, 0);

                double[] maxandmin1 = { 0, 0 };
                band1.ComputeRasterMinMax(maxandmin1, 0);

                int i, j;
                for (i = 0; i < BufferWidth; i++)
                {
                    for (j = 0; j < BufferHeight; j++)
                    {
                        int rVal = Convert.ToInt32(r[i + j * BufferWidth]);
                        rVal = (int)((rVal - maxandmin1[0]) / (maxandmin1[1] - maxandmin1[0]) * 255);

                        Color newColor = Color.FromArgb(rVal, rVal, rVal);
                        bitmap.SetPixel(i, j, newColor);
                    }
                }
            }

            return bitmap;
        }
    }
}
