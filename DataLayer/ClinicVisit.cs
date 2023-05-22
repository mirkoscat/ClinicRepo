using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class ClinicVisit
	{
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public string ExamTypology { get; set; } = String.Empty;
        public string TreatmentDescription { get; set; } = String.Empty;

		public string DescriptionBeforeVisit { get; set; } = String.Empty;
        public ICollection<ClinicAnimal> ClinicAnimals { get; set; }= new List<ClinicAnimal>();
    

    }
}
