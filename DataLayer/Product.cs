
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataLayer
{
	public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string MedicineName { get; set; }
        [Required]
        public string BusinessName { get; set; }
        public string? BusinessStreet { get; set; }
        public string? BusinessTelNum { get; set; }
        public int QtyInStock { get; set; }
        public Usage? Usage { get; set; } = 0;
		public ProductType? Type { get; set; } = 0;
        public string? NumCassetto { get; set; }
        public string? NumArmadietto { get; set; }
        public int? Price { get; set; }
        public ICollection<ProductCart> ProductsInCart { get; set; } = new List<ProductCart>();

    }
	public enum Usage : int
	{
		EarInfection,
		Cold,
		Dermatitis,
		BonePain,
		DryFood

	}
	public enum ProductType : int
	{
		Medicin,
        Integratore,
        Food

	}
}
