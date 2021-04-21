namespace ComputerGraphics
{
    public class Vector
    {
        private double[] coordinates = new double[3];

        public Vector()
        {
        }

        public Vector(double x, double y, double z)
        {
            coordinates[0] = x;
            coordinates[1] = y;
            coordinates[2] = z;
        }

        public double X => coordinates[0];

        public double Y => coordinates[1];

        public double Z => coordinates[2];

        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector sum = new Vector();
            for (int i = 0; i < 3; i++)
            {
                sum[i] = v1[i] + v2[i];
            }

            return sum;
        }

        public double this[int index]
        {
            get { return coordinates[index]; }
            set { coordinates[index] = value; }
        }
    }
}