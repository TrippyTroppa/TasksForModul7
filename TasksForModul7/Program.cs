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
        protected string Name;

        public BaseClass(string name)
        {
            Name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine("Метод класса BaseClass");
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
        public override void Display()
        {   
            base.Display();
            Console.WriteLine("Метод класса DerivedClass");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {


        }

    }
}
