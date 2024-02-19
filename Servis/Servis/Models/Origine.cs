namespace Servis.Models
{
    public class Origine
    {
        public int ID { get; set; }
        public string OrigineName { get; set; }
        public ICollection<CarOrigine>? CarOrigines { get; set; }
    }
}
