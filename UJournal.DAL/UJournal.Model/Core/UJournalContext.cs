using Microsoft.EntityFrameworkCore;
using UJournal.Model.Models;
using UJournal.Model.Core;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace UJournal.Model.Core
{
    public class UJournalContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public UJournalContext(DbContextOptions<UJournalContext> context) : base(context)//Here comes the configuration from Startup class
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();//If db isn`t create - CREATE it
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //Use this method to override configuration using in constructor
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id= 1, FirstName="Andrey", LastName="Kuklinov"},
                new Student { Id = 2, FirstName = "Oleg", LastName = "Ivanetc" },
                new Student { Id = 3, FirstName = "Ivan", LastName = "Burchan" }
            );
        }
    }
}
