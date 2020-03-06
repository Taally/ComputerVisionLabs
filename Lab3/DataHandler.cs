using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class DataHandler
    {
        const string hole_ring = "hole_ring";
        const string hole_mask = "hole_mask";
        const string gear_body = "gear_body";
        const string tip_spacing = "tip_spacing";
        const string defect_cue = "defect_cue";



        const string hole_ring1 = "hole_ring1";
        const string hole_ring_rev = "hole_ring_rev";
        const string hole_ring1_rev = "hole_ring1_rev";


        public static int[,] GetMaskArray(Bitmap bmp)
        {
            var dst = new int[bmp.Width, bmp.Height];
            for (int x = 0; x < bmp.Width; ++x)
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var c = bmp.GetPixel(x, y);
                    dst[x, y] = c.R / 255 >= 0.5 ? 1 : 0;
                }
            return dst;
        }

        public static int[,] GetArray(Bitmap bmp)
        {
            var dst = new int[bmp.Width, bmp.Height];
            for (int x = 0; x < bmp.Width; ++x) 
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var c = bmp.GetPixel(x, y);
                    dst[x, y] = bmp.GetPixel(x, y).R / 255 >= 0.5 ? 1 : 0;
                }
            return dst;
        }

        public static Bitmap GetBitmap(int[,] arr)
        {
            var bmp = new Bitmap(arr.GetLength(0), arr.GetLength(1));
            for (int x = 0; x < bmp.Width; ++x)
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var c = Math.Min(arr[x, y] * 255, 255);
                    bmp.SetPixel(x, y, Color.FromArgb(c, c, c));
                }
            return bmp;
        }

        public static int[,] Step1(int[,] arr)
        {
            var mask = LoadMask(hole_ring);
            var res = Erosion(arr, mask);
            return res;
        }

        public static int[,] Step2(int[,] arr)
        {
            var mask = LoadMask(hole_mask);
            var res = Dilation(arr, mask);
            return res;
        }

        // B3 = B OR B2
        public static int[,] Step3(int [,] arr1, int[,] arr2)
        {
            return Or(arr1, arr2);
        }

        public static int[,] Or(int[,] arr1, int[,] arr2)
        {
            int w = arr1.GetLength(0);
            int h = arr1.GetLength(1);

            int[,] dst = new int[w, h];
            for (int x = 0; x < w; ++x)
                for (int y = 0; y < h; ++y)
                {
                    var res = 0;
                    if (arr1[x, y] == 1 || arr2[x, y] == 1)
                    {
                        res = 1;
                    }
                    dst[x, y] = res;
                }
            return dst;
        }

        // B8 = B AND B7
        public static int[,] Step4(int[,] arr)
        {
            var mask = LoadMask(gear_body);
            return And(arr, mask);
        }

        public static int[,] And(int[,] arr1, int[,] arr2)
        {
            int w = arr1.GetLength(0);
            int h = arr1.GetLength(1);

            int[,] dst = new int[w, h];
            for (int x = 0; x < w; ++x)
                for (int y = 0; y < h; ++y)
                {
                    var res = 0;
                    if (arr1[x, y] == 1 && arr2[x, y] == 1)
                    {
                        res = 1;
                    }
                    dst[x, y] = res;
                }
            return dst;
        }

        // B9 = B8 (+) tip_spacing
        public static int[,] Step5(int[,] arr)
        {
            var mask = LoadMask(tip_spacing);
            var res = Dilation(arr, mask);
            return res;
        }

        // result = ((B7-B9) (+) defect_cue) OR B9
        public static int[,] Step6(int[,] B9)
        {
            var B7 = LoadMask(gear_body);
            var mask = LoadMask(defect_cue);
            var res = Subtract(B7, B9);
            res = Dilation(res, mask);
            res = Or(res, B9);
            return res;
        }

        public static int[,] Subtract(int[,] arr1, int[,] arr2)
        {
            int w = arr1.GetLength(0);
            int h = arr1.GetLength(1);

            int[,] dst = new int[w, h];
            for (int x = 0; x < w; ++x)
                for (int y = 0; y < h; ++y)
                {
                    dst[x, y] = arr1[x,y] - arr2[x,y];
                }
            return dst;
        }

        public static void PrintArr(int[,] arr)
        {
            for (int x = 0; x < arr.GetLength(0); ++x)
            {
                for (int y = 0; y < arr.GetLength(1); ++y)
                    Console.Write(arr[x, y] + " ");
                Console.WriteLine();
            }
        }

        public static int[,] Dilation(int[,] src, int[,] mask)
        {
            int w = src.GetLength(0);
            int h = src.GetLength(1);
            int mw = mask.GetLength(0) / 2;
            int mh = mask.GetLength(1) / 2;

            int[,] dst = new int[w, h];
            for (int y = mh; y < h - mh; ++y)
                for (int x = mw; x< w - mw; ++x)
                {
                    int max = 0;
                    for (int j = -mh; j < mh; ++j)
                        for (int i = -mw; i < mw; ++i)
                        {
                            if (mask[i+mw, j+mh] == 1 && src[x + i, y + j] > max)
                                max = src[x + i, y + j];
                        }
                    dst[x, y] = max;
                }

            return dst;
        }

        public static int[,] Erosion(int[,] src, int[,] mask)
        {
            int w = src.GetLength(0);
            int h = src.GetLength(1);
            int mw = mask.GetLength(0) / 2;
            int mh = mask.GetLength(1) / 2;

            int[,] dst = new int[w, h];
            for (int y = mh; y < h - mh; ++y)
                for (int x = mw; x < w - mw; ++x)
                {
                    int min = Int32.MaxValue;
                    for (int j = -mh; j < mh; ++j)
                        for (int i = -mw; i < mw; ++i)
                        {
                            if (mask[i + mw, j + mh] == 1 && src[x + i, y + j] < min)
                                min = src[x + i, y + j];
                        }
                    dst[x, y] = min;
                }

            return dst;
        }

        public static int[,] Closing(int[,] src, int[,] mask)
        {
            var d = Dilation(src, mask);
            var res = Erosion(d, mask);
            return res;
        }

        public static int[,] Opening(int[,] src, int[,] mask)
        {
            var e = Erosion(src, mask);
            var res = Dilation(e, mask);
            return res;
        }

        public static int[,] LoadMask(string name)
        {
            var path = System.Environment.CurrentDirectory;
            path = System.IO.Directory.GetParent(path).FullName;
            path = System.IO.Directory.GetParent(path).FullName;

            var imagePath = System.IO.Path.Combine(path.ToString(), name + ".png");
            var bmp = new Bitmap(Bitmap.FromFile(imagePath));
            var mask = GetMaskArray(bmp);
            return mask;
        }
    }
}
