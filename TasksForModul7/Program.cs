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
        class Obj
        {
            public int Value;
            public static Obj operator +(Obj a, Obj b)
            {
                return new Obj
                {
                    Value = a.Value + b.Value
                };
            }
            public static Obj operator -(Obj a, Obj b)
            {
                return new Obj
                {
                    Value = a.Value - b.Value
                };
            }
        }



    }
}
