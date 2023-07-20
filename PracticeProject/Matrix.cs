namespace PracticeProject
{
    internal class Matrix
    {
        private const int _matrixSize = 8;
        private int[,] _matrix = new int[_matrixSize, _matrixSize];

        public void FillMatrixRandomly()
        {
            var rand = new Random();
            for (int i = 0; i < _matrixSize; i++)
            {
                for (int j = 0; j < _matrixSize; j++)
                {
                    _matrix[i, j] = rand.Next(-50, 51);
                }
            }
        }

        public void PrintInformation()
        {
            int count = 0, max = 0;
            for (int i = 0; i < _matrixSize; i++)
            {
                for (int j = 0; j < _matrixSize; j++)
                {
                    if (_matrix[i, j] > 0 && _matrix[i, j] % 2 == 1)
                    {
                        Console.Write(_matrix[i, j] + "\t");
                        if (++count % 5 == 0)
                        {
                            Console.WriteLine();
                        }
                        max = _matrix[i, j] > max ? _matrix[i, j] : max;
                    }
                }
            }

            if (count == 0)
            {
                Console.WriteLine("\nThere are no odd positive numbers in the matrix");
            }
            else
            {
                Console.WriteLine($"\nThe amount of odd positive numbers: {count}");
                Console.WriteLine($"The biggest odd positive number: {max}");
            }

        }
    }
}
