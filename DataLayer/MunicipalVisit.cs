using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class MunicipalVisit:ClinicVisit
	{
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime PaymentDate { get; set; }
        public RecoveryStatus Status { get; set; } = 0;
		public ICollection<MunicipalAnimal> MunicipalAnimals { get; set; } = new List<MunicipalAnimal>();


	}
	public enum RecoveryStatus : int { 
    NotInRecovery,
    InRecovery
    }
}
