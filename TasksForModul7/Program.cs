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


        }
        public class A
        {
            public virtual void Display()
            {
                Console.WriteLine("A");
            }
        }
        public class B : A 
        {
            public new void Display()
            {
                Console.WriteLine("B");
            }
        }

        public class C:A
        {
            public override void Display()
            {
                Console.WriteLine("C");
            }

        }
        public class D : B
        {
            public new void Display()
            {
                Console.WriteLine("D");
            }
        }
        public class E : C
        {
            public new void Display()
            {
                Console.WriteLine("E");
            }
        }

    }
}
