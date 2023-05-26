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
        private readonly DataDbContext db;
        public StoreService(DataDbContext db)
        {
            this.db = db;
        }
        public bool AddToCart(Product p, Cart c, int qty)
        {
            var prodcartcheck = db.ProductCarts.Any(x => x.Product.Id == p.Id);

            if (!prodcartcheck)
            {
                var prodotto = new ProductCart
                {
                    Quantity = qty,
                    Cart = c,
                    Product = p
                };
                db.ProductCarts.Add(prodotto);
            }
            else
            {
                var productcart = db.ProductCarts.FirstOrDefault(x => x.Product.Id == p.Id);
                productcart.Quantity += qty;
            }

            db.SaveChanges();
            return true;
        }

        

        public bool CreateProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return true;
        }

        public bool DeleteToCart()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts() => db.Products.ToList();
	

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
