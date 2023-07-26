namespace PracticeProject
{
    internal class Car
    {
        public int Quantity { get; set; }
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
