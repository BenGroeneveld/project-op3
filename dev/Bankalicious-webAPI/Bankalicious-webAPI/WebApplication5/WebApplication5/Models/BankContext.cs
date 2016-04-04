using System.Data.Entity;

namespace WebApplication5.Models
{
    public class BankContext : DbContext
    {
        public BankContext() : base("MyDbContextConnectionStringRemote") //verwijs hier naar de connection string in de app.config. Op deze manier kan je redelijk makkelijk switchen tussen verschillende databases
        //public BankContext()
        {
            base.Configuration.LazyLoadingEnabled = false; //helaas ondersteunt de huidige versie van de mysql connector geen lazy loading, dus die moeten we uitzetten
        }

        public DbSet<Klant> Klants { get; set; }

        public DbSet<Pas> Pas { get; set; }

        public DbSet<Rekening> Rekenings { get; set; }

        public DbSet<Transactie> Transacties { get; set; }
    }
}