using PracticeProject;

internal class Program
{
    private static void Main(string[] args)
    {
        var matrix = new Matrix();
        matrix.FillMatrixRandomly();
        matrix.PrintInformation();
    }
}