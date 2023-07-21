namespace PracticeProject
{
    internal class Matrix
    {
        private readonly int _matrixWidth;
        private readonly int _matrixHeight;
        private int[,] _matrix;

        private Matrix(int width, int height)
        {
            _matrixWidth = width;
            _matrixHeight = height;
            _matrix = new int[width, height];
        }

        public static Matrix GetMatrix(int width, int height)
        {
            var matrix = new Matrix(width, height);
            var rand = new Random();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    matrix._matrix[i, j] = rand.Next(-50, 51);
                }
            }
            return matrix;
        }

        public void PrintInformation()
        {
            int count = 0;
            int max = 0;
            for (int i = 0; i < _matrixWidth; i++)
            {
                for (int j = 0; j < _matrixHeight; j++)
                {
                    int element = _matrix[i, j];
                    if (element > 0 && element % 2 == 1)
                    {
                        Console.Write(element + "\t");
                        if (++count % 5 == 0)
                        {
                            Console.WriteLine();
                        }
                        max = element > max ? element : max;
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
