namespace PracticeProject
{
    internal class WV : Car
    {
        public override void GetQuantity()
        {
            Console.WriteLine($"The amount of WV cars equals {Quantity}");
        }

        public void GetQuantity(int additionalCars)
        {
            Quantity += additionalCars;
            Console.WriteLine($"The amount of WV cars equals {Quantity}");
        }

        public override sealed void GetFullInfo()
        {
            GetQuantity();
            Console.WriteLine($"The warranty period for WV cars equals {Warranty} years");
        }

        public new void SetWarranty(int warranty)
        {
            Warranty = warranty > 1 ? warranty : 1;
        }
    }
}
