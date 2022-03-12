using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR7
{    
    class Vector
    {
        private int vect_len;
        public int Vect_len { get => this.vect_len; }

        public Vector(int len)
        {
            this.vect_len = len;
        }
        
        public void MultiplyVect(Vector vector2)
        {
            ThreadPool.QueueUserWorkItem(MethodForThread, vector2);
        }

         public void MethodForThread(object obj)
        {
            Vector vector2 = (Vector)obj;
            Console.WriteLine("Поток №{0}. Получена пара векторов: {1}; {2}",
                Thread.CurrentThread.ManagedThreadId,
                this.Vect_len,
                vector2.Vect_len);

            Console.WriteLine("Поток №{0}. Вычисление результата произведения векторов: {1}; {2}",
                Thread.CurrentThread.ManagedThreadId,
                this.Vect_len,
                vector2.Vect_len);

            double res = this.Vect_len * vector2.vect_len;

            Thread.Sleep(100);

            Console.WriteLine(" //\\"+ "Поток №{0}. Результат произведения векторов: {1}; {2} равен {3}",
                Thread.CurrentThread.ManagedThreadId,
                this.Vect_len,
                vector2.Vect_len,
                res);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int MaxWorkThreads;
            int MaxIOThreads;
            ThreadPool.GetMaxThreads(out MaxWorkThreads, out MaxIOThreads);
            Console.WriteLine("Максимальное количество рабочих потоков: {0}, максимальное количество потоков ввода-вывода: {1}",
                MaxWorkThreads, MaxIOThreads);

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                Vector vector1 = new Vector(Convert.ToInt32(random.Next(0, 10)));
                Vector vector2 = new Vector(Convert.ToInt32(random.Next(0, 10)));

                vector1.MultiplyVect(vector2);
            }

            Console.ReadKey();
        }
    }
}
