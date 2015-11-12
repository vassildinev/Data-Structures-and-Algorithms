namespace TradeCompany
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var structure  = new ArticlesStructure();

            Console.Write("Injecting articles");
            for (int i = 0; i < 1000000; i++)
            {
                structure.Add(new Article
                {
                    Title = "Title" + i,
                    Vendor = "Vendor" + i,
                    Barcode = Guid.NewGuid().ToString(),
                    Price = i
                });

                if (i % 100000 == 0)
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine();

            Console.Write("Searching articles...");
            int from = 10000;
            int to = 250000;
            Console.WriteLine();
            Console.WriteLine(structure.GetByPriceInRange(from, to).Count());
        }
    }
}
