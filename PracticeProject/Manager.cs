namespace PracticeProject
{
    internal class Manager : Employee
    {
        private int _quantity;

        public Manager(string name, double salary, int clientAmount) : base(name, salary)
        {
            _quantity = clientAmount;
        }

        public override void SetBonus(double bonus)
        {
            base.SetBonus(bonus);
            if (_quantity > 150)
            {
                _bonus += 1000;
            }
            else if (_quantity > 100)
            {
                _bonus += 500;
            }
        }
    }
}
