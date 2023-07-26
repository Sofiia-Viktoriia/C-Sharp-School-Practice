using PracticeProject;

internal class Program
{
    private static void Main(string[] args)
    {
        var worker = new Worker(40, 220);
        double salary;
        if (worker.Rate < 50 && worker.TotalHour > 200)
        {
            salary = worker.CalculateSalaryWithBonus();
        }
        else
        {
            salary = worker.CalculateSalary();
        }
        Console.WriteLine($"The workers salary equals {salary:C}");
    }
}