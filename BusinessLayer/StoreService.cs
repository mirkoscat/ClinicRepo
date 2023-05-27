using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using DataLayer;
using Microsoft.Identity.Client;

namespace BusinessLayer
{
    public class StoreService : IStoreService
    {
        private readonly DataDbContext _context;
        public StoreService(DataDbContext db)
        {
            _context = db;
        }
        public bool AddToCart(Product p, Cart c, int qty)
        {
            var prodcartcheck = _context.ProductCarts.Any(x => x.Product.Id == p.Id);

            if (!prodcartcheck)
            {
                var prodotto = new ProductCart
                {
                    Quantity = qty,
                    Cart = c,
                    Product = p
                };
                _context.ProductCarts.Add(prodotto);
            }
            else
            {
                var productcart = _context.ProductCarts.FirstOrDefault(x => x.Product.Id == p.Id);
                productcart.Quantity += qty;
            }

            _context.SaveChanges();
            return true;
        }

		public bool Checkout(Cart c, List<ProductCart> list, string street)
		{//not complete
            c.StreetName = street;
			foreach (var productcart in list)
            {
                c.ProductsInCart.Add(productcart);
            }
            _context.SaveChanges();
            return true;
		}


		public bool CreateProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteToCart()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts() => _context.Products.ToList();
	

		public IEnumerable<Product> GetProductsByDate(string date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByFiscalCode(string fc)
        {
            throw new NotImplementedException();
        }
    }
}
