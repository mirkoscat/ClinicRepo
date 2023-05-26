
namespace DataLayer
{
    public class ClinicAnimal :Animal
	{
        public string? OwnerName { get; set; } = String.Empty;

        public string? OwnerLastName { get; set; } = String.Empty;
        public ICollection<ClinicVisit> ClinicVisits { get; set; } = new List<ClinicVisit>();


	}
}
