using System;
//using System.Text;
//using System.Windows.Controls;
//using System.Windows.Media;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


public static class ResizeImage 
{
   
   public static Image resizeImage (Image image)
    {
       

       System.Drawing.Image thumbnail =
            new Bitmap(1920, 1920); // changed parm names
        using (System.Drawing.Graphics graphic =
                      System.Drawing.Graphics.FromImage(thumbnail))
        {

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            /* ------------------ new code --------------- */

            // Figure out the ratio
            double ratioX = 1920 / (double)image.Width;
            double ratioY = 1920 / (double)image.Height;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(image.Height * ratio);
            int newWidth = Convert.ToInt32(image.Width * ratio);

            // Now calculate the X,Y position of the upper-left corner 
            // (one of these will always be zero)
            int posX = Convert.ToInt32((1920 - (image.Width * ratio)) / 2);
            int posY = Convert.ToInt32((1920 - (image.Height * ratio)) / 2);

            graphic.Clear(Color.White); // white padding
            graphic.DrawImage(image, posX, posY, newWidth, newHeight);

            /* ------------- end new code ---------------- */

            System.Drawing.Imaging.ImageCodecInfo[] info =
                             ImageCodecInfo.GetImageEncoders();
            EncoderParameters encoderParameters;
            encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality,
                             100L);
            using (MemoryStream ms = new MemoryStream()) { 
            thumbnail.Save(ms, info[1],
            encoderParameters); }
        }
     
        return thumbnail;
       
    }

    public static byte[] newimg = new byte[0];
    public static byte[] ImageToByte(Image img)
    {
        ImageConverter converter = new ImageConverter();
        return (byte[])converter.ConvertTo(img, typeof(byte[]));
    }
//    ImageSourceConverter c = new ImageSourceConverter();
//this.picture.Source = (ImageSource)c.ConvertFrom(bmp);


}