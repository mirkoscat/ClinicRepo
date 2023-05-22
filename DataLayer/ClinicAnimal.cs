using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class ClinicAnimal :Animal
	{
        public string OwnerName { get; set; } 
        public string OwnerLastName { get; set; } = String.Empty;
		public ICollection<ClinicVisit> ClinicVisits { get; set; } = new List<ClinicVisit>();


	}
}
