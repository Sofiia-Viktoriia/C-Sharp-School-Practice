using PracticeProject;

internal class Program
{
    private static void Main(string[] args)
    {
        Shape shape = new Shape(12, 20);
        shape.GetArea();

        Rectangle rectangle = new Rectangle(23, 44);
        rectangle.GetArea();

        object objectShape = new Shape(32, 667);
        object objectRectangle = new Rectangle(43, 11);

        Shape? shape1 = objectShape as Shape;
        shape1?.GetArea();

        if (objectRectangle is Rectangle rectangleFromObject)
        {
            rectangleFromObject.GetArea();
        }
        else
        {
            Console.WriteLine("Error while converting");
        }
    }
}