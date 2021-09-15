using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CardsApp.Helpers;
using CardsApp.Models;

namespace CardsApp.Data
{
    public class CardsContext : DbContext
    {
        private IRateCalculator RateCalculator;

        public CardsContext(DbContextOptions<CardsContext> options, IRateCalculator RateCalculator)
            : base(options)
        {
            this.RateCalculator = RateCalculator;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User()
            {
                IdUser = 1,
                Name = "Javier",
                NameUser = "Javier",
                Password = "Cabrera"
            });

            modelBuilder.Entity<Card>().HasData(new Card()
            {
                IdCard = 1,
                IdPerson = 1,
                Name = "Javier",
                Number = "00000000",
                Limit = 100000,
                Brand = Brand.PERE,
                Rate = RateCalculator.CalcularRatePorcentual(Brand.PERE, DateTime.Now),
                cardHolder = "Javier",
                Expiration = DateTime.Now
            });

            modelBuilder.Entity<Person>().HasData(new Person()
            {
                IdPerson = 1,
                Name = "Javier",
                Lastname = "Cabrera",
                Adress = "Calle 123",
                DNI = "30303030"
            });
        }
    }
}
