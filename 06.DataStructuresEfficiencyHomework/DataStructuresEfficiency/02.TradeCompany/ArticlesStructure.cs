namespace TradeCompany
{
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class ArticlesStructure
    {
        private readonly OrderedBag<Article> articles;

        public ArticlesStructure()
        {
            this.articles = new OrderedBag<Article>();
        }

        public void Add(Article article)
        {
            this.articles.Add(article);
        }

        public void Remove(string barcode)
        {
            this.articles.RemoveAll(a => a.Barcode == barcode);
        }

        public IEnumerable<Article> GetByPriceInRange(decimal from, decimal to)
        {
            return this.articles.FindAll(x => x.Price >= from && x.Price <= to);
        }
    }
}
