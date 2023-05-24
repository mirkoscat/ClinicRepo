using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class UploadMunicipalAnimal
    {
        public int Id { get; set; }

        public string? Name { get; set; }
       
        public string? Typology { get; set; } = String.Empty;
      
        public string CoatColor { get; set; } = String.Empty;
       

        public DateTime RecoveryStart { get; set; }
      
        public DateTime RecoveryEnd { get; set; }
      
        public IFormFile? Picture { get; set; }
       
        public bool IsInHospital { get; set; } = false;
    }
}
