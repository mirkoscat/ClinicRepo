using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class StoreService : IStoreService
    {
        private readonly DataDbContext db;
        public StoreService(DataDbContext db)
        {
            this.db = db;
        }
        public bool AddToCart()
        {
            throw new NotImplementedException();
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

        public IEnumerable<Product> GetProducts()=>db.Products.ToList();

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
