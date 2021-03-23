using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    public class Point3D
    {
        private int x;
        private int y;
        private int z;
        private int k;
        private int a;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }
        

        
        private int Convert(double n)
        {
            return (int)Math.Round(k * n + a);
        }

        public Point3D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point3D(double x, double y, double z, int k, int a)
        {
            this.k = k;
            this.a = a;
            this.x = Convert(x);
            // конвертирование в экранные координаты для y надо с противоположным знаком, чтобы изображение не было перевернуто
            this.y = Convert(-y);
            this.z = Convert(z);
        }
    }
}
