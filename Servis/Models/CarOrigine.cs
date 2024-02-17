namespace Servis.Models
{
    public class CarOrigine
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int OrigineID { get; set; }
        public Origine Origine { get; set; }
    }
}
