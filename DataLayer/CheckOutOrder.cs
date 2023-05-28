using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{//can't do other migrations "EF not installed in DataLayer error"
	//public class CheckOutOrder
	//{
	//	[Key]
	//	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
 //       public int Id { get; set; }
		
	//	public DateTime? OrderDate { get; set; }
	//	[Required]
	//	[StringLength(50)]
	//	public string StreetName { get; set; }
	//	public byte[]? Picture { get; set; }
	//	public string? FileExtension { get; set; }
	//	public Cart Cart { get; set; }= new Cart();
	//	public List<ProductCart> ProductCarts { get; set; } = new List<ProductCart>();
	//	public OrderStatus OrderStatus { get; set; } 
	//}
	//public enum OrderStatus : int {
	//Pending=1,
	//Sent,
	//Received	
	//}
}
