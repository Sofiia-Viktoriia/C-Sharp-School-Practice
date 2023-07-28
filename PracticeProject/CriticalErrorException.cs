namespace PracticeProject
{
    internal class CriticalErrorException : Exception
    {
        public CriticalErrorException(string message) : base(message) { }
    }
}
