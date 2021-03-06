using ChilePlacer.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ChilePlacer.Application
{
    public class ImageTool : IImageTool
    {

        public void MarcaDeAgua(string path, string pathName)
        {
            Image image = Image.FromFile(path);
            Bitmap bmp = new Bitmap(image);
            Graphics graphicsobj = Graphics.FromImage(bmp);
            Brush brush = new SolidBrush(Color.FromArgb(80, 255, 255, 255));
            Point postionWaterMark = new Point((bmp.Width / 9), (bmp.Height - 50));
            graphicsobj.DrawString("www.chileplacer.cl", new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel), brush, postionWaterMark);
            Image img = (Image)bmp;
            img.Save(pathName, System.Drawing.Imaging.ImageFormat.Jpeg);
            graphicsobj.Dispose();
        }

        public void MarcaDeAguaPerfil(string path, string pathName)
        {
            Image image = Image.FromFile(path);
            Bitmap bmp = new Bitmap(image);
            Graphics graphicsobj = Graphics.FromImage(bmp);
            Brush brush = new SolidBrush(Color.FromArgb(80, 255, 255, 255));
            Point postionWaterMark = new Point((bmp.Width / 9), (bmp.Height / 2));
            graphicsobj.DrawString("www.chileplacer.cl", new System.Drawing.Font("Arial",50, FontStyle.Bold, GraphicsUnit.Pixel), brush, postionWaterMark);
            Image img = (Image)bmp;
            img.Save(pathName, System.Drawing.Imaging.ImageFormat.Jpeg);
            graphicsobj.Dispose();
        }


        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }


            return destImage;
        }
    }
}
