using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class MunicipalVisit:ClinicVisit
	{
      
        public int Price { get; set; } = 0;
        public DateTime PaymentDate { get; set; }
        public RecoveryStatus Status { get; set; } = 0;
		public ICollection<MunicipalAnimal> MunicipalAnimals { get; set; } = new List<MunicipalAnimal>();


	}
	public enum RecoveryStatus : int { 
    NotInRecovery,
    InRecovery
    }
}
