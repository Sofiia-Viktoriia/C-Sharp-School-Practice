using PracticeProject;

internal class Program
{
    private static void Main(string[] args)
    {
        Car car = new Car() { Quantity = 3};
        car.SetWarranty(-1);
        WV wv = new WV() { Quantity = 5 };
        wv.SetWarranty(0);
        Toyota toyota = new Toyota() { Quantity = 1 };
        toyota.SetWarranty(1);
        Audi audi = new Audi() { Quantity = 4 };
        audi.SetWarranty(4);

        car.GetQuantity();
        car.GetFullInfo();

        wv.GetQuantity();
        wv.GetQuantity(1);
        wv.GetFullInfo();

        toyota.GetQuantity();
        toyota.GetQuantity(1);
        toyota.GetFullInfo();

        audi.GetQuantity();
        audi.GetQuantity(1);
        audi.GetFullInfo();

        WV wvFromAudi = audi;
        wvFromAudi.SetWarranty(3);
        wvFromAudi.GetFullInfo();

        Car carFromToyota = toyota;
        carFromToyota.SetWarranty(0);
        carFromToyota.GetFullInfo();
    }
}