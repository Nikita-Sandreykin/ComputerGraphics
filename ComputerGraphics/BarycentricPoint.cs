using System;

namespace ComputerGraphics
{
    public class BarycentricPoint
    {
        public static bool sumLambdsIsOne(Polygon polygon, Point3D screenPoint)
        {
            double x0 = polygon[0].InitialX;
            double y0 = polygon[0].InitialY;
            double x1 = polygon[1].InitialX;
            double y1 = polygon[1].InitialY;
            double x2 = polygon[2].InitialX;
            double y2 = polygon[2].InitialY;
            double lambda0 = ((x1 - x2) * (screenPoint.Y - y2) - (y1 - y2) * (screenPoint.X - x2)) /
                             ((x1 - x2) * (y0 - y2) - (y1 - y2) * (x0 - x2));
            double lambda1 = ((x2 - x0) * (screenPoint.Y - y0) - (y2 - y0) * (screenPoint.X - x0)) /
                             ((x2 - x0) * (y1 - y0) - (y2 - y0) * (x1 - x0));
            double lambda2 = ((x0 - x1) * (screenPoint.Y - y1) - (y0 - y1) * (screenPoint.X - x1)) /
                             ((x0 - x1) * (y2 - y1) - (y0 - y1) * (x2 - x1));
            return Math.Abs(1 - lambda0 - lambda1 - lambda2) < 0.000001;
        }
    }
}