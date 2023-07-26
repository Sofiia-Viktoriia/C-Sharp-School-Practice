namespace PracticeProject
{
    static class TopWorker
    {
        public static double CalculateSalaryWithBonus(this Worker worker)
        {
            return worker.Rate * worker.TotalHour * 2;
        }
    }
}
