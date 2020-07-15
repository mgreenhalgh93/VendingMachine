using System;
using System.Collections.Generic;
using VendingKata.Domain;

namespace VendingKata.Services
{
    public class ProductService
    {
        private Dictionary<Product, int> _products { get; set; }

        public ProductService()
        {
            _products = new Dictionary<Product, int>();
        }

        public void Insert(Product product, int number)
        {
            if (_products.ContainsKey(product))
                _products[product] += number;
            else
                _products.Add(product, number);
        }

        public void Vend(Product product)
        {
            int stock = Stock(product);
            if (stock > 0)
            {
                _products[product] = stock - 1;
            }
        }

        public int Stock(Product product)
        {
            if (_products.ContainsKey(product))
               return _products[product];

            return 0;
        }
    }
}
