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

        private static int transformColor(int y, int min, int max)
        {
            return Math.Min((y - min) * 255 / (max - min), 255);
        }

        public static int getGrayScale(int r, int g, int b)
        {
            return (int)(0.2126 * r + 0.7152 * g + 0.0722 * b);
        }

        public static Bitmap toGrayscale(Bitmap bmp)
        {
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    int grey = (int)(0.2126 * pixel.R + 0.7152 * pixel.G + 0.0722 * pixel.B);
                    bmp.SetPixel(x, y, Color.FromArgb(grey, grey, grey));
                }
            }
            return bmp;
        }

        public static Bitmap linearCorrection(Bitmap image)
        {
            Bitmap bmp = new Bitmap(image);
            int[] r_hist = new int[256];
            int[] g_hist = new int[256];
            int[] b_hist = new int[256];

            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y) {
                    var pixel = bmp.GetPixel(x, y);
                    r_hist[pixel.R] += 1;
                    g_hist[pixel.G] += 1;
                    b_hist[pixel.B] += 1;
                }
            }

            int r_min = 0, r_max = 255;
            int g_min = 0, g_max = 255;
            int b_min = 0, b_max = 255;
            
            // red hist
            for (int i = 0; i <= 255; ++i)
            {
                if (r_hist[i] != 0)
                {
                    r_min = i;
                    break;
                }
            }
            for (int i = 255; i >= 0; --i)
            {
                if (r_hist[i] != 0)
                {
                    r_max = i;
                    break;
                }
            }

            // green hist
            for (int i = 0; i <= 255; ++i)
            {
                if (g_hist[i] != 0)
                {
                    g_min = i;
                    break;
                }
            }
            for (int i = 255; i >= 0; --i)
            {
                if (g_hist[i] != 0)
                {
                    g_max = i;
                    break;
                }
            }

            // blue hist
            for (int i = 0; i <= 255; ++i)
            {
                if (b_hist[i] != 0)
                {
                    b_min = i;
                    break;
                }
            }
            for (int i = 255; i >= 0; --i)
            {
                if (b_hist[i] != 0)
                {
                    b_max = i;
                    break;
                }
            }

            // transform
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(
                        pixel.A,
                        transformColor(pixel.R, r_min, r_max),
                        transformColor(pixel.G, g_min, g_max),
                        transformColor(pixel.B, b_min, b_max)
                        ));
                }
            }
            return bmp;
        }

        public static Bitmap gammaCorrection(Bitmap image, double gamma = 1)
        {
            Bitmap bmp = new Bitmap(image);
            bmp = toGrayscale(bmp);
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    var c = pixel.R / 255.0;
                    c = Math.Pow(c, 1.0 / gamma);
                    c *= 255;
                    bmp.SetPixel(x, y, Color.FromArgb((int)c, (int)c, (int)c));
                }
            }
            return bmp;
        }

        public static Bitmap histNorm(Bitmap image)
        {
            Bitmap bmp = new Bitmap(image);

            double[] r = new double[256];
            double[] g = new double[256];
            double[] b = new double[256];

            // построение гистограмм
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    r[pixel.R] += 1;
                    g[pixel.G] += 1;
                    b[pixel.B] += 1;
                }
            }

            // нормирование гистограммы
            int N = bmp.Width * bmp.Height;
            for (int i = 0; i < 256; ++i)
            {
                r[i] /= N * 1.0;
                g[i] /= N * 1.0;
                b[i] /= N * 1.0;
            }

            // равномерное распределение значений
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(
                        pixel.A,
                        (int)Math.Round(r[pixel.R] * 255),
                        (int)Math.Round(g[pixel.G] * 255),
                        (int)Math.Round(b[pixel.B] * 255)
                        ));
                }
            }

            return bmp;
        }

        public static Bitmap histEq(Bitmap image)
        {
            Bitmap bmp = new Bitmap(image);

            double[] r = new double[256];
            double[] g = new double[256];
            double[] b = new double[256];
            
            // построение гистограмм
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    r[pixel.R] += 1;
                    g[pixel.G] += 1;
                    b[pixel.B] += 1;
                }
            }

            // нормирование гистограммы
            int N = bmp.Width * bmp.Height;
            for (int i = 0; i < 256; ++i)
            {
                r[i] /= N * 1.0;
                g[i] /= N * 1.0;
                b[i] /= N * 1.0;
            }

            // построение гистограммы с накоплением
            for (int i = 1; i < 256; ++i)
            {
                r[i] = r[i - 1] + r[i];
                g[i] = g[i - 1] + g[i];
                b[i] = b[i - 1] + b[i];
            }

            // равномерное распределение значений
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(
                        pixel.A,
                        (int)Math.Round(r[pixel.R] * 255),
                        (int)Math.Round(g[pixel.G] * 255),
                        (int)Math.Round(b[pixel.B] * 255)
                        ));
                }
            }

            return bmp;
        }

        public static Bitmap quantization(Bitmap image, int levelCnt)
        {
            int cntPerLevel = 256 / levelCnt;
            int[] means = new int[levelCnt];
            for (int i = 0; i < levelCnt; ++i)
            {
                int start = i * cntPerLevel;
                int end = start + cntPerLevel;
                means[i] = (start + end) / 2;
            }

            Bitmap bmp = new Bitmap(image);
            bmp = toGrayscale(bmp);

            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    int level = pixel.R / cntPerLevel;
                    if (level >= levelCnt)
                    {
                        level = levelCnt - 1;
                    }
                    bmp.SetPixel(x, y, Color.FromArgb(pixel.A, means[level], means[level], means[level]));
                }
            }

            return bmp;
        }

        public static Bitmap binarizationWithThreshold(Bitmap image, int threshold, bool upper)
        {
            Color c1 = Color.White;
            Color c2 = Color.Black;
            if (!upper)
            {
                c1 = Color.Black;
                c2 = Color.White;
            }

            Bitmap bmp = new Bitmap(image);
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    var g = getGrayScale(pixel.R, pixel.G, pixel.B);

                    if (g < threshold)
                    {
                        bmp.SetPixel(x, y, c1);
                    } else
                    {
                        bmp.SetPixel(x, y, c2);
                    }
                }
            }
            return bmp;
        }

        public static Bitmap binarizationWithRange(Bitmap image, int threshold1, int threshold2)
        {
            Bitmap bmp = new Bitmap(image);
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    var g = getGrayScale(pixel.R, pixel.G, pixel.B);

                    if (threshold1 <= g && g < threshold2)
                    {
                        bmp.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        bmp.SetPixel(x, y, Color.Black);
                    }
                }
            }
            return bmp;
        }

        private static int[] getGrayscaleHist(Bitmap bmp)
        {
            int[] hist = new int[256];
            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    var g = getGrayScale(pixel.R, pixel.G, pixel.B);
                    hist[g] += 1;
                }
            }
            return hist;
        }

        private static int Otsu1(int[] hist)
        {
            int intensitySum = 0;
            double m = 0;
            for (int i = 0; i < 256; ++i)
            {
                m += hist[i];
                intensitySum += hist[i] * i;
            }
            m /= intensitySum;

            int q1 = hist[0], q2 = 0;
            double m1 = 0, m2 = 0;

            int t = 0;
            double max = 0;
            for (int i = 1; i < 256; ++i)
            {
                q2 = q1 + hist[i];
                m1 = (q1 * m1 + i * hist[i]) / q2;
                m2 = (m - q2 * m1) / (1 - q2);
                q1 = q2;
                double disp = q1 * (1 - q1) * (m1 - m2) * (m1 - m2);
                if (disp > max)
                {
                    max = disp;
                    t = i;
                }
            }
            
            return t;
        }

        private static int Otsu(int[] hist)
        {
            int allPixelCnt = 0;
            int allIntensitySum = 0;
            for (int i = 0; i < 256; ++i)
            {
                allPixelCnt += hist[i];
                allIntensitySum += i * hist[i];
            }

            int t = 0;
            double maxSigma = 0;
            
            int pixelCnt = 0;
            int intensitySum = 0;

            for (int i = 0; i < 255; ++i)
            {
                pixelCnt += hist[i];
                intensitySum += i * hist[i];

                double prob = pixelCnt / (double)allPixelCnt;

                double mean1 = intensitySum / (double)pixelCnt;
                double mean2 = (allIntensitySum - intensitySum) 
                    / (double)(allPixelCnt - pixelCnt);
                
                double sigma = prob * (1.0 - prob) * (mean1 - mean2) * (mean1 - mean2);

                if (sigma > maxSigma)
                {
                    maxSigma = sigma;
                    t = i;
                }
            }
            return t;
        }

        public static Bitmap OtsuGlobal(Bitmap image)
        {
            Bitmap bmp = new Bitmap(image);
            var hist = getGrayscaleHist(image);
            var t = Otsu(hist);

            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    var g = getGrayScale(pixel.R, pixel.G, pixel.B);
                    if (g > t)
                    {
                        bmp.SetPixel(x, y, Color.White);
                    } else
                    {
                        bmp.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return bmp;
        }

        private static void divideImage(
            Bitmap image, 
            out Bitmap bmp1, 
            out Bitmap bmp2, 
            out bool byWidth
            )
        {
            int width, height, x1, y1, x2, y2;
            if (image.Width > image.Height)
            {
                byWidth = true;
                width = image.Width / 2;
                height = image.Height;

                x1 = 0;
                y1 = 0;
                x2 = width;
                y2 = 0;
            }
            // divide by height
            else
            {
                byWidth = false;
                width = image.Width;
                height = image.Height / 2;

                x1 = 0;
                y1 = 0;
                x2 = 0;
                y2 = height;
            }
            Rectangle rect1 = new Rectangle(x1, y1, width, height);
            Rectangle rect2 = new Rectangle(x2, y2, width, height);

            bmp1 = new Bitmap(rect1.Width, rect1.Height);
            Graphics g = Graphics.FromImage(bmp1);
            g.DrawImage(image, new Rectangle(0, 0, bmp1.Width, bmp1.Height), rect1, GraphicsUnit.Pixel);

            bmp2 = new Bitmap(rect2.Width, rect2.Height);
            Graphics g2 = Graphics.FromImage(bmp2);
            g2.DrawImage(image, new Rectangle(0, 0, bmp2.Width, bmp2.Height), rect2, GraphicsUnit.Pixel);
        }

        private static Bitmap combineImages(Bitmap bmp1, Bitmap bmp2, bool byWidth)
        {
            int width, height, x2, y2;
            if (byWidth)
            {
                width = bmp1.Width + bmp2.Width;
                height = bmp1.Height;
                x2 = bmp1.Width;
                y2 = 0;
            } else
            {
                width = bmp1.Width;
                height = bmp1.Height + bmp2.Height;
                x2 = 0;
                y2 = bmp1.Height;
            }
            Bitmap res = new Bitmap(width, height);
            Rectangle rect1 = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
            Rectangle rect2 = new Rectangle(x2, y2, bmp2.Width, bmp2.Height);

            Graphics g = Graphics.FromImage(res);
            g.DrawImage(bmp1, rect1, new Rectangle(0, 0, bmp1.Width, bmp1.Height), GraphicsUnit.Pixel);
            g.DrawImage(bmp2, rect2, new Rectangle(0, 0, bmp2.Width, bmp2.Height), GraphicsUnit.Pixel);

            return res;
        }


        public static Bitmap OtsuLocal(Bitmap image)
        {
            //Bitmap bmp = new Bitmap(image);

            Bitmap bmp1, bmp2;
            bool byWidth;
            divideImage(image, out bmp1, out bmp2, out byWidth);

            bmp1 = OtsuGlobal(bmp1);
            bmp2 = OtsuGlobal(bmp2);

            Bitmap bmp = combineImages(bmp1, bmp2, byWidth);      
            return bmp;
        }

        public static Bitmap OtsuHierarchy(Bitmap image, int minSize)
        {
            Bitmap bmp = new Bitmap(image);
            Color c1 = Color.Black, c2 = Color.White;

            List<int> listT = new List<int>();
            var cnt = image.Width * image.Height;
            var hist = getGrayscaleHist(image);
            double[] normedHist = new double[256];
            for (int i = 0; i < 256; ++i)
            {
                normedHist[i] = hist[i] * 1.0 / cnt;
            }
            OtsuRecursive(normedHist, listT, minSize);
            listT = listT.OrderBy(x => x).ToList();

            for (int x = 0; x < bmp.Width; ++x)
            {
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var pixel = bmp.GetPixel(x, y);
                    var first = listT.FindIndex(c => c > pixel.R);
                    if (first % 2 == 0)
                    {
                        bmp.SetPixel(x, y, c1);
                    } else
                    {
                        bmp.SetPixel(x, y, c2);
                    }
                }
            }

            return bmp;
        }

        private static void OtsuRecursive(double[] hist, List<int> listT, int minSize)
        {
            if (minSize == 0 || hist.Length < 3) return;

            double q = hist[0];
            double m1 = 0, m2 = 0;
            double n = 0, m = 0;
            for (int i = 0; i < hist.Length; ++i)
            {
                n += hist[i];
                m += hist[i] * i;
            }
            m /= n;

            int t = 0;
            double maxSigma = 0;
            for (int i = 0; i < hist.Length; ++i)
            {
                m1 = q * m1 + i * hist[i];
                q += hist[i];
                if (Math.Abs(q) < 0.0001 || Math.Abs(q - 1) < 0.0001) continue;
                m1 /= q;
                m2 = (m - q * m1) / (1 - q);
                double d = Math.Sqrt(q * (1 - q) * (m1 - m2) * (m1 - m2));
                if (d > maxSigma)
                {
                    maxSigma = d;
                    t = i;
                }
            }
            listT.Add(t);

            if (t > 0)
            {
                double[] hist1 = new double[t];
                for (int i = 0; i < t; ++i)
                    hist1[i] = hist[i];
                OtsuRecursive(hist1, listT, minSize - 1);

                double[] hist2 = new double[hist.Length - t];
                for (int i = t; i < hist.Length; ++i)
                    hist2[i - t] = hist[i];
                OtsuRecursive(hist2, listT, minSize - 1);
            }
           
        }
    }
}
