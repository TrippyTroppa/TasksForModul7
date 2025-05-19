using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksForModul7
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        public class Food
        { }
        public class Fruit : Food
        { }

        public class Vegetable : Food
        { }

        public class Apple : Fruit
        { }
        public class Pear : Fruit
        { }
        public class Banana : Fruit
        { }
        public class Potato : Vegetable
        { }
        public class Carrot : Vegetable
        { }
    }
}
