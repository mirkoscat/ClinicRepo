
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
	public class ProductCart
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string? Prescription { get; set; }=String.Empty;
        public Product Product { get; set; }=new Product();
        public Cart Cart { get; set; }  =new Cart();

    }
}
