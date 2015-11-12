//namespace OnlineStore
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Globalization;
//    using System.Linq;
//    using Wintellect.PowerCollections;

//    public class Startup
//    {
//        private static readonly BigList<Product> allProducts = new BigList<Product>();

//        public static void Main()
//        {
//            int commandsCount = int.Parse(Console.ReadLine());
//            for (int i = 0; i < commandsCount; i++)
//            {
//                string line = Console.ReadLine().Trim();
//                int commandNameEnd = line.IndexOf(' ');
//                int commandBodyStart = commandNameEnd + 1;
//                string commandName = line.Substring(0, commandNameEnd).Trim();

//                // TODO: Check trim
//                string commandBody = line.Substring(commandBodyStart).Trim();
//                switch (commandName)
//                {
//                    case "AddProduct":
//                        {
//                            string[] commandBodyComponents = commandBody.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
//                            string productName = commandBodyComponents[0];
//                            float price = float.Parse(commandBodyComponents[1]);
//                            string producer = commandBodyComponents[2];
//                            AddProduct(productName, price, producer);
//                            break;
//                        }

//                    case "DeleteProducts":
//                        {
//                            string[] commandBodyComponents = commandBody.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
//                            string producer = string.Empty;
//                            if (commandBodyComponents.Length == 1)
//                            {
//                                producer = commandBodyComponents[0];
//                                DeleteProductsByProducer(producer);
//                                break;
//                            }

//                            string productName = commandBodyComponents[0];
//                            producer = commandBodyComponents[1];
//                            DeleteProductsByNameAndProducer(productName, producer);
//                            break;
//                        }

//                    case "FindProductsByProducer":
//                        {
//                            FindProductByProducer(commandBody);
//                            break;
//                        }

//                    case "FindProductsByName":
//                        {
//                            FindProductByName(commandBody);
//                            break;
//                        }
//                    case "FindProductsByPriceRange":
//                        {
//                            string[] commandBodyComponents = commandBody.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
//                            float from = float.Parse(commandBodyComponents[0]);
//                            float to = float.Parse(commandBodyComponents[1]);
//                            FindProductsByPrice(from, to);
//                            break;
//                        }

//                    default:
//                        break;
//                }
//            }
//        }

//        private static void DeleteProductsByProducer(string producer)
//        {
//            List<Product> products = allProducts
//                .RemoveAll(p => p.Producer == producer)
//                .ToList();

//            Console.WriteLine("{0} products deleted", products.Count);
//        }

//        private static void DeleteProductsByNameAndProducer(string name, string producer)
//        {
//            List<Product> products = allProducts
//                .RemoveAll(p => p.Producer == producer && p.Name == name)
//                .ToList();

//            Console.WriteLine("{0} products deleted", products.Count);
//        }

//        private static void FindProductsByPrice(float from, float to)
//        {
//            List<Product> products = allProducts
//                .FindAll(p => p.Price <= to && p.Price >= from)
//                .OrderBy(p => p.Name)
//                .ToList();
//            if (products.Count == 0)
//            {
//                Console.WriteLine("No products found");
//                return;
//            }

//            Console.WriteLine(string.Join("\n", products));
//        }

//        private static void FindProductByName(string name)
//        {
//            List<Product> products = allProducts
//                .FindAll(p => p.Name == name)
//                .OrderBy(p => p.Name)
//                .ToList();
//            if (products.Count == 0)
//            {
//                Console.WriteLine("No products found");
//                return;
//            }

//            Console.WriteLine(string.Join("\n", products));
//        }

//        private static void FindProductByProducer(string producer)
//        {
//            List<Product> products = allProducts
//                .FindAll(p => p.Producer == producer)
//                .OrderBy(p => p.Name)
//                .ToList();
//            if (products.Count == 0)
//            {
//                Console.WriteLine("No products found");
//                return;
//            }

//            Console.WriteLine(string.Join("\n", products));
//        }

//        private static void AddProduct(string name, float price, string producer)
//        {
//            var product = new Product
//            {
//                Name = name,
//                Price = price,
//                Producer = producer
//            };

//            allProducts.Add(product);
//            Console.WriteLine("Product added");
//        }
//    }

//    internal class Product : IComparable<Product>
//    {
//        public string Name { get; set; }

//        public float Price { get; set; }

//        public string Producer { get; set; }

//        public int CompareTo(Product other)
//        {
//            if (other.Price > this.Price)
//            {
//                return -1;
//            }
//            else if (other.Price < this.Price)
//            {
//                return 1;
//            }
//            else
//            {
//                int nameComparison = other.Name.CompareTo(this.Name);
//                if (nameComparison == 0)
//                {
//                    return other.Producer.CompareTo(this.Producer);
//                }
//                else
//                {
//                    return nameComparison;
//                }
//            }
//        }

//        public override string ToString()
//        {
//            return "{" + string.Format("{0};{1};{2}", this.Name, this.Producer, this.Price.ToString("F",
//                  CultureInfo.InvariantCulture)) + "}";
//        }
//    }
//}

