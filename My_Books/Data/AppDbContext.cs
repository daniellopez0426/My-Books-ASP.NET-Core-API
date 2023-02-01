using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;

namespace My_Books.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
