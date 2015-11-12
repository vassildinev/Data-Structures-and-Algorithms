namespace Triples
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var dict = new MultiKeyDictionary<string, string, int>();
            dict.Add("pesho", "gosho", 26);
            Console.WriteLine(dict[primaryKey: "pesho"]);
        }
    }
}
