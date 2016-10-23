namespace PrototypePattern.Abstracts
{
    public abstract class ProductPrototype
    {
        public ProductPrototype(decimal price)
        {
            this.Price = price;
        }

        public decimal Price { get; set; }

        public abstract ProductPrototype Clone();
    }
}
