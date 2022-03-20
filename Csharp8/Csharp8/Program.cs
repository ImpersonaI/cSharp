using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR8MP
{
    class Array
    {
        private int[,,] data;

        private int x;
        public int X { get => this.x; }

        private int y;
        public int Y { get => this.y; }

        private int z;
        public int Z { get => this.z; }

        public int pos_x;
        public int pos_y;


        public Array(int x, int y, int z)
        {
            this.data = new int[x, y, z];

            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void CreateArray(int left, int right)
        {
            Random random = new Random();

            for (int a = 0; a < this.X; a++)
            {
                for (int b = 0; b < this.Y; b++)
                {
                    for (int c = 0; c < this.Z; c++)
                    {
                        this.data[a, b, c] = random.Next(left, right);
                    }
                }
            }
        }

        public void PrintArray()
        {
            for (int a = 0; a < this.X; a++)
            {
                for (int b = 0; b < this.Y; b++)
                {
                    Console.Write("(");
                    for (int c = 0; c < this.Z; c++)
                    {
                        Console.Write(this.data[a, b, c] + " ");
                    }
                    Console.Write(") ");
                }
                Console.WriteLine();
            }
        }

        public double Summary()
        {
            int sr = 0;

            for (int a = 0; a < this.X; a++)
            {
                for (int b = 0; b < this.Y; b++)
                {
                    for (int c = 0; c < this.Z; c++)
                    {
                        sr += this.data[a, b, c];
                    }
                }
            }

            sr = sr / (this.X * this.Y * this.Z);

            return sr;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Task ts = new Task(ParallelMethod);
            ts.Start();

            Console.ReadKey();
        }

        public static void ParallelMethod()
        {
            Console.WriteLine("Выполнение задачи {0}", Task.CurrentId);

            Array massive = new Array(5, 5, 5);
            massive.CreateArray(0, 50);
            massive.PrintArray();

            Console.WriteLine("Result = {0}", massive.Summary());
        }
    }
}
