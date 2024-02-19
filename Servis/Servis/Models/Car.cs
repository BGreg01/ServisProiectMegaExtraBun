using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Servis.Models
{
    public class Car
    {
        public int ID { get; set; }
        [Display(Name = "Tip")]
        public string Marca { get; set; }
        public string Revizie { get; set; }
        [Column(TypeName = "decimal(6, 2)")]

        public decimal Pret { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public int? MecanicID { get; set; }
        public Mecanic? Mecanic { get; set; }

        public ICollection<CarOrigine>? CarOrigines { get; set; }

    }
}
