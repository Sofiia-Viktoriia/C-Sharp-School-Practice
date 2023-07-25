namespace PracticeProject
{
    internal class Drink
    {
        private string _name;
        private double _price;

        public string Name
        { 
            set
            {
                _name = value;
            }
        }

        public double Price
        {
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
            }
        }

        public Drink(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public void PrintInfo()
        {
            GetInfo();
            Console.WriteLine("This is an additional line");
        }

        private void GetInfo()
        {
            Console.WriteLine($"Name: {_name}\nPrice: {_price:C}");
        }
    }
}
