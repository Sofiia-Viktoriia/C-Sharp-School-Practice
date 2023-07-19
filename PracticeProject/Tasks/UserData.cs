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

    internal class UserDataBuilder
    {
        private static int _passwordLength = 4;
        private string _name = string.Empty;
        private string _email = string.Empty;
        private int _age;
        private int _password;

        public UserDataBuilder SetName()
        {
            string result;
            do
            {
                Console.WriteLine("Enter your name:");
                result = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(result));

            _name = result;
            return this;
        }

        public UserDataBuilder SetEmail()
        {
            string result;
            do
            {
                Console.WriteLine("Enter valid email:");
                result = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(result) || !Regex.IsMatch(result, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase));

            _email = result;
            return this;
        }

        public UserDataBuilder SetAge()
        {
            string result;
            do
            {
                Console.WriteLine("Enter your age:");
                result = Console.ReadLine();
            } while (!int.TryParse(result, out _age));
            return this;
        }

        public UserDataBuilder SetPassword()
        {
            Console.WriteLine("Enter your password:\n****");
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            StringBuilder result = new StringBuilder();
            char currCharacter;
            while (result.Length < _passwordLength)
            {
                do
                {
                    currCharacter = Console.ReadKey(true).KeyChar;
                } while (!char.IsDigit(currCharacter));
                result.Append(currCharacter);
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(result.ToString() + new string('*', _passwordLength - result.Length));
                Console.SetCursorPosition(result.Length, Console.CursorTop);
            }
            _password = Convert.ToInt32(result.ToString());
            return this;
        }

        public UserData Build()
        {
            return new UserData(_name, _email, _age, _password);
        }
    }
}
