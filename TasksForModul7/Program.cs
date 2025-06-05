using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TasksForModul7
{

    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 58;
            int num2 = 3;

            Helper.Swap(ref num1, ref num2);
            Console.WriteLine(num1);
            Console.WriteLine(num2);
        }
       class Helper
        {
         public static void Swap (ref int a, ref int b)
            {
                int c = a;
                a = b;
                b = c;
            }
        }
        
    }
}
