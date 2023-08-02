using PracticeProject;

internal class Program
{
    private static void Main(string[] args)
    {
        Employee[] employees = { new SalesPerson("Potapenko", 2000, 210), new Employee("Vodiy", 500), new Manager("Markov", 3000, 110)};
        Company company = new Company(employees);
        Console.WriteLine($"Overall spendings: {company.TotalToPay():C}");
        company.GiveEverybodyBonus(300);
        Console.WriteLine($"Overall spendings: {company.TotalToPay():C}");
        company.GetNameSalary();
    }
}