using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Restaurant
{
    internal class Chef
    {
        private void MakeSpecialDish()
        {
            Console.WriteLine("Make a specialty soup");
        }

        public virtual void MakeSteak()
        {
            Console.WriteLine("Make a well-cooked steak");
        }
    }
}
