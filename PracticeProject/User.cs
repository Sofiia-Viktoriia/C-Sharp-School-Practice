using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject
{
    internal class User
    {
        public string _name { get; private set; }
        public int _id { get; private set; }
        public int _age { get; private set; }

        public User(string name, int id, int age)
        {
            _name = name;
            _id = id;
            _age = age;
        }

        public static void ChangeAge(User user, int age)
        {
            user._age = age;
        }

        public void PrintInformation()
        {
            Console.WriteLine($"Name: {_name}\nId: {_id}\nAge: {_age}");
        }
    }
}
