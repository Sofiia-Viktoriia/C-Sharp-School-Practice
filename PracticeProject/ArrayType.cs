using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject
{
    internal class ArrayType
    {
        public static int[] CreateArrayWithConsole(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                string result;
                do
                {
                    result = Console.ReadLine();
                } while (!int.TryParse(result, out array[i]));
            }
            return array;
        }

        public static void PrintArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write(item + "\t");
            }
        }

        public static void SortDesc(ref int[] array)
        {
            for (int pass = 0; pass <= array.Length - 2; pass++)
            {
                for (int loop = 0; loop <= array.Length - 2; loop++)
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
                return false;

            if (firstArray.Length != secondArray.Length)
                return false;

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i]) return false;
            }
            return true;
        }
    }
}
