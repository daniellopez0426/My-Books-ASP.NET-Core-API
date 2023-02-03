using System.Collections.Generic;

namespace My_Books.Data.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }

        public List<Machine_Country> Machine_Country { get; set; }

    }
}
