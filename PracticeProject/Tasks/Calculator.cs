namespace PracticeProject.Tasks
{
    internal class Calculator
    {
        private int _currOption;
        private float _firstOperand;
        private float _secondOperand;

        public void Start()
        {
            while (_currOption != 5)
            {
                PrintMenu();
                _currOption = (int)char.GetNumericValue(Console.ReadKey().KeyChar);
                Console.Clear();
                switch (_currOption)
                {
                    case 1:
                        SetOperands();
                        Console.WriteLine($"The result of addition is: {_firstOperand + _secondOperand}");
                        break;
                    case 2:
                        SetOperands();
                        Console.WriteLine($"The result of subtraction is: {_firstOperand - _secondOperand}");
                        break;
                    case 3:
                        SetOperands();
                        Console.WriteLine($"The result of multiplication is: {_firstOperand * _secondOperand}");
                        break;
                    case 4:
                        SetOperands();
                        Console.WriteLine($"The result of division is: {_firstOperand / _secondOperand}");
                        break;

                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("\n\nPlease, choose the option:\n1 - Add\n2 - Subtract\n3 - Multiply" +
                "\n4 - Divide\n5 - Exit");
        }

        private void SetOperands()
        {
            string result;
            do
            {
                Console.WriteLine("Enter the first operand:");
                result = Console.ReadLine();
            } while (!float.TryParse(result, out _firstOperand));

            do
            {
                Console.WriteLine("Enter the second operand:");
                result = Console.ReadLine();
            } while (!float.TryParse(result, out _secondOperand) || _currOption == 4 && float.Parse(result) == 0);
        }
    }
}
