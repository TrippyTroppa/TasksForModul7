using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksForModul7
{
    class BaseClass
    {
        protected string Name;

        public BaseClass(string name)
        {
            Name = name;
        }
    }

    class DerivedClass : BaseClass
    {
        public string Description;

        public int Counter;

        public DerivedClass(string name, string discription) : base(name)
        {
            Description = discription;
        }

        public DerivedClass(string name, string discription, int counter) : base(name)
        {
            Description = discription;
            Counter = counter;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           
        }

    }
}
