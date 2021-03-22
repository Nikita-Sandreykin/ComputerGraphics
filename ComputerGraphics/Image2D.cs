using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class Image2D
    {
        private int height;
        private int width;
        private List<ColorRGB> colorsList = new List<ColorRGB>();
        public Image2D(int width, int height)
        {
            this.width = width;
            this.height = height;
            for(int i = 0; i < width * height; i++)
            {
                colorsList.Add(new ColorRGB(0, 0, 0));
            }
        }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }

        public void setPixel(int x, int y, ColorRGB colorRGB)
        {
            colorsList[x + this.Width * y] = colorRGB;
        }
        public ColorRGB getColor(int x, int y)
        {
            return colorsList[x + this.Width * y];
        }
    }
}
