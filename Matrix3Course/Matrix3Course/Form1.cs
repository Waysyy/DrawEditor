using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix3Course
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Add(3);
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public double[,] matrix;
        void Solution()
        {
            try
            {
                
                    string[,] matrixRead = new string[dataGridView1.RowCount, dataGridView1.ColumnCount];

                for (int i = 0; i < dataGridView1.RowCount; ++i)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; ++j)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null && Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) <= 10 && Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) >= -10)
                            matrixRead[i, j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        
                        
                    }
                }

                double[,] matrixConvert = new double[matrixRead.GetLength(0), matrixRead.GetLength(1)];

                for (int i = 0; i < matrixRead.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixRead.GetLength(1); j++)
                    {
                        double.TryParse(matrixRead[i, j], out matrixConvert[i, j]);
                    }
                }
                matrix = matrixConvert;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        void SearchMin(double[,] matrix)
        {
            try
            {
                double MIN = 1000;
                double tmp = 1;
                double min = 0;
                //int Column;
                List<int> Columns = new List<int>();
                Columns.Add(0);
                for (int i = 0; i < 5; ++i)
                {
                    for (int j = 0; j <= 3; ++j)
                    {
                        if (j > 2)
                        {
                            min = tmp;
                            tmp = 1;
                            if (min == MIN)
                            {
                                Columns.Add(i);
                            }
                            if (min < MIN)
                            {
                                MIN = min;
                                Columns[0] = i;
                            }

                        }
                        if (j <= 2)
                        { tmp *= matrix[j, i]; }

                    }
                }
                
                bool diapazon = true;
                for (int i = 0; i < dataGridView1.RowCount; ++i)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; ++j)
                    {
                       
                        if (dataGridView1.Rows[i].Cells[j].Value == null && Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) <= 10 && Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) >= -10)
                        {
                            diapazon = false;
                            
                        }
                    }
                }
                if(diapazon == false)
                    MessageBox.Show("Диапазон от -10 до 10");
                if (diapazon == true)
                {
                    label2.Text = (Convert.ToString(MIN) + "\n");
                    label3.Text = "Столбец(ы) № ";
                    for (int i = 0; i < Columns.Count; ++i)
                    {
                        label3.Text += Convert.ToString(Columns[i]) + " ";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        void RandomInput()
        {
            try
            {
                Random rand = new Random();
                try
                {

                    double[,] matrixRand = new double[3, 5];

                    for (int i = 0; i < 3; ++i)
                    {
                        for (int j = 0; j < 5; ++j)
                        {

                            matrixRand[i, j] = rand.Next(-10, 10);
                        }
                    }
                    for (int i = 0; i < dataGridView1.RowCount; ++i)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; ++j)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = matrixRand[i, j];
                        }
                    }

                }
                catch
                {
                    Console.WriteLine("Ошибочка вышла, давайте сначала\n");
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Solution();
            SearchMin(matrix);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RandomInput();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; ++i)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; ++j)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = null;
                    }
                }
                label2.Text = null;
                label3.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CausesValidationChanged(object sender, EventArgs e)
        { }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try { 
            const string disallowed = @"[^0-9-]";
            var newText = Regex.Replace(e.FormattedValue.ToString(), disallowed, string.Empty);
            if (dataGridView1.Rows[e.RowIndex].IsNewRow) return;
            if (string.CompareOrdinal(e.FormattedValue.ToString(), newText) == 0) return;
            e.Cancel = true;
            dataGridView1.Rows[e.RowIndex].ErrorText = "Некорректный символ!";
                }
            catch
            {
                Console.WriteLine("Ошибочка вышла, давайте сначала\n");
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);

            }
        }
    }
}
