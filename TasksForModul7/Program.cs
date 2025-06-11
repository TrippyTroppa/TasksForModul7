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
    
    class Engine { }
    class CarPart { }
    class ElectricEngine : Engine { }

    class GasEngine : Engine { }

    class BAttery : CarPart { }

    class Differential : CarPart { }

    class Wheel : CarPart { }

    class Car<TEngine> where TEngine : Engine
    {
        public TEngine Engine;

        public virtual void ChangePart<TCarPart>(TCarPart newPart) where TCarPart: CarPart
        {

        }
    }

    
}