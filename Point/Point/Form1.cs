using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Point
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            SizeMap();

        }
        private class Point
        {

            private int index = 0;
            private System.Drawing.Point[] points;

            public Point(int size)
            {
                if (size <= 0) { size = 1; }
                points = new System.Drawing.Point[size];

            }

            public void SetPoint(int x, int y)
            {
                if (index >= points.Length)
                {
                    index = 0;
                }
                points[index] = new System.Drawing.Point(x, y);
                ++index;
            }
            public void ResetPoint()
            {
                index = 0;
            }
            public int CountPoint()
            {
                return index;
            }

            public System.Drawing.Point[] GetPoints()
            {
                return points;
            }
        }

        private class Polynom
        {
            public System.Drawing.Point[] pointsPolynom;
            private int index = 0;

            public Polynom(int size)
            {
                if (size <= 0) { size = 3; }
                pointsPolynom = new System.Drawing.Point[size];

            }

            public void SetPoint(int x, int y)
            {
                if (index >= pointsPolynom.Length)
                {
                    index = 0;
                }
                pointsPolynom[index] = new System.Drawing.Point(x, y);
                ++index;
            }
            public void ResetPoint()
            {
                index = 0;
            }
            public int CountPoint()
            {
                return index;

            }

            public System.Drawing.Point[] GetPoints()
            {
                return pointsPolynom;
            }
        }
        private class Line
        {
            public System.Drawing.Point[] pointsLine;
            public int index = 0;

            public Line(int size)
            {
                if (size <= 0) { size = 2; }
                pointsLine = new System.Drawing.Point[size];

            }

            public void SetPoint(int x, int y)
            {
                if (index >= pointsLine.Length)
                {
                    index = 0;
                }
                pointsLine[index] = new System.Drawing.Point(x, y);

                ++index;
            }
            public void ResetPoint()
            {
                index = 0;
            }
            public int CountPoint()
            {
                return index;

            }

            public System.Drawing.Point[] GetPoints()
            {
                return pointsLine;
            }
        }

        private bool MouseCheck = false;
        private Point point = new Point(2);
        private Polynom polynom = new Polynom(3);
        private Line line = new Line(2);
        public int[] xLine = new int[6];
        public int[] yLine = new int[6];
        public int resetLine = 0;


        Bitmap map = new Bitmap(100, 100);
        Graphics g;
        Pen pen = new Pen(Color.Black, 10f);
        SolidBrush Brush = new SolidBrush(Color.Black);

        private void SizeMap()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            g = Graphics.FromImage(map);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseCheck = true;
            if (radioButton2.Checked)
            {

                if (!MouseCheck)
                {
                    return;
                }
                if (MouseCheck)
                {
                    point.SetPoint(e.X, e.Y);
                }
                if (point.CountPoint() >= 1)
                {
                    g.FillEllipse(Brush, e.X - 1, e.Y - 1, 20, 20);
                    pictureBox1.Image = map;
                    point.SetPoint(e.X, e.Y);
                }
            }
            if (radioButton4.Checked)
            {
                MouseCheck = true;

                if (!MouseCheck)
                {
                    return;
                }
                if (MouseCheck)
                {
                    polynom.SetPoint(e.X, e.Y);

                }

                if (polynom.CountPoint() >= 3)
                {
                    g.DrawPolygon(pen, polynom.pointsPolynom);
                    pictureBox1.Image = map;
                    polynom.SetPoint(e.X, e.Y);

                }
            }
            if (radioButton1.Checked)
            {

                MouseCheck = true;
                if (!MouseCheck)
                {
                    return;
                }
                if (MouseCheck)
                {
                    line.SetPoint(e.X, e.Y);
                    if (resetLine < 1)
                    {
                        xLine[line.index] = e.X;
                        yLine[line.index] = e.Y;
                        ++resetLine;
                    }


                }
                if (line.CountPoint() >= 2)
                {
                    resetLine = 0;
                    g.DrawLine(pen, xLine[1], yLine[1], e.X, e.Y);
                    pictureBox1.Image = map;
                    polynom.SetPoint(e.X, e.Y);

                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseCheck = false;
            point.ResetPoint();
            //polynom.ResetPoint();
            line.ResetPoint();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (radioButton3.Checked)
            {
                if (!MouseCheck)
                {
                    return;
                }
                if (MouseCheck)
                {
                    point.SetPoint(e.X, e.Y);

                }
                if (point.CountPoint() >= 0)
                {
                    g.FillEllipse(Brush, e.X - 1, e.Y - 1, 20, 20);
                    pictureBox1.Image = map;
                    point.SetPoint(e.X, e.Y);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void GetCoordinate(object sender, MouseEventArgs args)
        {
            var location = args.Location;
            int CursorX = Cursor.Position.X;
            int CursorY = Cursor.Position.Y;

            coordinate.Text = " X: " + CursorX.ToString() + "   Y: " + CursorY.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            
                pictureBox1.MouseMove += GetCoordinate;
            
            //pictureBox1.MouseClick += GetCoordinate;
            this.pictureBox1.MouseUp += new MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.MouseDown += new MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new MouseEventHandler(this.pictureBox1_MouseMove);
           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Brush.Color = colorDialog1.Color;
                pen.Color = colorDialog1.Color;
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (radioButton4.Checked)
            {
                
                    polynom.ResetPoint();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Color col = Color.White;
            g.Clear(col);
        }
        
    }
}
