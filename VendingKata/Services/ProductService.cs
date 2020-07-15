using System;
using VendingKata.Domain;

namespace VendingKata.Services
{
    public class ProductService
    {
        public ProductService()
        {
        }

        public int Cola { get; private set; }
        public int Candy { get; private set; }
        public int Chips { get; private set; }

        public void Insert(Product product, int number)
        {
           switch (product)
            {
                case Product.Cola:
                    Cola += number;
                    break;
                case Product.Candy:
                    Candy += number;
                    break;
                case Product.Chips:
                    Chips += number;
                    break;
            }
        }

        public void Vend(Product product)
        {
            switch (product)
            {
                case Product.Cola:
                    Cola --;
                    break;
                case Product.Candy:
                    Candy--;
                    break;
                case Product.Chips:
                    Chips--;
                    break;
            }
        }

        public int Stock(Product product)
        {
            switch (product)
            {
                case Product.Cola:
                    return Cola;
                case Product.Candy:
                    return Candy;
                case Product.Chips:
                    return Chips;
                default:
                    return 0;
            }
        }
    }
}
