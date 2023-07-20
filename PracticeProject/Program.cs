using PracticeProject.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        var userData = new UserDataBuilder()
            .SetName()
            .SetEmail()
            .SetAge()
            .SetPassword()
            .Build();
        userData.PrintResult();
    }
}