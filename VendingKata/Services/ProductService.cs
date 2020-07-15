using System;
using System.Collections.Generic;
using VendingKata.Domain;

namespace VendingKata.Services
{
    public class ProductService
    {
        private Dictionary<Product, int> Products { get; set; }

        public ProductService()
        {
            Products = new Dictionary<Product, int>();
        }

        public void Insert(Product product, int number)
        {
            if (Products.ContainsKey(product))
                Products[product] += number;
            else
                Products.Add(product, number);
        }

        public void Vend(Product product)
        {
            int stock = Stock(product);
            if (stock > 0)
            {
                Products[product] = stock - 1;
            }
        }

        public int Stock(Product product)
        {
            if (Products.ContainsKey(product))
               return Products[product];

            return 0;
        }
    }
}
