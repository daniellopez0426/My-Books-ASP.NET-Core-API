using System.Collections.Generic;

namespace My_Books.Data.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int units { get; set; }

        //navigation Proporties
        public List<Country> Countries { get; set; }
    }
}
