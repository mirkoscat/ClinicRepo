using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class ClinicAnimal :Animal
	{
		[Required]
        public string OwnerName { get; set; }
        [Required]
        public string OwnerLastName { get; set; } = String.Empty;
		public ICollection<ClinicVisit> ClinicVisits { get; set; } = new List<ClinicVisit>();


	}
}
