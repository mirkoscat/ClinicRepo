using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
	public interface IStoreService
	{
		bool CreateProduct(Product p);
		IEnumerable<Product> GetProducts();
		IEnumerable<Product> GetProductsByFiscalCode(string fc);
		IEnumerable<Product> GetProductsByDate(string date);
		bool AddToCart(Product p, Cart c, int qty);
		bool DeleteToCart();
		bool Checkout(Cart c, List<ProductCart> list,string street, byte[]? picture,string? extension);
	
	}
}
