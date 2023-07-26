using PracticeProject;
using PracticeProject.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        Cat cat = new Cat();
        cat.Sound();
        cat.Eat();
        cat.Run();
        (cat as ISleepable).Sleep();

        Dog dog = new Dog();
        dog.Sound();
        dog.Eat();
        dog.Run();
        (dog as ISleepable).Sleep();
    }
}