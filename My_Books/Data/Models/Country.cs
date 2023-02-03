using System.Collections.Generic;

namespace My_Books.Data.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Machine_Country> Machine_Country { get; set; }
    }
}