namespace InternetShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Linq;

    class Product
    {
        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Producer { get; set; }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
        }
    }

    class OnlineStore
    {
        private Dictionary<string, List<Product>> productsByName;
        private Dictionary<string, List<Product>> productsProducere;
        private Dictionary<string, List<Product>> productsByNameNadProducer;
        private Dictionary<decimal, List<Product>> productsByPrice;

        public OnlineStore()
        {
            this.productsByName = new Dictionary<string, List<Product>>();
            this.productsProducere = new Dictionary<string, List<Product>>();
            this.productsByNameNadProducer = new Dictionary<string, List<Product>>();
            this.productsByPrice = new Dictionary<decimal, List<Product>>();
        }

        public string AddProduct(string productName, decimal price, string producer)
        {
            var newProduct = new Product(productName, price, producer);

            if (!this.productsByName.ContainsKey(productName))
            {
                this.productsByName.Add(productName, new List<Product>());
            }

            if (!this.productsProducere.ContainsKey(producer))
            {
                this.productsProducere.Add(producer, new List<Product>());
            }

            if (!this.productsByNameNadProducer.ContainsKey(productName + producer))
            {
                this.productsByNameNadProducer.Add(productName + producer, new List<Product>());
            }

            if (!this.productsByPrice.ContainsKey(price))
            {
                this.productsByPrice.Add(price, new List<Product>());
            }

            this.productsByName[productName].Add(newProduct);
            this.productsProducere[producer].Add(newProduct);
            this.productsByNameNadProducer[productName + producer].Add(newProduct);
            this.productsByPrice[price].Add(newProduct);

            return "Product added";
        }

        public string DeleteProducts(string productName, string producer)
        {
            var index = productName + producer;

            if (!this.productsByNameNadProducer.ContainsKey(index))
            {
                return "No products found";
            }

            var productsToDelete = this.productsByNameNadProducer[index];
            var deletedCOunt = productsToDelete.Count();

            if (deletedCOunt == 0)
            {
                return "No products found";
            }

            foreach (var pr in productsToDelete)
            {
                this.productsByName[pr.Name].Remove(pr);
                this.productsProducere[pr.Producer].Remove(pr);
                this.productsByPrice[pr.Price].Remove(pr);
            }

            this.productsByNameNadProducer.Remove(index);

            return string.Format("{0} products deleted", deletedCOunt);
        }

        public string DeleteProducts(string producer)
        {
            if (!this.productsProducere.ContainsKey(producer))
            {
                return "No products found";
            }

            var productsToDelete = this.productsProducere[producer];
            var deletedCOunt = productsToDelete.Count();

            if (deletedCOunt == 0)
            {
                return "No products found";
            }

            foreach (var pr in productsToDelete)
            {
                this.productsByName[pr.Name].Remove(pr);
                this.productsByNameNadProducer[pr.Name + pr.Producer].Remove(pr);
                this.productsByPrice[pr.Price].Remove(pr);
            }

            this.productsProducere.Remove(producer);

            return string.Format("{0} products deleted", deletedCOunt);
        }

        public string FindProductsByName(string productName)
        {
            if (!this.productsByName.ContainsKey(productName))
            {
                return "No products found";
            }

            var foundProducts = this.productsByName[productName];

            if (foundProducts.Count == 0)
            {
                return "No products found";
            }

            return GetProductsSetToString(foundProducts);
        }

        public string FindProductsByPriceRange(decimal from, decimal to)
        {
            var foundProducts = this.productsByPrice.Where(i => i.Key >= from && i.Key <= to).SelectMany(x => x.Value).ToList();

            if (foundProducts.Count() == 0)
            {
                return "No products found";
            }

            return GetProductsSetToString(foundProducts);
        }

        public string FindProductsByProducer(string producer)
        {
            if (!this.productsProducere.ContainsKey(producer))
            {
                return "No products found";
            }

            var foundProducts = this.productsProducere[producer];

            if (foundProducts.Count == 0)
            {
                return "No products found";
            }

            return GetProductsSetToString(foundProducts);
        }

        private string GetProductsSetToString(List<Product> products)
        {
            if (products == null)
            {
                return null;
            }

            var sb = new StringBuilder();
            var sortedProducts = products.OrderBy(p => p.ToString());

            foreach (var pr in sortedProducts)
            {
                sb.AppendLine(pr.ToString());
            }

            return sb.ToString().Trim();
        }
    }

    class Program
    {
        static void Main()
        {
            //Console.SetIn(File.OpenText("../../input.txt"));
            var commandsCOunt = int.Parse(Console.ReadLine());

            var output = new StringBuilder();
            var store = new OnlineStore();

            for (int i = 0; i < commandsCOunt; i++)
            {
                var command = Console.ReadLine();
                var indexfWhiteSpace = command.IndexOf(" ");
                var CommandName = command.Substring(0, indexfWhiteSpace);
                var commanParameters = command.Substring(indexfWhiteSpace + 1).Split(';');

                if (CommandName == "AddProduct")
                {
                    output.AppendLine(store.AddProduct(commanParameters[0], decimal.Parse(commanParameters[1]), commanParameters[2]));
                }
                else if (CommandName == "DeleteProducts")
                {
                    if (commanParameters.Length == 2)
                    {
                        output.AppendLine(store.DeleteProducts(commanParameters[0], commanParameters[1]));
                    }
                    else if (commanParameters.Length == 1)
                    {
                        output.AppendLine(store.DeleteProducts(commanParameters[0]));
                    }
                }
                else if (CommandName == "FindProductsByName")
                {
                    output.AppendLine(store.FindProductsByName(commanParameters[0]));
                }
                else if (CommandName == "FindProductsByPriceRange")
                {
                    output.AppendLine(store.FindProductsByPriceRange(decimal.Parse(commanParameters[0]), decimal.Parse(commanParameters[1])));
                }
                else if (CommandName == "FindProductsByProducer")
                {
                    output.AppendLine(store.FindProductsByProducer(commanParameters[0]));
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}
