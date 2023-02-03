﻿using System.Collections.Generic;

namespace My_Books.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        //Navigation Proporties
        public List<Book_Author> Book_Author { get; set; }

    }
}
