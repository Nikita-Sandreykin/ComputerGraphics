using System;

namespace ComputerGraphics
{
    public class VectorUtil
    {
        public static readonly Vector directionEarth = new Vector(0, 0, 1);
        public static readonly int directionEarthVectorLength = 1;

        public static Vector getVectorNormal(Polygon polygon)
        {
            double x0 = polygon[0].X;
            double y0 = polygon[0].Y;
            double z0 = polygon[0].Z;
            double x1 = polygon[1].X;
            double y1 = polygon[1].Y;
            double z1 = polygon[1].Z;
            double x2 = polygon[2].X;
            double y2 = polygon[2].Y;
            double z2 = polygon[2].Z;
            // нахождение координат нормали через определитель
            double x = (y1 - y0) * (z1 - z2) - (z1 - z0) * (y1 - y2);
            double y = (x1 - x0) * (z1 - z2) - (z1 - z0) * (x1 - x2);
            double z = (x1 - x0) * (y1 - y2) - (y1 - y0) * (x1 - x2);
            return new Vector(x, y, z);
        }

        public static double cosDirectionEarthNormal(Polygon polygon)
        {
            Vector normalVector = getVectorNormal(polygon);
            double innerProduct = normalVector.X * directionEarth.X + normalVector.Y * directionEarth.Y +
                                  normalVector.Z * directionEarth.Z;
            double normalVectorLength = Math.Sqrt(normalVector.X * normalVector.X + normalVector.Y * normalVector.Y +
                                                  normalVector.Z * normalVector.Z);
            return innerProduct / normalVectorLength * directionEarthVectorLength;
        }
    }
}