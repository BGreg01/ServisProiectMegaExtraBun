using Microsoft.AspNetCore.Mvc.RazorPages;
using Servis.Data;

namespace Servis.Models

{
    public class Mecanic
    {
        public int ID { get; set; }
        public string MecanicName { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
