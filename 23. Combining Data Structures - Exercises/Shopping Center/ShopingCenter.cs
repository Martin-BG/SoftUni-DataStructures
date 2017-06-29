using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Shopping_Center
{
    internal class ShopingCenter
    {
        private readonly Dictionary<string, OrderedBag<Product>> _byName;
        private readonly Dictionary<string, OrderedBag<Product>> _byProducer;
        private readonly Dictionary<string, OrderedBag<Product>> _byNameAndProducer;
        private readonly OrderedMultiDictionary<decimal, Product> _byPrice;

        public ShopingCenter()
        {
            _byName = new Dictionary<string, OrderedBag<Product>>();
            _byProducer = new Dictionary<string, OrderedBag<Product>>();
            _byNameAndProducer = new Dictionary<string, OrderedBag<Product>>();
            _byPrice = new OrderedMultiDictionary<decimal, Product>(true);
        }

        public List<Product> FindProductsByPriceRange(string tokens)
        {
            var token = tokens.Split(';').Select(decimal.Parse).ToList();
            var fromPrice = token[0];
            var toPice = token[1];

            var products = _byPrice
                .Range(fromPrice, true, toPice, true)
                .SelectMany(x => x.Value)
                .ToList();
            products.Sort();
            return products;
        }

        public List<Product> FindProductsByNameAndProducer(string nameAndProducer)
        {
            var products = Enumerable.Empty<Product>().ToList();

            if (_byNameAndProducer.ContainsKey(nameAndProducer))
            {
                products = _byNameAndProducer[nameAndProducer].ToList();
            }

            return products;
        }

        public List<Product> FindProductsByProducer(string tokens)
        {
            var producer = tokens;

            var products = Enumerable.Empty<Product>().ToList();

            if (_byProducer.ContainsKey(producer))
            {
                products = _byProducer[producer].ToList();
            }

            return products;
        }

        public List<Product> FindProductsByName(string tokens)
        {
            var name = tokens;

            var products = Enumerable.Empty<Product>().ToList();

            if (_byName.ContainsKey(name))
            {
                products = _byName[name].ToList();
            }

            return products;
        }

        public void DeleteProducts(string tokens)
        {
            var token = tokens.Split(';').ToList();

            List<Product> products;

            if (token.Count == 1) // Delete by producer
            {
                var producer = token[0];

                products = FindProductsByProducer(producer);
            }
            else // Delete by name and producer
            {
                var name = token[0];
                var producer = token[1];
                var nameAndProducer = GetNameAndProducerKey(name, producer);
                products = FindProductsByNameAndProducer(nameAndProducer);
            }

            var deletedProducts = products.Count;

            foreach (var product in products)
            {
                var nameAndProducer = GetNameAndProducerKey(product.Name, product.Producer);
                _byName[product.Name].Remove(product);
                _byProducer[product.Producer].Remove(product);
                _byNameAndProducer[nameAndProducer].Remove(product);
                _byPrice[product.Price].Remove(product);
            }

            if (deletedProducts == 0)
            {
                Console.WriteLine("No products found");
            }
            else
            {
                Console.WriteLine($"{deletedProducts} products deleted");
            }
        }

        public void AddProduct(string tokens)
        {
            var token = tokens.Split(';').ToList();
            var name = token[0];
            var price = decimal.Parse(token[1]);
            var producer = token[2];

            var product = new Product(name, price, producer);

            if (!_byName.ContainsKey(name))
            {
                _byName.Add(name, new OrderedBag<Product>());
            }
            _byName[name].Add(product);

            if (!_byProducer.ContainsKey(producer))
            {
                _byProducer.Add(producer, new OrderedBag<Product>());
            }
            _byProducer[producer].Add(product);

            var nameAndProducer = GetNameAndProducerKey(name, producer);
            if (!_byNameAndProducer.ContainsKey(nameAndProducer))
            {
                _byNameAndProducer.Add(nameAndProducer, new OrderedBag<Product>());
            }
            _byNameAndProducer[nameAndProducer].Add(product);

            _byPrice.Add(price, product);

            Console.WriteLine("Product added");
        }

        private static string GetNameAndProducerKey(string name, string producer)
        {
            return $"{name}_{producer}";
        }
    }
}
