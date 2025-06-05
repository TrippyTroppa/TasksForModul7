using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TasksForModul7;

namespace TasksForModul7
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }


    class ElectricEngine { }

    class GasEngine { }

    class BAttery { }

    class Differential { }

    class Wheel { }

    class Car<T>
    {
        public T Engine;

        public virtual void ChangePart<T2>(T2 newPart)
        {

        }
    }

    
}