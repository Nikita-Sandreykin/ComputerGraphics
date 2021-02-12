using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    class Polygon
    {
        private Point3D[] p = new Point3D[3];
        internal Polygon()
        {
        }
        internal Polygon(Point3D p1, Point3D p2, Point3D p3)
        {
            this.p[0] = p1;
            this.p[1] = p2;
            this.p[2] = p3;
        }
        public Point3D this[int index]
        {
            get
            {
                return p[index];
            }
            set
            {
                p[index] = value;
            }
        }
    }
}
