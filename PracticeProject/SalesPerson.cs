namespace PracticeProject
{
    internal class SalesPerson : Employee
    {
        private int _percent;

        public SalesPerson(string name, double salary, int percent) : base(name, salary)
        {
            _percent = percent;
        }

        public override void SetBonus(double bonus)
        {
            base.SetBonus(bonus);
            if (_percent > 200)
            {
                _bonus *= 3;
            }
            else if (_percent > 100)
            {
                _bonus *= 2;
            }
        }
    }
}
