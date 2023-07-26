namespace PracticeProject
{
    internal class Rectangle : Shape
    {
        public Rectangle(int width, int height) : base(width, height)
        {
            Console.WriteLine("Rectangle is created");
        }

        public new void GetArea()
        {
            Console.WriteLine($"The area of the rectangle equals {Width * Height}");
        }
    }
}
