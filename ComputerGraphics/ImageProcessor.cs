using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class ImageProcessor
    {
        public static Color ColorRGBtoColor(ColorRGB value)
        {
            Color color = Color.FromArgb(value.Red, value.Green, value.Blue);
            return color;
        }

        public static Bitmap Image2DtoBitmap(Image2D image2D)
        {
            Bitmap result = new Bitmap(image2D.Width, image2D.Height);
            for (int x = 0; x < image2D.Width; x++)
            {
                for (int y = 0; y < image2D.Height; y++)
                {
                    result.SetPixel(x, y, ImageProcessor.ColorRGBtoColor(image2D.getColor(x, y)));
                }
            }

            return result;
        }

        public static void line1(int x0, int y0, int x1, int y1, Image2D image, ColorRGB color)
        {
            for (float t = 0.0F; t < 1.0F; t += 0.01F)
            {
                int x = Convert.ToInt32(x0 * (1 - t) + x1 * t);
                int y = Convert.ToInt32(y0 * (1 - t) + y1 * t);
                image.setPixel(x, y, color);
            }
        }

        public static void line2(int x0, int y0, int x1, int y1, Image2D image, ColorRGB color)
        {
            for (int x = x0; x <= x1; x++)
            {
                float t = (x - x0) / (float) (x1 - x0);
                int y = Convert.ToInt32(y0 * (1 - t) + y1 * t);
                image.setPixel(x, y, color);
            }
        }

        public static void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public static void line3(int x0, int y0, int x1, int y1, Image2D image, ColorRGB color)
        {
            bool steep = false;
            if (Math.Abs(x0 - x1) < Math.Abs(y0 - y1))
            {
                swap(ref x0, ref y0);
                swap(ref x1, ref y1);
                steep = true;
            }

            if (x0 > x1)
            {
                swap(ref x0, ref x1);
                swap(ref y0, ref y1);
            }

            for (int x = x0; x <= x1; x++)
            {
                float t = (x - x0) / (float) (x1 - x0);
                int y = Convert.ToInt32(y0 * (1 - t) + y1 * t);
                if (steep)
                {
                    image.setPixel(y, x, color);
                }
                else
                {
                    image.setPixel(x, y, color);
                }
            }
        }

        public static void line4(int x0, int y0, int x1, int y1, Image2D image, ColorRGB color)
        {
            bool steep = false;
            if (Math.Abs(x0 - x1) < Math.Abs(y0 - y1))
            {
                swap(ref x0, ref y0);
                swap(ref x1, ref y1);
                steep = true;
            }

            if (x0 > x1)
            {
                swap(ref x0, ref x1);
                swap(ref y0, ref y1);
            }

            int dx = x1 - x0;
            int dy = y1 - y0;
            float derror = Math.Abs(dy / (float) dx);
            float error = 0;
            int y = y0;

            for (int x = x0; x <= x1; x++)
            {
                if (steep)
                {
                    image.setPixel(y, x, color);
                }
                else
                {
                    image.setPixel(x, y, color);
                }

                error += derror;
                if (error > 0.5)
                {
                    y += (y1 > y0 ? 1 : -1);
                    error -= 1.0F;
                }
            }
        }
        
        public static void rawTriangle(Polygon polygon, Image2D image2D, ColorRGB colorRgb)
        {
            int xMin = Math.Min(Math.Min(polygon[0].X, polygon[1].X), polygon[2].X) < 0
                ? 0
                : Math.Min(Math.Min(polygon[0].X, polygon[1].X), polygon[2].X);
            int xMax = Math.Max(Math.Max(polygon[0].X, polygon[1].X), polygon[2].X) > image2D.Width
                ? image2D.Width
                : Math.Max(Math.Max(polygon[0].X, polygon[1].X), polygon[2].X);
            int yMin = Math.Min(Math.Min(polygon[0].Y, polygon[1].Y), polygon[2].Y) < 0
                ? 0
                : Math.Min(Math.Min(polygon[0].Y, polygon[1].Y), polygon[2].Y);
            int yMax = Math.Max(Math.Max(polygon[0].Y, polygon[1].Y), polygon[2].Y) > image2D.Height
                ? image2D.Height
                : Math.Max(Math.Max(polygon[0].Y, polygon[1].Y), polygon[2].Y);
            BarycentricPoint barycentricPoint = new BarycentricPoint(polygon);
            
            for (int x = xMin; x < xMax; x++)
            {
                for (int y = yMin; y < yMax; y++)
                {
                    barycentricPoint.calculateLambds(new Point3D(x, y));
                    if (barycentricPoint.Lambda0 >= 0 && barycentricPoint.Lambda1 >= 0 && barycentricPoint.Lambda2 >= 0)
                    {
                     image2D.setPixel(x, y, colorRgb);   
                    }
                }
            }
        }
    }
}