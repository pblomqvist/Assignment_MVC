using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class PersonDbContext : IdentityDbContext<ApplicationUser>
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
            modelBuilder.Entity<PersonLanguage>().HasKey(pl => new { pl.PersonId, pl.LanguageId });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(p => p.Person)
                .WithMany(pl => pl.PersonLanguages)
                .HasForeignKey(pl => pl.PersonId)
                .OnDelete(DeleteBehavior.Cascade); ;

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(l => l.Language)
                .WithMany(pl => pl.PersonLanguages)
                .HasForeignKey(pl => pl.LanguageId)
                .OnDelete(DeleteBehavior.Cascade); ;

            modelBuilder.Entity<City>()
                .HasOne<Country>(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Person>()
            .Property(p => p.City)
            .IsRequired(false);

            //Seeding
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    Name = "Maja Gräddnos",
                    CityId = 3,
                    PhoneNumber = 12345
                }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 2,
                    Name = "Kalle Kaviar",
                    CityId = 4,
                    PhoneNumber = 123457
                }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 3,
                    Name = "Pelle Svanslös",
                    CityId = 2,
                    PhoneNumber = 123458
                }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 4,
                    Name = "Frank Franksson",
                    CityId = 1,
                    PhoneNumber = 123458
                }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 5,
                    Name = "Kalle Söderström",
                    CityId = 1,
                    PhoneNumber = 123458
                }
            );

            //Country
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    CountryId = 1,
                    CountryName = "Sweden"
                }
            );

            //City

            modelBuilder.Entity<City>().HasData(
                new City
                {
                    CountryId = 1,
                    CityId = 1,
                    CityName = "Göteborg"
                }
            );

            modelBuilder.Entity<City>().HasData(
                new City
                {
                    CountryId = 1,
                    CityId = 2,
                    CityName = "Stockholm"
                }
            );

            modelBuilder.Entity<City>().HasData(
                new City
                {
                    CountryId = 1,
                    CityId = 3,
                    CityName = "Kiruna"
                }
            );

            modelBuilder.Entity<City>().HasData(
                new City
                {
                    CountryId = 1,
                    CityId = 4,
                    CityName = "Västerås"
                }
            );

            //Language
            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    LanguageId = 1,
                    LanguageName = "Swedish"
                }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    LanguageId = 2,
                    LanguageName = "Norwegian"
                }
            );

            //PersonLanguage
            modelBuilder.Entity<PersonLanguage>().HasData(
                new PersonLanguage
                {
                    PersonId = 1,
                    LanguageId = 1
                }
            );

            modelBuilder.Entity<PersonLanguage>().HasData(
                new PersonLanguage
                {
                    PersonId = 1,
                    LanguageId = 2
                }
            );

            modelBuilder.Entity<PersonLanguage>().HasData(
                new PersonLanguage
                {
                    PersonId = 2,
                    LanguageId = 2
                }
            );


            //Users
            string roleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();
            DateTime dt = new DateTime(1987, 12, 31);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userId,
                Name = "User",
                NormalizedName = "USER"
            });

            //Make pw hasher for seeded users
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            //Seeded users
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PasswordHash = hasher.HashPassword(null, "password"),
                FirstName ="Admin",
                LastName="Adminsson",
                BirthDate = dt
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId, UserId = userId
            });

        }


        //Entities
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }
    }
}
