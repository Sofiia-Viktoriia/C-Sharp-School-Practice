using System.Text;

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
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < _matrixWidth; i++)
            {
                for (int j = 0; j < _matrixHeight; j++)
                {
                    int element = _matrix[i, j];
                    if (element > 0 && element % 2 == 1)
                    {
                        result.Append(element + "\t");
                        if (++count % 5 == 0)
                        {
                            result.Append('\n');
                        }
                        max = element > max ? element : max;
                    }
                }
            }

            if (count == 0)
            {
                result.Append("\nThere are no odd positive numbers in the matrix");
                Console.WriteLine(result);
            }
            else
            {
                result.Append($"\nThe amount of odd positive numbers: {count}\nThe biggest odd positive number: {max}");
                Console.WriteLine(result);
            }

        }
    }
}
