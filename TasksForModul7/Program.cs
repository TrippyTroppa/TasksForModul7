using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TasksForModul7
{
    class BaseClass
    {
        public virtual int Counter
        {
            get;
            set;
        }
    }

    class DerivedClass : BaseClass
    {
        private int counter;
        public override int Counter 
        { 
         get 
            {  
                return Counter;
            }
            
         set
            {
              if (value > 0)
                    Counter = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            

        }

    }
}
