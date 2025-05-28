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
        abstract class ComputerPart
        {
            public abstract void Work();
        }

        class Processor : ComputerPart
        {
            public override void Work()
            {

            }
        }

        class MotherBoard : ComputerPart
        {
            public override void Work()
            {

            }
        }

        class GraphicCard : ComputerPart
        {
            public override void Work()
            {

            }
        }
    }
}
