using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LR5
{
    //Класс матрицы
    public class Matrix
    {
        public double[,] data;

        private int m;
        public int M { get => this.m; }

        private int n;
        public int N { get => this.m; }

        public int m_temp;
        public int n_temp;

        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.data = new double[m, n];
        }

        //Печать матрицы
        public void PrintMatrix()
        {
            for (int i = 0; i < this.m; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    Console.Write(Math.Round(this.data[i, j], 2) + " ");
                }
                Console.WriteLine();
            }
        }

        public void RandomMatrix(int left, int right)
        {
            Random random = new Random();

            for (int i = 0; i < this.m; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    this.data[i, j] = random.Next(left, right);
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine("Input the size of an array");
            int leni = Convert.ToInt32(Console.ReadLine());
            int lenj = Convert.ToInt32(Console.ReadLine());

            Matrix matrix = new Matrix(leni, lenj);
            matrix.RandomMatrix(0, 10);
            matrix.PrintMatrix();

            int count = 0;

            Thread[] threads = new Thread[leni * lenj];

            for (int i = 0; i < leni; i++)
            {
                for (int j = 0; j < lenj; j++)
                {                    
                    matrix.m_temp = i;
                    matrix.n_temp = j;

                    threads[count] = new Thread(UpdateMatrix);
                    threads[count].Start(matrix);
                    count++;

                    Thread.Sleep(10);
                }
            }

            matrix.PrintMatrix();

            Console.ReadKey();
        }

        public static void UpdateMatrix(object obj)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Matrix matrix = (Matrix)obj;

            double temp = Math.Sin(matrix.data[matrix.m_temp, matrix.n_temp]);

            Console.WriteLine("Current thread: {0}, result: {1} -> {2}", threadId, matrix.data[matrix.m_temp, matrix.n_temp], Math.Round(temp, 2));

            matrix.data[matrix.m_temp, matrix.n_temp] = temp;
        }
    }
}