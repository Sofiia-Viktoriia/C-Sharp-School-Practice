using System.Text;
using System.Text.RegularExpressions;

namespace PracticeProject.Tasks
{
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
            Console.WriteLine("Enter your password:\n****");
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            StringBuilder result = new("****");
            ConsoleKeyInfo currCharacter;
            for (int i = 0; !int.TryParse(result.ToString(), out _password);)
            {
                currCharacter = Console.ReadKey(true);
                if (char.IsDigit(currCharacter.KeyChar))
                {
                    result[i] = currCharacter.KeyChar;
                    Console.CursorLeft = 0;
                    Console.Write(result.ToString());
                    Console.CursorLeft = ++i;
                } else if (currCharacter.Key == ConsoleKey.Backspace && result[0] != '*')
                {
                    result[--i] = '*';
                    Console.CursorLeft = 0;
                    Console.Write(result.ToString());
                    Console.CursorLeft = i;
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
