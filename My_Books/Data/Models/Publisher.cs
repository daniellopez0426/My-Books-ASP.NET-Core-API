using My_Books.Data.Models;
using System.Collections.Generic;

namespace My_Books.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Proporties
        public List<Book> Books { get; set; }
    }
}
