using PracticeProject;

internal class Program
{
    private static void Main(string[] args)
    {
        var matrix = Matrix.GetMatrix(8, 8);
        matrix.PrintInformation();
    }
}