using PracticeProject;

internal class Program
{
    private static void Main(string[] args)
    {
        Shape shape = new Shape(12, 20);
        shape.GetArea();

        Rectangle rectangle = new Rectangle(23, 44);
        rectangle.GetArea();

        object obj1 = new Shape(32, 667);
        object obj2 = new Rectangle(43, 11);

        Shape shape1 = obj1 as Shape;
        shape1?.GetArea();

        if (obj2 is Rectangle r)
        {
            r.GetArea();
        }
        else
        {
            Console.WriteLine("Error while converting");
        }
    }
}