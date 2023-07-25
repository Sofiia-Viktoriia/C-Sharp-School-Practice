namespace PracticeProject
{
    internal class Messenger
    {
        public static int State { get; set; }
        public string Message { get; set; }
        public int MessageNumber { get; set; }

        static Messenger()
        {
            State = 2;
        }

        public Messenger(string message, int messageNumber)
        {
            this.Message = message;
            this.MessageNumber = messageNumber;
        }

        public void Deconstruct(out string message, out int messageNumber)
        {
            message = Message;
            messageNumber = MessageNumber;
        }
    }
}
