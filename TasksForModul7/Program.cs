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
            public string Name;
            public string Description;

            public static string Parent;
            public static int DaysInWeek;
            public static int MaxValue;

            static Obj()
            {
                Parent = "System.Object";
                DaysInWeek = 7;
                MaxValue = 2000;

            }
        }

    }
}
