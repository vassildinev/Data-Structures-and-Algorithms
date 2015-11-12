namespace TradeCompany
{
    using System;

    public class Article : IComparable<Article>
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Vendor { get; set; }

        public string Barcode { get; set; }

        public int CompareTo(Article other)
        {
            return other.Price.CompareTo(this.Price);
        }
    }
}