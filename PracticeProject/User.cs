namespace PracticeProject
{
    internal class User
    {
        public readonly string Name;
        public readonly int Id;
        public int Age { get; private set; }

        public User(string name, int id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public static void ChangeAge(User user, int age)
        {
            user.Age = age;
        }

        public void PrintInformation()
        {
            Console.WriteLine($"Name: {Name}\nId: {Id}\nAge: {Age}");
        }
    }
}
