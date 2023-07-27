namespace PracticeProject
{
    internal class Car
    {
        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value > 0 ? value : 0;
            }
        }
        public int Warranty { get; protected set; }

        public virtual void GetQuantity()
        {
            Console.WriteLine($"The amount of cars equals {Quantity}");
        }

        public virtual void GetFullInfo()
        {
            GetQuantity();
            Console.WriteLine($"The warranty period equals {Warranty} years");
        }

        public void SetWarranty(int warranty)
        {
            Warranty = warranty > 0 ? warranty : 0;
        }
    }
}
