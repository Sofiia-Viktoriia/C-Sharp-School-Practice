namespace PracticeProject
{
    internal class User
    {
        private int _userId;
        private double _balance;

        public int UserId { 
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }
        public double Balance {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }
    }
}
