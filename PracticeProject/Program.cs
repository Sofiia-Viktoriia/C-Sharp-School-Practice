using PracticeProject;

internal class Program
{
    private static void Main(string[] args)
    {
        User user = new User() { UserId = 123, Balance = 5324.67 };
        Provider<User> provider = new Provider<User>();
        provider.CheckBalance(user);
    }
}