

using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
	public class MunicipalVisit:ClinicVisit
	{

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int Price { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PaymentDate { get; set; }
        public RecoveryStatus Status { get; set; } = 0;
		public ICollection<MunicipalAnimal> MunicipalAnimals { get; set; } = new List<MunicipalAnimal>();


	}
	public enum RecoveryStatus : int { 
    NotInRecovery,
    InRecovery
    }
}
