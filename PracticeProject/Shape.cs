namespace PracticeProject
{
    internal class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Shape(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void GetArea()
        {
            Console.WriteLine($"The area of the shape equals {Width * Height}");
        }
    }
}
