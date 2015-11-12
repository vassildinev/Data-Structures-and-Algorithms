namespace ProductsSearch
{
    using System;

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return other.Price.CompareTo(this.Price);
        }

        public override string ToString()
        {
            return $"{this.Name} -> ${this.Price}";
        }
    }
}
