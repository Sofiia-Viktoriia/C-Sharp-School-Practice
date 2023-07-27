namespace PracticeProject
{
    internal class Employee
    {
        private string _name;
        private double _salary;
        protected double _bonus;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
            }
        }

        public Employee(string name, double salary)
        {
            _name = name;
            _salary = salary;
        }

        public virtual void SetBonus(double bonus)
        {
            _bonus = bonus;
        }

        public double ToPay()
        {
            return _salary + _bonus;
        }
    }
}
