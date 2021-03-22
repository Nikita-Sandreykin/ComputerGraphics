using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics
{
    public class Polygon
    {
        private Point3D[] points = new Point3D[3];
        internal Polygon()
        {
        }
        internal Polygon(Point3D p1, Point3D p2, Point3D p3)
        {
            this.points[0] = p1;
            this.points[1] = p2;
            this.points[2] = p3;
        }
        public Point3D this[int index]
        {
            get
            {
                return points[index];
            }
            set
            {
                points[index] = value;
            }
        }
    }
}
