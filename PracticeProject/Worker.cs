namespace PracticeProject
{
    sealed class Worker
    {
        public int Rate;
        public int TotalHour;

        public Worker(int rate, int totalHour)
        {
            Rate = rate;
            TotalHour = totalHour;
        }

        public double CalculateSalary()
        {
            return Rate * TotalHour * 1.5;
        }
    }
}
