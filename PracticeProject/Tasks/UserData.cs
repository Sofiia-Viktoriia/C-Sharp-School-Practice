using System.Text;
using System.Text.RegularExpressions;

namespace PracticeProject.Tasks
{
    internal class UserData
    {
        private string _name = string.Empty;
        private string _email = string.Empty;
        private int _age;
        private int _password;

        public UserData(string name, string email, int age, int password)
        {
            _name = name;
            _email = email;
            _age = age;
            _password = password;
        }

        public void PrintResult()
        {
            Console.Clear();
            Console.Write($"----------\n\tName: {_name}\n\tEmail: {_email}\n\tAge: {_age}\n\tPassword: " +
                $"{_password}\n\tLength of name: {_name.Length}\n----------\n");
        }
    }
}
