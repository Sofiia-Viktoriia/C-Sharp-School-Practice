namespace PracticeProject.Tasks
{
    internal class Calculator
    {
        private const string _firstOperandMessage = "Please, enter the first operand:";
        private const string _secondOperandMessage = "Please, enter the second operand:";
        private const string _divideByZeroMessage = "The second operand can't be equal to zero.";

        public void Start()
        {
            char currOption = '0';
            while (currOption != '5')
            {
                PrintMenu();
                currOption = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (currOption)
                {
                    case '1':
                        AddNumbers();
                        break;
                    case '2':
                        SubrtactNumbers();
                        break;
                    case '3':
                        MultiplyNumbers();
                        break;
                    case '4':
                        DivideNumbers();
                        break;
                    case '5':
                        Console.WriteLine("The program is shutting down...");
                        break;
                    default:
                        Console.WriteLine("Please, enter an option from the list");
                        break;

                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("\n\nPlease, choose the option:\n1 - Add\n2 - Subtract\n3 - Multiply" +
                "\n4 - Divide\n5 - Exit");
        }

        private double GetOperand(string message)
        {
            string result;
            double operand;
            do
            {
                Console.WriteLine(message);
                result = Console.ReadLine();
            } while (!double.TryParse(result, out operand));

            return operand;
        }

        private void AddNumbers()
        {
            double firstOperand = GetOperand(_firstOperandMessage);
            double secondOperand = GetOperand(_secondOperandMessage);
            Console.WriteLine($"The result of addition is: {firstOperand + secondOperand}");
        }

        private void SubrtactNumbers()
        {
            double firstOperand = GetOperand(_firstOperandMessage);
            double secondOperand = GetOperand(_secondOperandMessage);
            Console.WriteLine($"The result of subtraction is: {firstOperand - secondOperand}");
        }

        private void MultiplyNumbers()
        {
            double firstOperand = GetOperand(_firstOperandMessage);
            double secondOperand = GetOperand(_secondOperandMessage);
            Console.WriteLine($"The result of multiplication is: {firstOperand * secondOperand}");
        }

        private void DivideNumbers()
        {
            double firstOperand = GetOperand(_firstOperandMessage);
            double secondOperand = GetOperand(_secondOperandMessage);
            while (secondOperand == 0)
            {
                Console.WriteLine(_divideByZeroMessage);
                secondOperand = GetOperand(_secondOperandMessage);
            }
            Console.WriteLine($"The result of division is: {firstOperand / secondOperand}");
        }
    }
}
