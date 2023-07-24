using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.University
{
    internal class Person
    {
        protected string name;
        protected int age;

        public void SayName()
        {
            Console.WriteLine($"My name is {name}");
        }
    }
}
