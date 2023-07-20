using PracticeProject;

internal class Program
{
    private static void Main(string[] args)
    {
        int arraySize = 5;
        Console.WriteLine("Please, enter numbers for the first array:");
        int[] firstArray = ArrayType.CreateArrayWithConsole(arraySize);
        
        Console.WriteLine("Please, enter numbers for the second array:");
        int[] secondArray = ArrayType.CreateArrayWithConsole(arraySize);

        Console.Clear();
        Console.WriteLine("First array before sort:");
        ArrayType.PrintArray(firstArray);
        Console.WriteLine("\nSecond array before sort:");
        ArrayType.PrintArray(secondArray);

        ArrayType.SortDesc(ref firstArray);
        ArrayType.SortDesc(ref secondArray);
        Console.WriteLine("\nFirst array after sort:");
        ArrayType.PrintArray(firstArray);
        Console.WriteLine("\nSecond array after sort:");
        ArrayType.PrintArray(secondArray);

        if (ArrayType.Equal(firstArray, secondArray))
        {
            Console.WriteLine("\n\nThe given arrays are equal");
        }
        else
        {
            Console.WriteLine("\n\nThe given arrays are not equal");
        }
    }
}