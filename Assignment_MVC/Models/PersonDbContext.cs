using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AssignmentDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //seed people
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    Name = "Maja Gräddnos",
                    City = "Kiruna",
                    PhoneNumber = 12345
                }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 2,
                    Name = "Kalle Kaviar",
                    City = "Västerås",
                    PhoneNumber = 123457
                }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 3,
                    Name = "Pelle Svanslös",
                    City = "Stockholm",
                    PhoneNumber = 123458
                }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 4,
                    Name = "Frank Franksson",
                    City = "Göteborg",
                    PhoneNumber = 123458
                }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 5,
                    Name = "Kalle Söderström",
                    City = "Göteborg",
                    PhoneNumber = 123458
                }
            );

        }


        //Entities
        public DbSet<Person> People { get; set; }
    }
}
