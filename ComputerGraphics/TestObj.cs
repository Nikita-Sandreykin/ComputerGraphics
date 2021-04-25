using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public partial class TestObj : Form
    {
        private DrawLine line;
        internal List<Point3D> points = new List<Point3D>();
        internal List<Polygon> polygons = new List<Polygon>();
        internal List<Vector> normalVectors = new List<Vector>();

        public TestObj(bool move)
        {
            if (move)
            {
                InitializeComponentWithMoving();
            }
            else
            {
                InitializeComponent();
            }
        }

        private void TestObj_Load(object sender, EventArgs e)
        {
        }

        private void turn(object sender, EventArgs e)
        {
            polygons.Clear();
            points.Clear();
            List<string> file = new List<string>();
            using (StreamReader sr = new StreamReader(@"Test.obj", System.Text.Encoding.Default))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    file.Add(str);
                }
            }

            Regex floatNumber = new Regex(@"(?:-)?\d*[.]\d*");
            Regex intNumber = new Regex(@"\d+");
            foreach (string temp in file)
            {
                if (temp[0] == 'v' && temp[1] == ' ')
                {
                    MatchCollection matchCollection = floatNumber.Matches(temp);
                    double x = Convert.ToDouble(matchCollection[0].Value.Replace('.', ','));
                    double y = Convert.ToDouble(matchCollection[1].Value.Replace('.', ','));
                    double z = Convert.ToDouble(matchCollection[2].Value.Replace('.', ','));
                    Point3D point = new Point3D(x, y, z, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text),
                        Convert.ToInt32(textBox3.Text));
                    points.Add(point);
                }

                if (temp[0] == 'v' && temp[1] == 'n')
                {
                    MatchCollection matchCollection = floatNumber.Matches(temp);
                    double x = Convert.ToDouble(matchCollection[0].Value.Replace('.', ','));
                    double y = Convert.ToDouble(matchCollection[1].Value.Replace('.', ','));
                    double z = Convert.ToDouble(matchCollection[2].Value.Replace('.', ','));
                    Vector normalVector = new Vector(x, y, z);
                    normalVectors.Add(normalVector);
                }

                if (temp[0] == 'f')
                {
                    MatchCollection matchCollection = intNumber.Matches(temp);
                    int p1 = Convert.ToInt32(matchCollection[0].Value);
                    int n1 = Convert.ToInt32(matchCollection[2].Value);
                    int p2 = Convert.ToInt32(matchCollection[3].Value);
                    int n2 = Convert.ToInt32(matchCollection[5].Value);
                    int p3 = Convert.ToInt32(matchCollection[6].Value);
                    int n3 = Convert.ToInt32(matchCollection[8].Value);
                    Polygon polygon = new Polygon();
                    polygon[0] = points[p1 - 1];
                    polygon.Norms[0] = normalVectors[n1 - 1];
                    polygon[1] = points[p2 - 1];
                    polygon.Norms[1] = normalVectors[n2 - 1];
                    polygon[2] = points[p3 - 1];
                    polygon.Norms[2] = normalVectors[n3 - 1];
                    polygons.Add(polygon);
                    // далее пойдет просто проверка на расчет бприцентрических координат точки относительно вершин треуголника
                    // здесь это удобнее так как тут идет создание всех полигонов модели 
                    BarycentricPoint barycentricPoint = new BarycentricPoint(polygon);
                    barycentricPoint.calculateLambds(polygon[0]);
                    if (Math.Abs(1 - barycentricPoint.Lambda0 - barycentricPoint.Lambda1 -
                                 barycentricPoint.Lambda2) > 0.001)
                    {
                        MessageBox.Show("Сумма барицентрических координат не равна 1!!!", "Ошибка",
                            MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void rawPoints(object sender, EventArgs e)
        {
            Image2D pointsImage = new Image2D(1000, 1000);
            foreach (Point3D temp in points)
            {
                pointsImage.setPixel(temp.X, temp.Y, new ColorRGB(255, 0, 0));
            }

            Bitmap image = ImageProcessor.Image2DtoBitmap(pointsImage);
            pictureBox1.Image = image;
        }

        private void rawPolygons(object sender, EventArgs e)
        {
            Image2D polygonsImage = new Image2D(1700, 1500);
            line = ImageProcessor.line4;
            foreach (Polygon pol in polygons)
            {
                line(pol[0].X, pol[0].Y, pol[1].X, pol[1].Y, polygonsImage, new ColorRGB(0, 0, 255));
                line(pol[0].X, pol[0].Y, pol[2].X, pol[2].Y, polygonsImage, new ColorRGB(0, 0, 255));
                line(pol[1].X, pol[1].Y, pol[2].X, pol[2].Y, polygonsImage, new ColorRGB(0, 0, 255));
            }

            Bitmap image = ImageProcessor.Image2DtoBitmap(polygonsImage);
            pictureBox1.Image = image;
        }

        private void rawTriangles(object sender, EventArgs e)
        {
            Image2D polygonsImage = new Image2D(1000, 1000);
            Random random = new Random();
            foreach (Polygon pol in polygons)
            {
                ImageProcessor.rawTriangle(pol, polygonsImage,
                    new ColorRGB(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
            }

            Bitmap image = ImageProcessor.Image2DtoBitmap(polygonsImage);
            pictureBox1.Image = image;
        }

        private void basicLighting(object sender, EventArgs e)
        {
            Image2D polygonsImage = new Image2D(1000, 1000);
            foreach (Polygon pol in polygons)
            {
                if (MatrixUtil.cosDirectionEarthNormal(pol) >= 0)
                {
                    continue;
                }

                ImageProcessor.rawTriangle(pol, polygonsImage,
                    new ColorRGB((int) Math.Abs(MatrixUtil.cosDirectionEarthNormal(pol) * 255), 0, 0));
            }

            Bitmap image = ImageProcessor.Image2DtoBitmap(polygonsImage);
            pictureBox1.Image = image;
        }

        private void zBuffer(object sender, EventArgs e)
        {
            Image2D polygonsImage = new Image2D(1000, 1000);
            ZBuffer zBuffer = new ZBuffer(1000, 1000);
            foreach (Polygon pol in polygons)
            {
                if (MatrixUtil.cosDirectionEarthNormal(pol) >= 0)
                {
                    continue;
                }

                ImageProcessor.rawTriangleWithZBuffer(pol, polygonsImage,
                    new ColorRGB((int) Math.Abs(MatrixUtil.cosDirectionEarthNormal(pol) * 255),
                        (int) Math.Abs(MatrixUtil.cosDirectionEarthNormal(pol) * 255),
                        (int) Math.Abs(MatrixUtil.cosDirectionEarthNormal(pol) * 255)), zBuffer);
            }

            Bitmap image = ImageProcessor.Image2DtoBitmap(polygonsImage);
            pictureBox1.Image = image;
        }

        private void Guru(object sender, EventArgs e)
        {
            Image2D polygonsImage = new Image2D(1000, 1000);
            ZBuffer zBuffer = new ZBuffer(1000, 1000);
            foreach (Polygon pol in polygons)
            {
                if (MatrixUtil.cosDirectionEarthNormal(pol) >= 0)
                {
                    continue;
                }

                ImageProcessor.rawTriangleWithGuruAndZBuffer(pol, polygonsImage, zBuffer);
            }

            Bitmap image = ImageProcessor.Image2DtoBitmap(polygonsImage);
            pictureBox1.Image = image;
        }
    }
}