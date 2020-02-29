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

        public static int[,] GetArray(Bitmap bmp)
        {
            var dst = new int[bmp.Width, bmp.Height];
            for (int x = 0; x < bmp.Width; ++x) 
                for (int y = 0; y < bmp.Height; ++y)
                {
                    dst[x, y] = bmp.GetPixel(x, y).R;
                }
            return dst;
        }

        public static Bitmap GetBitmap(int[,] arr)
        {
            var bmp = new Bitmap(arr.GetLength(0), arr.GetLength(1));
            for (int x = 0; x < bmp.Width; ++x)
                for (int y = 0; y < bmp.Height; ++y)
                {
                    var c = Math.Min(arr[x, y], 255);
                    bmp.SetPixel(x, y, Color.FromArgb(c, c, c));
                }
            return bmp;
        }

        public static Bitmap Test(Bitmap image)
        {
            var arr = GetArray(image);

            /*int[,] mask = new int[,]
            {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            };*/
            var mask = LoadMask(hole_ring);
            var res = Erosion(arr, mask);
            //Console.WriteLine("Res");
            //PrintArr(res);
            return GetBitmap(res);
            //return image;
        }

        public static Bitmap Test1(Bitmap image)
        {
            var arr = GetArray(image);
            /*int[,] mask = new int[,]
            {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            };*/
            var mask1 = LoadMask(hole_ring);
            var res = Erosion(arr, mask1);
            var mask2 = LoadMask(hole_mask);
            res = Dilation(res, mask2);

            return GetBitmap(res);
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
            var mask = GetArray(bmp);
            return mask;
        }
    }
}
