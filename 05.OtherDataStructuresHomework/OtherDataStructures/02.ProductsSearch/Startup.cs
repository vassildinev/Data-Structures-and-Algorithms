using System;
using System.Diagnostics;
using Wintellect.PowerCollections;

namespace ProductsSearch
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Filling bag with products...");
            var bag = new OrderedBag<Product>();
            for (int i = 0; i < 500000; i++)
            {
                string name = "Name" + i;
                decimal price = i;
                bag.Add(new Product
                {
                    Name = name,
                    Price = price
                });
            }

            Console.WriteLine("Done.");

            int minPrice = 10000;
            int maxPrice = 300000;

            var from = new Product
            {
                Name = string.Empty,
                Price = minPrice
            };

            var to = new Product
            {
                Name = string.Empty,
                Price = maxPrice
            };

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                bag.Range(from, true, to, true);
            }

            stopwatch.Stop();
            Console.WriteLine($"10 000 searches done in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
