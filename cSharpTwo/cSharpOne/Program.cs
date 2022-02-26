using System;
using System.Threading;

namespace SharpTwo
{
    class Program
    {
        
        public delegate int TakesAWhileDelegate(int n, int m);
        static int TakesAWhile(int n, int m)
        {   
            Console.WriteLine("n =" + n);
            Console.WriteLine("m =" + m);
            
            Console.WriteLine("TakeaWhile start");
            Random rand = new Random();
            int[] arrayN = new int[n];
            int[] arrayM = new int[m];
            int maxN = 0;
            int maxM = 0;
            for (int i = 0; i < arrayN.Length; i++)
            {

                arrayM[i] = rand.Next(1000);
                arrayN[i] = rand.Next(1000);
                if (arrayN[i] > maxN)
                {
                    maxN = arrayN[i];
                }
                if (arrayM[i] > maxM)
                {
                    maxM = arrayM[i];
                }

                Console.Write("max1 =" + maxN + " max2 =" + maxM + "; ");
            }
            Thread.Sleep(m*n*100);
            Console.WriteLine("TakeAwhile ended");
            return 0;
        }
        static void Main(string[] args)
        {
            int n = 4;
            int m = 5;
            

            TakesAWhileDelegate d1 = TakesAWhile;
            IAsyncResult ar = d1.BeginInvoke(4, 6, null, null);
            while (!ar.IsCompleted)
            {
                
                Console.Write(" ");
                Thread.Sleep(50);
            }
            int result = d1.EndInvoke(ar);
            //Console.WriteLine("result: {0}", result);
            Console.ReadKey();
        }
    }
}
