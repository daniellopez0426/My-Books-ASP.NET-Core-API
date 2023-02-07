using System.Collections.Generic;

namespace My_Books.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }

    }

    public class AuthorWithBooksVM
    {
        public string FullName { get; set;}
        public List<string> BooksTitles { get; set; }
    }
}
