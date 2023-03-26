using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Books
{
    public class BookContext : DbContext
    {
        public DbSet<Book>? Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-7V9PI8DR\SQLEXPRESS;Database=book;Trusted_Connection=True;Trust Server Certificate=true;");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public Book()
        {
            Publisher = new Publisher();
        }
    }
     
    public class Publisher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    }


}


