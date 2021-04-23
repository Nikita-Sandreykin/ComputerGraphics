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
        private double initialX;
        private int y;
        private double initialY;
        private int z;
        private double initialZ;
        private int k;
        private int a;

        public int X
        {
            get => x;
            set => x = value;
        }

        public int Y
        {
            get => y;
            set => y = value;
        }

        public int Z
        {
            get => z;
            set => z = value;
        }

        public double InitialX
        {
            get => initialX;
            set => initialX = value;
        }

        public double InitialY
        {
            get => initialY;
            set => initialY = value;
        }

        public double InitialZ
        {
            get => initialZ;
            set => initialZ = value;
        }


        private int Convert(double n)
        {
            return (int) Math.Round(k * n + a);
        }

        public Point3D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point3D(double x, double y, double z, int angleX, int angleY, int angleZ)
        {
            initialX = x;
            initialY = y;
            initialZ = z;
            double[,] initVector = {{x}, {y}, {z}};
            double[,] r1 =
            {
                {1, 0, 0}, {0, Math.Cos(angleToRadian(angleX)), Math.Sin(angleToRadian(angleX))},
                {0, -Math.Sin(angleToRadian(angleX)), Math.Cos(angleToRadian(angleX))}
            };
            double[,] r2 =
            {
                {Math.Cos(angleToRadian(angleY)), 0, Math.Sin(angleToRadian(angleY))}, {0, 1, 0},
                {-Math.Sin(angleToRadian(angleY)), 0, Math.Cos(angleToRadian(angleY))}
            };
            double[,] r3 =
            {
                {Math.Cos(angleToRadian(angleZ)), Math.Sin(angleToRadian(angleZ)), 0},
                {-Math.Sin(angleToRadian(angleZ)), Math.Cos(angleToRadian(angleZ)), 0}, {0, 0, 1}
            };
            double[,] r = MatrixUtil.multiplyMatrix(MatrixUtil.multiplyMatrix(r1, r2), r3);
            double[,] turnVector = MatrixUtil.multiplyMatrix(r, initVector);
            double[,] projectiveTransformationVector = MatrixUtil.projectiveTransformation(turnVector);
            this.x = (int) (projectiveTransformationVector[0, 0] / projectiveTransformationVector[2, 0]);
            this.y = (int) (projectiveTransformationVector[1, 0] / projectiveTransformationVector[2, 0]);
            this.z = (int) projectiveTransformationVector[2, 0];
        }

        public static double angleToRadian(int angle)
        {
            return angle * Math.PI / 180;
        }

        public Point3D(double x, double y, double z, int k, int a)
        {
            initialX = x;
            initialY = y;
            InitialZ = z;
            this.k = k;
            this.a = a;
            this.x = Convert(x);
            // конвертирование в экранные координаты для y надо с противоположным знаком, чтобы изображение не было перевернуто
            this.y = Convert(-y);
            this.z = Convert(z);
        }
    }
}