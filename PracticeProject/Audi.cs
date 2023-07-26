namespace PracticeProject
{
    internal class Audi : WV
    {
        public override void GetQuantity()
        {
            Console.WriteLine($"The amount of Audi cars equals {Quantity}");
        }

        public new void GetQuantity(int additionalCars)
        {
            Quantity += additionalCars;
            Console.WriteLine($"The amount of Audi cars equals {Quantity}");
        }

        public new void GetFullInfo()
        {
            GetQuantity();
            Console.WriteLine($"The warranty period for Audi cars equals {Warranty} years");
        }

        public new void SetWarranty(int warranty)
        {
            Warranty = warranty > 5 ? warranty : 5;
        }
    }
}
