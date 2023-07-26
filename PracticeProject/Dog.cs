using PracticeProject.Interfaces;

namespace PracticeProject
{
    internal class Dog : Animal, IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("Crunch");
        }

        public void Run()
        {
            Console.WriteLine("Sprint");
        }

        public override void Sound()
        {
            Console.WriteLine("Woof");
        }
    }
}
