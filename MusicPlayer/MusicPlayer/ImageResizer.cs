using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    class ImageResizer
    {
        public static Bitmap ResizeImage(Image image, int width)
        {
            int height = (image.Height * width) / image.Width;
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

        public static Image CropCenteredImage(Control ctrl, Image img)
        {
            var cs = ctrl.Size;
            if (img.Size != cs)
            {
                float ratio = Math.Max(cs.Height / (float)img.Height, cs.Width / (float)img.Width);
                if (ratio > 1)
                {
                    Func<float, int> calc = f => (int)Math.Ceiling(f * ratio);
                    img = new Bitmap(img, calc(img.Width), calc(img.Height));
                }

                var part = new Bitmap(cs.Width, cs.Height);
                using (var g = Graphics.FromImage(part))
                {
                    g.DrawImageUnscaled(img, (cs.Width - img.Width) / 2, (cs.Height - img.Height) / 2);
                }
                img = part;
            }
            return img;
        }

        public static List<bool> HashImage(Bitmap bmpSource)
        {
            List<bool> output = new List<bool>();
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {               
                    output.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return output;
        }
    }
}
