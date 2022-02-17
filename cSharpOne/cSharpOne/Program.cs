using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpOne
{
    class Program
    {
        public static void Main(string[] args)
        {
            Func<Action<String>, int, int> lambda = Function;
            Action<String> action = Method;

            Console.WriteLine(lambda(action, 16));
            Console.WriteLine(lambda(action, 25));
            Console.WriteLine(lambda(action, 455));
            Console.ReadLine();
        }
        static void Method(String s)
        {            
            Console.WriteLine(s);            
        }

        static int Function(Action<String> action, int integer)
        {
            int res = integer * integer;
           
            action("The value equels " + integer) ;
            action("The result of multiplyaing is " + res.ToString());
            action("The result of addition is below");
            return (res + res);
        }




    }



}


