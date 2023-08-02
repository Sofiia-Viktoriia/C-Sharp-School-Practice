namespace PracticeProject
{
    internal class Company
    {
        private Employee[] _employees;

        public Company(Employee[] employees)
        {
            _employees = employees;
        }

        public void GiveEverybodyBonus(double companyBonus)
        {
            foreach (Employee employee in _employees)
            {
                employee.SetBonus(companyBonus);
            }
        }

        public double TotalToPay()
        {
            return _employees.Sum(x => x.ToPay());
        }

        public void GetNameSalary()
        {
            foreach (Employee employee in _employees)
            {
                Console.WriteLine($"Employee name: {employee.Name}\nSalary with bonus: {employee.ToPay():C}");
            }
        }
    }
}
