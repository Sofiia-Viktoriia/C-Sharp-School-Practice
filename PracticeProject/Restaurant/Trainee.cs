using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Restaurant
{
    internal class Trainee : Chef
    {
        public override void MakeSteak()
        {
            Console.WriteLine("Make a burnt steak");
        }
    }
}
