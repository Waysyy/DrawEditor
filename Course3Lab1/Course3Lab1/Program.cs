using System;
using System.Diagnostics;
using System.Reflection;

namespace Course3Lab1
{
    class Program
    {
        private double[,] matrix;

        static void SearchMin(double[,] matrix)
        {
            Program p = new Program();
            double MIN = 1000;
            double tmp = 1;
            double min = 0;
            double Column = 0;
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j <= 3; ++j)
                {
                    if (j > 2)
                    {
                        min = tmp;
                        tmp = 1;

                        if (min < MIN)
                        {
                            MIN = min;
                            Column = j+1;
                        }
                    }
                    if(j <= 2)
                    { tmp *= matrix[j, i]; }
                    
                    
                    
                }
            }
            Console.WriteLine("Минимальное произведение: "+ Convert.ToString(MIN) + "\n Столбец № " + Convert.ToString(Column));
        }

        static void Input()
        {
            try
            {
                Console.WriteLine("Введите элементы матрицы");
                Program p = new Program();
                p.matrix = new double[3, 5];

                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {
                        Console.WriteLine("Элемент: " + i + j);
                        p.matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 5; j++)
                        Console.Write(String.Format("{0,3}", p.matrix[i, j]));
                    Console.WriteLine();
                }
                SearchMin(p.matrix);
            }
            catch
            {
                Console.WriteLine("Ошибочка вышла, давайте сначала");
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);

            }
        }

        static void RandomInput()
        {
            Random rand = new Random();
            try
            {
                
                Program p = new Program();
                p.matrix = new double[3, 5];

                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {
                       
                        p.matrix[i, j] = rand.Next(-10, 10);
                    }
                }
                Console.WriteLine("Матрица: \n");
                for (int i = 0; i < 3; i++)
                {
                    
                    for (int j = 0; j < 5; j++)
                        
                    Console.Write(String.Format("{0,3}", p.matrix[i, j]));
                    Console.WriteLine();
                }
                SearchMin(p.matrix);
            }
            catch
            {
                Console.WriteLine("Ошибочка вышла, давайте сначала\n");
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);

            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Матрица 3х5");
                Console.WriteLine("Выберите способ заполнения:\n 1 - ручной ввод \n 2 - рандом\n");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Input();
                    
                }
                else if (choice == 2)
                {
                    RandomInput();
                    
                }
                else
                {
                    Console.WriteLine("Вы ввели что-то не то, попробуйте еще раз \n");
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                }

            }
            catch
            {
                Console.WriteLine("Ошибочка вышла, давайте сначала \n");
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);

            }
        }
        
    }

}
