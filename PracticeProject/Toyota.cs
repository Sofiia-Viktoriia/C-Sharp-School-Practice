namespace PracticeProject
{
    internal class Toyota : Car
    {
        public override void GetQuantity()
        {
            Console.WriteLine($"The amount of Toyota cars equals {Quantity}");
        }

        public void GetQuantity(int additionalCars)
        {
            Quantity += additionalCars;
            Console.WriteLine($"The amount of Toyota cars equals {Quantity}");
        }

        public override sealed void GetFullInfo()
        {
            GetQuantity();
            Console.WriteLine($"The warranty period for Toyota cars equals {Warranty} years");
        }

        public new void SetWarranty(int warranty)
        {
            Warranty = warranty > 2 ? warranty : 2;
        }
    }
}
