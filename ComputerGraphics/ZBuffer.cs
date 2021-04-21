using System;
using System.Collections.Generic;

namespace ComputerGraphics
{
    public class ZBuffer
    {
        private int height;
        private int width;
        private List<double> zBuffer = new List<double>();
        public ZBuffer(int width, int height)
        {
            this.width = width;
            this.height = height;
            for(int i = 0; i < width * height; i++)
            {
                zBuffer.Add(Double.PositiveInfinity);
            }
        }
        public void setZBuffer(int x, int y, double z)
        {
            zBuffer[x + width * y] = z;
        }
        public double getZBuffer(int x, int y)
        {
            return zBuffer[x + width * y];
        }
    }
}