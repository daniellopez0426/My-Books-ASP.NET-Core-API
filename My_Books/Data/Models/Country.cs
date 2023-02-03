using System.Collections.Generic;

namespace My_Books.Data.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        //Navigation Proporties
        public int IdMachine { get; set; }
        public Machine Machine { get; set; }

    }
}
