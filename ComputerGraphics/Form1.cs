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
    delegate void drawline(int x0, int y0, int x1, int y1, Image2D image, ColorRGB color);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        drawline line;
        private void button1_Click(object sender, EventArgs e)
        {
            int height = Convert.ToInt32(textBox1.Text);
            int widht = Convert.ToInt32(textBox2.Text);
            Image2D blackImage = new Image2D(widht, height);
            int[,] black = new int[widht, height];
            for(int i = 0; i < widht; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    black[i, j] = 0;
                }
            }    
            for(int i = 0; i < widht; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    blackImage.setPixel(i, j, new ColorRGB(black[i, j], black[i, j], black[i, j]));
                }
            }
            Bitmap resultBlackImage = ImageProcessor.Image2DtoBitmap(blackImage);
            pictureBox1.Image = resultBlackImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int height = Convert.ToInt32(textBox1.Text);
            int widht = Convert.ToInt32(textBox2.Text);
            Image2D whiteImage = new Image2D(widht, height);
            int[,] white = new int[widht, 255];
            for (int i = 0; i < widht; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    white[i, j] = 255;
                }
            }
            for (int i = 0; i < widht; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    whiteImage.setPixel(i, j, new ColorRGB(white[i, j], white[i, j], white[i, j]));
                }
            }
            Bitmap resultBlackImage = ImageProcessor.Image2DtoBitmap(whiteImage);
            pictureBox1.Image = resultBlackImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int height = Convert.ToInt32(textBox1.Text);
            int widht = Convert.ToInt32(textBox2.Text);
            Image2D redImage = new Image2D(widht, height);
            for (int i = 0; i < widht; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    redImage.setPixel(i, j, new ColorRGB(255, 0, 0));
                }
            }
            Bitmap resultBlackImage = ImageProcessor.Image2DtoBitmap(redImage);
            pictureBox1.Image = resultBlackImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int height = Convert.ToInt32(textBox1.Text);
            int widht = Convert.ToInt32(textBox2.Text);
            Image2D gradientImage = new Image2D(widht, height);
            for (int i = 0; i < widht; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    gradientImage.setPixel(i, j, new ColorRGB((i + j)%256, (i + j) % 256, (i + j) % 256));
                }
            }
            Bitmap resultBlackImage = ImageProcessor.Image2DtoBitmap(gradientImage);
            pictureBox1.Image = resultBlackImage;
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            Image2D imageLines = new Image2D(200, 200);
            int type = Convert.ToInt32(textBox3.Text);
            switch(type)
            {
                case 1:
                    line = ImageProcessor.line1;
                    break;
                case 2:
                    line = ImageProcessor.line2;
                    break;
                case 3:
                    line = ImageProcessor.line3;
                    break;
                case 4:
                    line = ImageProcessor.line4;
                    break;
            }                
            for(int i = 0; i < 13; i++)
            {
                double alpha = 2 * i * Math.PI / 13;
                line(100, 100, Convert.ToInt32(100 + 95 * Math.Cos(alpha)), Convert.ToInt32(100 + 95 * Math.Sin(alpha)), imageLines, new ColorRGB(255, 0, 0));
            }
            Bitmap resultImageLines = ImageProcessor.Image2DtoBitmap(imageLines);
            pictureBox1.Image = resultImageLines;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            TestObj testObj = new TestObj();
            List<string> file = new List<string>();
            using (StreamReader sr = new StreamReader(@"Test.obj", System.Text.Encoding.Default))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    file.Add(str);
                }
            }
            Regex floatNumber = new Regex(@"(?:-)?0[.]\d*");
            Regex intNumber = new Regex(@"\d+");
            int i = 1;
            foreach(string temp in file)
            {
                if(temp[0] == 'v' && temp[1] == ' ')
                {
                    MatchCollection matchCollection = floatNumber.Matches(temp);
                    double x = Convert.ToDouble(matchCollection[0].Value.Replace('.',','));
                    double y = Convert.ToDouble(matchCollection[1].Value.Replace('.', ','));
                    double z = Convert.ToDouble(matchCollection[2].Value.Replace('.', ','));
                    Point3D point = new Point3D(x, y, z, 3500, 500, i);
                    testObj.pointList.Add(point);
                    i++;
                }
            }
            foreach(string temp in file)
            {
                if(temp[0] == 'f')
                {
                    MatchCollection matchCollection = intNumber.Matches(temp);
                    int p1 = Convert.ToInt32(matchCollection[0].Value);
                    int p2 = Convert.ToInt32(matchCollection[3].Value);
                    int p3 = Convert.ToInt32(matchCollection[6].Value);
                    Polygon polygon = new Polygon();
                    int j = 0;
                    foreach (Point3D p in testObj.pointList)
                    {
                        if (p.I == p1 || p.I == p2 || p.I == p3)
                        {
                            polygon[j] = p;
                            j++;
                        }
                    }
                    testObj.polygons.Add(polygon);
                }
            }
            
            testObj.Show();
        }
    }
}
