using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Labs
{
    static class DataHandler
    {
        public static Bitmap refColor(Bitmap image, Color src, Color dst)
        {
            Bitmap bmp = new Bitmap(image);
            double r = dst.R * 1.0 / src.R;
            double g = dst.G * 1.0 / src.G;
            double b = dst.B * 1.0 / src.B;

            for (int y = 0; y < bmp.Height; ++y)
            {
                for (int x = 0; x < bmp.Width; ++x)
                {
                    var pixel = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(
                        pixel.A,
                        Math.Min((int)(pixel.R * r), 255),
                        Math.Min((int)(pixel.G * g), 255),
                        Math.Min((int)(pixel.B * b), 255)
                    ));
                }
            }
            return bmp;
        }

        public static Bitmap grayWorld(Bitmap image)
        {
            Bitmap bmp = new Bitmap(image);
            int r_avg = 0, g_avg = 0, b_avg = 0;

            for (int y = 0; y < bmp.Height; ++y)
            {
                for (int x = 0; x < bmp.Width; ++x)
                {
                    var pixel = bmp.GetPixel(x, y);
                    r_avg += pixel.R;
                    g_avg += pixel.G;
                    b_avg += pixel.B;
                }
            }
            var N = bmp.Height * bmp.Width;
            r_avg /= N;
            g_avg /= N;
            b_avg /= N;

            var avg = (r_avg + g_avg + b_avg) / 3;

            for (int y = 0; y < bmp.Height; ++y)
            {
                for (int x = 0; x < bmp.Width; ++x)
                {
                    var pixel = bmp.GetPixel(x, y);
                    int r = Math.Min((pixel.R * avg / r_avg), 255);
                    int g = Math.Min((pixel.G * avg / g_avg), 255);
                    int b = Math.Min((pixel.B * avg / b_avg), 255);
                    bmp.SetPixel(x, y, Color.FromArgb(pixel.A, r, g, b));
                }
            }
            return bmp;
        }

        public static Bitmap byFunction(Bitmap image)
        {
            return image;
        }
    }
}
