using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class MunicipalAnimal:Animal
	{
        public DateTime RecoveryStart { get; set; }
		public DateTime RecoveryEnd { get; set;}
		public byte[] Picture { get; set; }
		public bool IsInHospital { get; set; }=false;
		public ICollection<MunicipalVisit> MunicipalVisits { get; set; } = new List<MunicipalVisit>();



	}
}
