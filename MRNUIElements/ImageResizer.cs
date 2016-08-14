using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Media.Imaging;

using System.Windows.Media;
using System.Drawing;

namespace MRNUIElements.ImageManipulation
{
    public class ImageResizer
    {
        public System.Drawing.Image ImageResize(System.Drawing.Image image, System.Drawing.Size size, bool aspectratiopreserve = true)
        {
            Size a = new Size(); a.Width = 1280; a.Height = 900; if (a.Width < size.Width || a.Height < size.Height || size.Height > a.Width || size.Width > a.Height)
                size.Height = size.Width = 1280;



            return ResizeImage(image, size, aspectratiopreserve);
        }
        public static Image ResizeImage(Image image, Size size,
            bool preserveAspectRatio = true)
        {

            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

      

        private Image ConvertDrawingImageToWPFImage(BitmapImage image)
        {
            throw new NotImplementedException();
        }

        private System.Windows.Controls.Image ConvertDrawingImageToWPFImage(System.Drawing.Image gdiImg)
    {


        System.Windows.Controls.Image img = new System.Windows.Controls.Image();

        //convert System.Drawing.Image to WPF image
        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(gdiImg);
        IntPtr hBitmap = bmp.GetHbitmap();
        System.Windows.Media.ImageSource WpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

        img.Source = WpfBitmap;
        img.Width = 500;
        img.Height = 600;
        img.Stretch = System.Windows.Media.Stretch.Fill;
        return img;
    }
} }
