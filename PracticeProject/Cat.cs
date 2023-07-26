using PracticeProject.Interfaces;

namespace PracticeProject
{
    internal class Cat : Animal, IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("Chew");
        }

        public void Run()
        {
            Console.WriteLine("Elegant sprint");
        }

        public override void Sound()
        {
            Console.WriteLine("Meow");
        }
    }
}
