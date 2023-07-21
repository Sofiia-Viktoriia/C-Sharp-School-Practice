namespace PracticeProject
{
    internal class ArrayType
    {
        public static int[] CreateArrayWithConsole(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("The value is invalid. Please, enter the integer");
                }
            }
            return array;
        }

        public static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join('\t', array));
        }

        public static void SortDesc(int[] array)
        {
            for (int pass = 0; pass < array.Length - 1; pass++)
            {
                for (int loop = 0; loop < array.Length - 1; loop++)
                {
                    if (array[loop] < array[loop + 1])
                    {
                        int temp = array[loop + 1];
                        array[loop + 1] = array[loop];
                        array[loop] = temp;
                    }
                }
            }
        }

        public static bool Equal(int[] firstArray, int[] secondArray)
        {
            if (firstArray == null || secondArray == null)
            {
                return false;
            }

            if (firstArray.Length != secondArray.Length)
            {
                return false;
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
