using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class Point3D
    {
        private int x;
        private int y;
        private int z;
        private int i;
        private int k;
        private int a;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }
        public int I { get => i; set => i = value; }

        private int Convert(double n)
        {
            return (int)Math.Round(k * n + a);
        }
        public Point3D(double x, double y, double z, int k, int a, int I)
        {
            this.k = k;
            this.a = a;
            this.X = Convert(x);
            this.Y = Convert(y);
            this.Z = Convert(z);
            this.i = I;
        }
    }
}
