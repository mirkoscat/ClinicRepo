using DataLayer;

namespace WebApp.Models
{
	public class CartViewModel
	{
		public ICollection<ProductCart> ListProdottiInCarrello { get; set; } = new List<ProductCart>();
		public Cart Cart { get; set; }= new Cart();

	}
}
