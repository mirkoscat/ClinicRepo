
using System.ComponentModel.DataAnnotations;


namespace DataLayer
{
	public class MunicipalAnimal:Animal
	{
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RecoveryStart { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RecoveryEnd { get; set;}
        [Required]
        public byte[]? Picture { get; set; }
        public string? FileExtension { get; set; }
        [Required]
		public bool IsInHospital { get; set; }=false;
        
		public ICollection<MunicipalVisit> MunicipalVisits { get; set; } = new List<MunicipalVisit>();



	}
}
