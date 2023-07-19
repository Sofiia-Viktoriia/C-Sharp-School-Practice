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
            } while (string.IsNullOrWhiteSpace(result) || !int.TryParse(result, out _age));
            return this;
        }

        public UserDataBuilder SetPassword()
        {
            Console.WriteLine("Enter your password:\n****");
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            string result = "";
            ConsoleKeyInfo currCharacter;
            for (int i = 0; i < 4; i++)
            {
                currCharacter = Console.ReadKey();
                while (!char.IsDigit(currCharacter.KeyChar))
                {
                    if (currCharacter.Key == ConsoleKey.Backspace)
                    {
                        Console.Write('*');
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        if (result.Length != 0)
                        {
                            result = result.Substring(0, result.Length - 1);
                            i--;
                        }
                        currCharacter = Console.ReadKey();
                    }
                    else if (currCharacter.Key == ConsoleKey.Enter)
                    {
                        Console.SetCursorPosition(result.Length, Console.CursorTop);
                        currCharacter = Console.ReadKey();
                    }
                    else
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write('*');
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        currCharacter = Console.ReadKey();
                    }

                }
                result += currCharacter.KeyChar;
            }
            _password = Convert.ToInt32(result);
            return this;
        }

        public UserData Build()
        {
            return new UserData(_name, _email, _age, _password);
        }
    }
}
