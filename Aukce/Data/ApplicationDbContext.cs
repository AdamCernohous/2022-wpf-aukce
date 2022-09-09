using Aukce.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Aukce.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public DbSet<Book>? Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public ApplicationDbContext() : base()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=Auctions2022.sqlite");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Book>()
            //    .HasIndex(u => u.BookId)
            //    .IsUnique();
            //builder.Entity<Book>().HasData(new Book { BookId = 1, Title = "Společenstvo prstenu", Pages = 300 });
        }
    }
}
