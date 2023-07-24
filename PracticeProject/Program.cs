using PracticeProject;

internal class Program
{
    private static void Main(string[] args)
    {
        Messenger messenger = new Messenger("Message 1", 1);
        (string message, int number) = messenger;
        Console.WriteLine($"Message: {message}\nMessage number: {number}\nState: {Messenger.State}");
    }
}