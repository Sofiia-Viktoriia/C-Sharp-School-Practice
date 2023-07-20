using System.Text;
using System.Text.RegularExpressions;

namespace PracticeProject.Tasks
{
    internal class UserDataBuilder
    {
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
            } while (!Regex.IsMatch(result ?? string.Empty, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase));

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
            Console.Write("Enter your password:\n****");
            Console.CursorLeft = 0;
            StringBuilder result = new("****");
            while (!int.TryParse(result.ToString(), out _password))
            {
                char currCharacter = Console.ReadKey(true).KeyChar;
                if (char.IsDigit(currCharacter))
                {
                    result[Console.CursorLeft] = currCharacter;
                    Console.Write(currCharacter);
                }
                if (currCharacter == (char)ConsoleKey.Backspace)
                {
                    Console.Write(currCharacter);
                    Console.Write('*');
                    Console.CursorLeft--;
                }
            }
            return this;
        }

        public UserData Build()
        {
            return new UserData(_name, _email, _age, _password);
        }
    }
}
