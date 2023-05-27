using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
	public class Animal
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Typology { get; set; } = String.Empty;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? BirthDate { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set;}
        [Required]
        public string CoatColor { get; set; } = String.Empty;

        public bool? HasMicrochip { get; set; }=false;
        public string? MicrochipNumber { get; set;}
       
      

    }
}