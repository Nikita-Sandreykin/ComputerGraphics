using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public partial class TestObj : Form
    {
        private DrawLine line;
        internal List<Point3D> pointList = new List<Point3D>();
        internal List<Polygon> polygons = new List<Polygon>();

        public TestObj()
        {
            InitializeComponent();
        }

        private void TestObj_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image2D pointsImage = new Image2D(1800, 1500);
            foreach (Point3D temp in pointList)
            {
                pointsImage.setPixel(temp.X, temp.Y, new ColorRGB(255, 0, 0));
            }

            Bitmap image = ImageProcessor.Image2DtoBitmap(pointsImage);
            pictureBox1.Image = image;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image2D polygonsImage = new Image2D(1700, 1500);
            foreach (Point3D temp in pointList)
            {
                polygonsImage.setPixel(temp.X, temp.Y, new ColorRGB(255, 0, 0));
            }
            line = ImageProcessor.line4;
            Random random = new Random();
            foreach (Polygon pol in polygons)
            {
                ImageProcessor.rawTriangle(pol, polygonsImage,
                    new ColorRGB(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
                line(pol[0].X, pol[0].Y, pol[1].X, pol[1].Y, polygonsImage, new ColorRGB(0, 0, 255));
                line(pol[0].X, pol[0].Y, pol[2].X, pol[2].Y, polygonsImage, new ColorRGB(0, 0, 255));
                line(pol[1].X, pol[1].Y, pol[2].X, pol[2].Y, polygonsImage, new ColorRGB(0, 0, 255));
            }

            Bitmap image = ImageProcessor.Image2DtoBitmap(polygonsImage);
            pictureBox1.Image = image;
        }
        
    }
}