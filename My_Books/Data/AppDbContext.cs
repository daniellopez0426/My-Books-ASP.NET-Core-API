using Microsoft.EntityFrameworkCore;
using My_Books.Data.Models;

namespace My_Books.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Author)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Author)
                .HasForeignKey(bi => bi.AuthorId);


            modelBuilder.Entity<Machine_Country>()
                .HasOne(m => m.Machine)
                .WithMany(mc => mc.Machine_Country)
                .HasForeignKey(mi => mi.MachineId);

            modelBuilder.Entity<Machine_Country>()
                .HasOne(c => c.Country)
                .WithMany(mc => mc.Machine_Country)
                .HasForeignKey(ci => ci.CountryId);
                        
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Machine_Country> Country_Machine { get; set; }
    }
}
