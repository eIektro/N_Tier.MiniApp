using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace N_Tier.MiniApp.Presentation.WebUI.Utilities
{
    public class ByteImageResize
    {
        //TO-DO: Copy-Pase alert! Daha iyi bir formül bulunduğunda refactor edilecek.

        public static byte[] ResizeFromByteArray(string fileName, int MaxSideSize, Byte[] byteArrayIn)
        {
            byte[] byteArray = null;  // really make this an error gif
            MemoryStream ms = new MemoryStream(byteArrayIn);
            byteArray = ResizeFromStream(fileName, MaxSideSize, ms);
            return byteArray;
        }

        /// <summary>
        /// converts from input stream to output bytearray
        /// inspired from: http://www.eggheadcafe.com/articles/20030515.asp
        /// </summary>
        /// <param name="ImageSavePath"></param>
        /// <param name="MaxSideSize"></param>
        /// <param name="Buffer"></param>
        /// <returns></returns>
        public static byte[] ResizeFromStream(string fileName, int MaxSideSize, Stream Buffer)
        {
            byte[] byteArray = null;  // really make this an error gif

            try
            {
                Bitmap bitMap = new Bitmap(Buffer);
                int intOldWidth = bitMap.Width;
                int intOldHeight = bitMap.Height;

                int intNewWidth;
                int intNewHeight;

                int intMaxSide;

                if (intOldWidth >= intOldHeight)
                {
                    intMaxSide = intOldWidth;
                }
                else
                {
                    intMaxSide = intOldHeight;
                }

                if (intMaxSide > MaxSideSize)
                {
                    //set new width and height
                    double dblCoef = MaxSideSize / (double)intMaxSide;
                    intNewWidth = Convert.ToInt32(dblCoef * intOldWidth);
                    intNewHeight = Convert.ToInt32(dblCoef * intOldHeight);
                }
                else
                {
                    intNewWidth = intOldWidth;
                    intNewHeight = intOldHeight;
                }

                Size ThumbNailSize = new Size(intNewWidth, intNewHeight);
                System.Drawing.Image oImg = System.Drawing.Image.FromStream(Buffer);
                System.Drawing.Image oThumbNail = new Bitmap
                    (ThumbNailSize.Width, ThumbNailSize.Height);
                Graphics oGraphic = Graphics.FromImage(oThumbNail);
                oGraphic.CompositingQuality = CompositingQuality.HighQuality;
                oGraphic.SmoothingMode = SmoothingMode.HighQuality;
                oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Rectangle oRectangle = new Rectangle
                    (0, 0, ThumbNailSize.Width, ThumbNailSize.Height);

                oGraphic.DrawImage(oImg, oRectangle);

                //string fileName = Context.Server.MapPath("~/App_Data/") + "test1.jpg";
                //oThumbNail.Save(fileName, ImageFormat.Jpeg);
                MemoryStream ms = new MemoryStream();
                oThumbNail.Save(ms, ImageFormat.Jpeg);
                byteArray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));

                oGraphic.Dispose();
                oImg.Dispose();
                ms.Close();
                ms.Dispose();
            }
            catch (Exception)
            {
                int newSize = MaxSideSize - 20;
                Bitmap bitMap = new Bitmap(newSize, newSize);
                Graphics g = Graphics.FromImage(bitMap);
                g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(0, 0, newSize, newSize));

                Font font = new Font("Courier", 8);
                SolidBrush solidBrush = new SolidBrush(Color.Red);
                g.DrawString("Failed File", font, solidBrush, 10, 5);
                g.DrawString(fileName, font, solidBrush, 10, 50);

                MemoryStream ms = new MemoryStream();
                bitMap.Save(ms, ImageFormat.Jpeg);
                byteArray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));

                ms.Close();
                ms.Dispose();
                bitMap.Dispose();
                solidBrush.Dispose();
                g.Dispose();
                font.Dispose();

            }
            return byteArray;
        }
    }
}