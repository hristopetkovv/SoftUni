using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, decimal>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Revision")
                {
                    break;
                }
                var productParts = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var shop = productParts[0];

                var product = productParts[1];
                var price = decimal.Parse(productParts[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, decimal>();

                }
                var products = shops[shop];
                products[product] = price;
                //shops[shop][product]=price;

            }
            foreach (var kvp in shops)
            {
                var shop = kvp.Key;
                var products = kvp.Value;

                Console.WriteLine($"{shop}->");
                foreach (var productkvp in products)
                {
                    Console.WriteLine($"Product: {productkvp.Key}, Price: {productkvp.Value:F1}");
                }
            }
        }
    }
}
