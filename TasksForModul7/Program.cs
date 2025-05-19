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
        class Employee
        {
            public string Name;
            public int Age;
            public int Salary;
        }
        class ProjectManager : Employee
        { 

         public string ProjectName;

        }

        class Developer : Employee
        {
         public string ProgrammingLanguage;
        }
    }
}
