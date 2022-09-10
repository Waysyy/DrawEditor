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
                try
                {
                    if (size <= 0) { size = 1; }
                    points = new System.Drawing.Point[size];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public void SetPoint(int x, int y)
            {
                try { 
                if (index >= points.Length)
                {
                    index = 0;
                }
                points[index] = new System.Drawing.Point(x, y);
                ++index;
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
            private int index2 = 0;
            public System.Drawing.Point[] coordPolynom;
            public Polynom(int size)
            {
                try
                {
                    if (size <= 0) { size = 3; }
                    pointsPolynom = new System.Drawing.Point[size];
                    coordPolynom = new System.Drawing.Point[3];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public void addCoordinatePolynom(int x, int y)
            {
                try
                {
                    if (index2 >= 6)
                    {
                        index2 = 0;
                    }
                    coordPolynom[index2] = new System.Drawing.Point(x, y);
                    ++index2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public void SetPoint(int x, int y)
            {
                try
                {
                    if (index >= pointsPolynom.Length)
                    {
                        index = 0;
                    }
                    pointsPolynom[index] = new System.Drawing.Point(x, y);
                    ++index;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            public void ResetPoint()
            {
                index = 0;
                index2 = 0;
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
                try
                {
                    if (size <= 0) { size = 2; }
                    pointsLine = new System.Drawing.Point[size];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public void SetPoint(int x, int y)
            {
                try
                {
                    if (index >= pointsLine.Length)
                    {
                        index = 0;
                    }
                    pointsLine[index] = new System.Drawing.Point(x, y);

                    ++index;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        

        private void SizeMap()
        {
            try
            {
                Rectangle rectangle = Screen.PrimaryScreen.Bounds;
                map = new Bitmap(rectangle.Width, rectangle.Height);
                g = Graphics.FromImage(map);
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                MouseCheck = false;
                point.ResetPoint();
                line.ResetPoint();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
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
                StringBuilder sb = new StringBuilder();
                double ratio = 1.0 * pictureBox1.Width;
                int x = (int)(e.X / ratio);
                int y = (int)(e.Y / ratio);

                sb.Append("X ");
                sb.Append(e.X);
                sb.Append("  Y ");
                sb.Append(e.Y);
               
                coordinate.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                
                this.pictureBox1.MouseUp += new MouseEventHandler(this.pictureBox1_MouseUp);
                this.pictureBox1.MouseDown += new MouseEventHandler(this.pictureBox1_MouseDown);
                this.pictureBox1.MouseMove += new MouseEventHandler(this.pictureBox1_MouseMove);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    Brush.Color = colorDialog1.Color;
                    pen.Color = colorDialog1.Color;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (radioButton4.Checked)
                {
                    polynom.ResetPoint();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = null;
                Color col = Color.White;
                g.Clear(col);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool buttonDraw = false;
        public bool buttonAdd = false;
        List<int> ArrCoordinates = new List<int>();
        void DrawCoordinate()
        {
            try
            {
                if (buttonAdd == true)
                {
                    buttonAdd = false;
                    if (textBox1.Text != "" && textBox4.Text != "" && ArrCoordinates.Count != 6)
                    {
                        ArrCoordinates.Add(Convert.ToInt32(textBox1.Text));
                        ArrCoordinates.Add(Convert.ToInt32(textBox4.Text));
                        polynom.addCoordinatePolynom(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox4.Text));
                        textBox1.Text = "";
                        textBox4.Text = "";

                    }
                }
                if (buttonDraw == true)
                {
                    buttonDraw = false;
                    if (ArrCoordinates.Count == 4) //line
                    {
                        SolidBrush Brush = new SolidBrush(Color.Black);

                        g.DrawLine(pen, ArrCoordinates[0], ArrCoordinates[1], ArrCoordinates[2], ArrCoordinates[3]);
                        pictureBox1.Image = map;
                    }
                    if (ArrCoordinates.Count == 2) //dot
                    {
                        SolidBrush Brush = new SolidBrush(Color.Black);
                        g.FillEllipse(Brush, ArrCoordinates[0], ArrCoordinates[1], 20, 20);
                        pictureBox1.Image = map;
                    }
                    if (ArrCoordinates.Count == 6) //polynom
                    {
                        SolidBrush Brush = new SolidBrush(Color.Black);
                        g.DrawPolygon(pen, polynom.coordPolynom);
                        pictureBox1.Image = map;
                    }
                    ArrCoordinates.Clear();
                    line.ResetPoint();
                    polynom.ResetPoint();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e) //Add Coord
        {
            try
            {
                buttonAdd = true;
                DrawCoordinate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e) //Draw
        {
            try
            {
                buttonDraw = true;
                DrawCoordinate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
