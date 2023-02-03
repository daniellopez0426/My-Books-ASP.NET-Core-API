using My_Books.Data.Models;

namespace My_Books.Data.Models
{
    public class Machine_Country
    {
        public int Id { get; set; }
        public double Price { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
