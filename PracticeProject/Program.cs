using PracticeProject;

internal class Program
{
    private static void Main(string[] args)
    {
        User user = new User("Kate", 142, 23);
        User.ChangeAge(user, 15);
        user.PrintInformation();
    }
}