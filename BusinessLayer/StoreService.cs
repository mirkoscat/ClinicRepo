using DataLayer;

using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

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

		public bool Checkout(Cart c, List<ProductCart> list, string street, byte[]? picture, string? extension)
		{
			foreach (var productcart in list)
			{
				c.ProductsInCart.Add(productcart);
			}
            //var order = new CheckOutOrder()
            //{
            //    OrderDate = DateTime.Now,
            //    StreetName = street,
            //    Picture = picture,
            //    FileExtension = extension,
            //    ProductCarts = list,
            //    Cart = c,
            //    OrderStatus = (OrderStatus)1
            //};

            c.ProductsInCart.Clear();
            //_context.CheckOutOrders.Add(order);

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
