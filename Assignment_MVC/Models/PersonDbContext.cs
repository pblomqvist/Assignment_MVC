﻿using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<PersonLanguage>().HasKey(pl => new { pl.PersonId, pl.LanguageName });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(p => p.Person)
                .WithMany(pl => pl.PersonLanguages)
                .HasForeignKey(pl => pl.PersonId)
                .OnDelete(DeleteBehavior.Cascade); ;

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(l => l.Language)
                .WithMany(pl => pl.PersonLanguages)
                .HasForeignKey(pl => pl.LanguageName)
                .OnDelete(DeleteBehavior.Cascade); ;

            modelBuilder.Entity<City>()
                .HasOne<Country>(c => c.Country)
                .WithMany(pl => pl.Cities)
                .HasForeignKey(pl => pl.CountryName);

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

            //Language
            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    LanguageName = "Swedish"
                }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    LanguageName = "Norwegian"
                }
            );

            //PersonLanguage
            modelBuilder.Entity<PersonLanguage>().HasData(
                new PersonLanguage
                {
                    PersonId = 1,
                    LanguageName = "Swedish"
                }
            );

            modelBuilder.Entity<PersonLanguage>().HasData(
                new PersonLanguage
                {
                    PersonId = 1,
                    LanguageName = "Norwegian"
                }
            );

            modelBuilder.Entity<PersonLanguage>().HasData(
                new PersonLanguage
                {
                    PersonId = 2,
                    LanguageName = "Norwegian"
                }
            );

        }


        //Entities
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
    }
}
