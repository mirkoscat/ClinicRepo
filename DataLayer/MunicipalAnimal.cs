using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class MunicipalAnimal:Animal
	{
        [Required]
        public DateTime RecoveryStart { get; set; }
        [Required]
        public DateTime RecoveryEnd { get; set;}
        [Required]
        public byte[]? Picture { get; set; }
        public string? FileExtension { get; set; }
        [Required]
		public bool IsInHospital { get; set; }=false;
        
		public ICollection<MunicipalVisit> MunicipalVisits { get; set; } = new List<MunicipalVisit>();



	}
}
