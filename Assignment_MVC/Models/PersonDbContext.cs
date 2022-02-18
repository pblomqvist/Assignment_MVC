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

            //Setting relationships

            //Seeding
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    Name = "Maja Gräddnos",
                    CityName = "Kiruna",
                    PhoneNumber = 12345
                }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 2,
                    Name = "Kalle Kaviar",
                    CityName = "Västerås",
                    PhoneNumber = 123457
                }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 3,
                    Name = "Pelle Svanslös",
                    CityName = "Stockholm",
                    PhoneNumber = 123458
                }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 4,
                    Name = "Frank Franksson",
                    CityName = "Göteborg",
                    PhoneNumber = 123458
                }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 5,
                    Name = "Kalle Söderström",
                    CityName = "Göteborg",
                    PhoneNumber = 123458
                }
            );

            //Country
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    CountryName = "Sweden"
                }
            );

            //City

            modelBuilder.Entity<City>().HasData(
                new City
                {
                    CityName = "Göteborg",
                    CountryName = "Sweden"

                }
            );

            modelBuilder.Entity<City>().HasData(
                new City
                {
                    CityName = "Stockholm",
                    CountryName = "Sweden"
                }
            );

            modelBuilder.Entity<City>().HasData(
                new City
                {
                    CityName = "Kiruna",
                    CountryName = "Sweden"
                }
            );

            modelBuilder.Entity<City>().HasData(
                new City
                {
                    CityName = "Västerås",
                    CountryName = "Sweden"
                }
            );

        }


        //Entities
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
