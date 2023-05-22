namespace DataLayer
{
	public class Animal
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Typology { get; set; } = String.Empty;
        public DateTime? BirthDate { get; set; }
        public DateTime RegistrationDate { get; set;}
        public string CoatColor { get; set; } = String.Empty;
        public bool? HasMicrochip { get; set; }=false;
        public string? MicrochipNumber { get; set;}

    }
}