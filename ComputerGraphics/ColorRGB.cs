using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class ColorRGB
    {
        private int red;
        private int green;
        private int blue;
        public ColorRGB(int R, int G, int B)
        {
            Red = R;
            Green = G;
            Blue = B;
        }

        public int Red { get => red; set => red = value; }
        public int Green { get => green; set => green = value; }
        public int Blue { get => blue; set => blue = value; }
    }
}
