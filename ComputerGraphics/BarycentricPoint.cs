using System;

namespace ComputerGraphics
{
    public class BarycentricPoint
    {
        private Polygon polygon;

        private double lambda0;
        private double lambda1;
        private double lambda2;

        public double Lambda0 => lambda0;

        public double Lambda1 => lambda1;

        public double Lambda2 => lambda2;

        public BarycentricPoint(Polygon polygon)
        {
            this.polygon = polygon;
        }

        public void calculateLambds(Point3D screenPoint)
        {
            double x0 = polygon[0].X;
            double y0 = polygon[0].Y;
            double x1 = polygon[1].X;
            double y1 = polygon[1].Y;
            double x2 = polygon[2].X;
            double y2 = polygon[2].Y;
            double y = screenPoint.Y;
            double x = screenPoint.X;
            lambda0 = ((x1 - x2) * (y - y2) - (y1 - y2) * (x - x2)) /
                      ((x1 - x2) * (y0 - y2) - (y1 - y2) * (x0 - x2));
            lambda1 = ((x2 - x0) * (y - y0) - (y2 - y0) * (x - x0)) /
                      ((x2 - x0) * (y1 - y0) - (y2 - y0) * (x1 - x0));
            lambda2 = ((x0 - x1) * (y - y1) - (y0 - y1) * (x - x1)) /
                      ((x0 - x1) * (y2 - y1) - (y0 - y1) * (x2 - x1));
        }
    }
}