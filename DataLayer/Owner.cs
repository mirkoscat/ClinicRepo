
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataLayer
{
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FiscalCode { get; set; }
        public Cart Cart { get; set; }= new Cart();
        public bool HasAnimal { get; set; }=false;



       


    }
}
