using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR6
{
    public class Array
    {
        public double[] data;

        public List<int> result_data = new List<int>();

        private int m;
        public int M { get => this.m; }

        public int counter;

        public Array(int m)
        {
            this.m = m;
            this.data = new double[m];
        }

        public void PrintArray()
        {
            Console.WriteLine("Изначальный массив");
            for (int i = 0; i < this.m; i++)
            {
                Console.Write(this.data[i] + " ");
            }
            Console.WriteLine();
        }

        public void PrintResultArray()
        {
            Console.WriteLine("Результирующий массив");
            foreach (int i in this.result_data)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public void Random(int left, int right)
        {
            Random random = new Random();

            for (int i = 0; i < this.m; i++)
            {
                this.data[i] = random.Next(left, right);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива");
            double leni = Convert.ToInt32(Console.ReadLine());

            Array array = new Array(Convert.ToInt32(leni));
            array.Random(0, 10);
            array.PrintArray();

            int count = Convert.ToInt32(Math.Ceiling(leni / 5));

            Thread[] threads = new Thread[count];

            for (int i = 0; i < count; i++)
            {
                array.counter = i;

                threads[i] = new Thread(UpdateArray);
                threads[i].Start(array);

                Thread.Sleep(10);
            }

            array.PrintResultArray();

            Console.ReadKey();
        }

        public static void UpdateArray(object obj)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Array massive = (Array)obj;

            int counter = (massive.counter) * 5;

            for (int i = counter; i < counter + 5; i++)
            {
                if (massive.data[i] % 3 == 0 && massive.data[i] != 0)
                {
                    massive.result_data.Add(Convert.ToInt32(massive.data[i]));
                }
                if (i == massive.data.Length - 1) break;

            }
            Console.WriteLine("Current thread: {0}", threadId);
        }
    }
}
