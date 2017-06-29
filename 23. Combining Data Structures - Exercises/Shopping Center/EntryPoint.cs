using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Center
{
    internal class EntryPoint
    {
        private static void Main()
        {
            var sc = new ShopingCenter();

            var commands = int.Parse(Console.ReadLine());

            while (commands-- > 0)
            {
                var cmdLine = Console.ReadLine();
                var splitIndex = cmdLine.IndexOf(" ");
                var command = cmdLine.Substring(0, splitIndex);
                var tokens = cmdLine.Substring(splitIndex + 1).Trim();

                switch (command)
                {
                    case "AddProduct":
                        {
                            sc.AddProduct(tokens);
                            break;
                        }
                    case "DeleteProducts":
                        {
                            sc.DeleteProducts(tokens);
                            break;
                        }
                    case "FindProductsByName":
                        {
                            PrintProducts(sc.FindProductsByName(tokens));
                            break;
                        }
                    case "FindProductsByProducer":
                        {
                            PrintProducts(sc.FindProductsByProducer(tokens));
                            break;
                        }
                    case "FindProductsByPriceRange":
                        {
                            PrintProducts(sc.FindProductsByPriceRange(tokens));
                            break;
                        }
                }
            }
        }

        public static void PrintProducts(List<Product> products)
        {
            var sb = new StringBuilder();

            if (products.Count == 0)
            {
                sb.AppendLine("No products found");
            }
            else
            {
                foreach (var product in products)
                {
                    sb.AppendLine(product.ToString());
                }
            }

            Console.Write(sb.ToString());
        }
    }
}
