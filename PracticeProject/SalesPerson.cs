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
            if (_percent > 200)
            {
                bonus *= 3;
            }
            else if (_percent > 100)
            {
                bonus *= 2;
            }
            base.SetBonus(bonus);
        }
    }
}
