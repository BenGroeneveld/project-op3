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
            //we maken een nieuwe database-context. Als de database nog niet bestaat; wordt deze aangemaakt
            using (var db = new BankContext())
            {
                //en we slaan de nieuwe dingen in de database op
                db.SaveChanges();
                Console.WriteLine("\nDe rekeningen zijn:");
                foreach (var item in )
                {
                    Console.WriteLine("rekeningnaam: " + item.Rekening.RekeningType);
                    Console.WriteLine("eigenaar: " + item.Klant.Naam);
                    Console.WriteLine();
                }

                Console.WriteLine("Voer de naam in van de klant die je wilt zoeken");
                var zoekstring = Console.ReadLine();
                var GevondenKlant = db.Klant.Where(x => x.Naam.Contains(zoekstring)).First();
                Console.Write(GevondenKlant.Naam);
                Console.ReadKey();
            }
                
        }
    }

    /// <summary>
    /// door het aanmaken van een dbcontext zorg je dat er tabellen worden gemaakt met onderstaande namen Clients en Accounts
    /// </summary>
    public class BankContext : DbContext
    {
        public BankContext() : base("MyDbContextConnectionString") { }
        public DbSet<Klant> Klant { get; set; }
        public DbSet<Rekening> Rekening { get; set; }
        public DbSet<Pas> Pas { get; set; }
        public DbSet<Transactie> Transactie { get; set; }

    }

    /// <summary>
    /// Dit is ons model van de klant. 
    /// </summary>
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
