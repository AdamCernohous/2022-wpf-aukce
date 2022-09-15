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
            base.OnModelCreating(builder);

            builder.Entity<User>().HasMany(u => u.Auctions);
            builder.Entity<Auction>().HasOne(a => a.Author);

            builder.Entity<User>().HasData(new User { Id = new Guid("d43511aa-84b0-4514-9c5f-ec439113c381"), Username = "adamcernohous", Email = "adacern019@pslib.cz", Password = "1234" });
            builder.Entity<User>().HasData(new User { Id = new Guid("d43511aa-84b0-4514-9c5f-ec439113c382"), Username = "matejandrasko", Email = "matandr019@pslib.cz", Password = "4321" });
            builder.Entity<Auction>().HasData(new Auction { Id = new Guid("31023dc9-4947-43cf-a2c9-4379fc8cbca5"), AuthorId = new Guid("d43511aa-84b0-4514-9c5f-ec439113c381"), Title = "Mona Lisa", Description = "Drahý obraz!", Price = 69, LastBuyerId = new Guid("d43511aa-84b0-4514-9c5f-ec439113c381") });
        }
    }
}