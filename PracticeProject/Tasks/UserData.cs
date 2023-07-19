using System.Text.RegularExpressions;

namespace PracticeProject.Tasks
{
    internal class UserData
    {
        private string _name = string.Empty;
        private string _email = string.Empty;
        private int _age;
        private int _password;

        public void RetrieveAndPrintTheData()
        {
            RetrieveName();
            RetrieveEmail();
            RetrieveAge();
            RetrievePassword();
            PrintResult();
        }

        private void RetrieveName()
        {
            Console.WriteLine("Enter your name:");
            _name = Console.ReadLine();
        }

        private void RetrieveEmail()
        {
            string result;
            do
            {
                Console.WriteLine("Enter valid email:");
                result = Console.ReadLine();
            } while (!Regex.IsMatch(result, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase));

            _email = result;
        }

        private void RetrieveAge()
        {
            string result;
            do
            {
                Console.WriteLine("Enter your age:");
                result = Console.ReadLine();
            } while (result.Length == 0 || Regex.IsMatch(result, @"^\D+$"));
            _age = Convert.ToInt32(result);
        }

        private void RetrievePassword()
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
        }

        private void PrintResult()
        {
            Console.Clear();
            Console.Write("----------\n\tName: {0}\n\tEmail: {1}\n\tAge: {2}\n\tPassword: {3}\n\t" +
                "Length of name: {4}\n----------\n", _name, _email, _age, _password, _name.Length);
        }
    }
}
