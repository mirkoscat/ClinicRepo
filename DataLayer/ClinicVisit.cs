using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class ClinicVisit
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime VisitDate { get; set; }
        [Required]
        [StringLength(100)]
        public string ExamTypology { get; set; } = String.Empty;
        [Required]
        [StringLength(200)]
        public string TreatmentDescription { get; set; } = String.Empty;
        [StringLength(1024)]

        public string DescriptionBeforeVisit { get; set; } = String.Empty;
        public ICollection<ClinicAnimal> ClinicAnimals { get; set; }= new List<ClinicAnimal>();
    

    }
}
