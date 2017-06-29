using System;

namespace Shopping_Center
{
    internal class Product : IComparable<Product>
    {
        public string Name { get; }

        public decimal Price { get; }

        public string Producer { get; }

        public Product(string name, decimal price, string producer)
        {
            Name = name;
            Price = price;
            Producer = producer;
        }

        public override string ToString()
        {
            return "{" + $"{Name};{Producer};{Price:F2}" + "}";
        }

        public int CompareTo(Product other)
        {
            if (this == other)
            {
                return 0;
            }

            var cmp = string.Compare(Name, other.Name, StringComparison.InvariantCulture);

            if (cmp == 0)
            {
                cmp = string.Compare(Producer, other.Producer, StringComparison.InvariantCulture);
            }

            if (cmp == 0)
            {
                cmp = Price.CompareTo(other.Price);
            }

            return cmp;
        }
    }
}
