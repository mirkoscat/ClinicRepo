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
		bool AddToCart();
		bool DeleteToCart();
		

		//lista farmaci
		//getfarmacobyid
		
	}
}
