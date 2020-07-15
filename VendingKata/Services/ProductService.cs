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
            }
        }

        public void Vend(Product product)
        {
            switch (product)
            {
                case Product.Cola:
                    Cola --;
                    break;
            }
        }
    }
}
