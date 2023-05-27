using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
		public string? StreetName { get; set; }
	
		public DateTime? OrderDate { get; set; }
		
		public byte[]? Picture { get; set; }
		public string? FileExtension { get; set; }
		public ICollection<ProductCart> ProductsInCart { get; set; }=new List<ProductCart>();

    }
}
