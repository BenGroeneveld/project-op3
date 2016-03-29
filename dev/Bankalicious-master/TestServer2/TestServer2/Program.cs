using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*hier moet iets interessants komen te staan, maar dat staat er nu nog niet*/
                
        }
    }

    public class BankContext : DbContext
    {
        public BankContext() : base("MyDbContextConnectionString") { }
        public DbSet<Klant> Klant { get; set; }
        public DbSet<Rekening> Rekening { get; set; }
        public DbSet<Pas> Pas { get; set; }
        public DbSet<Transactie> Transactie { get; set; }

    }
    
    public class Klant
    {

        public string Adres { get; set; }
        public int KlantID { get; set; }
        public string Naam { get; set; }
        public string Achternaam { get; set; }
        public String Postcode { get; set; }
        /*public String getNaam()
        {
            return Naam;
        }*/
    }
    public class Pas
    {
        public String/*(/int)*/ PasID { get; set; }
        public int RekeningID { get; set; }
        public int KlantID { get; set; }
        public int Actief { get; set; }
        public int Pincode { get; set; }
    }
    public class Rekening
    {
        public int RekeningID { get; set; }
        public int Balans { get; set; }
        public int RekeningType { get; set; }
    }
    public class Transactie
    {
        public int TransactieID { get; set; }
        public int RekeningID { get; set; }
        public int Balans { get; set; }
        public int PasID { get; set; }
    }

}
