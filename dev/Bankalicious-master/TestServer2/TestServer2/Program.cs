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

                Console.WriteLine("Voer de naam van de eerste klant in:");
                string name = Console.ReadLine();

                //we maken een nieuw klant-object aan
                var Klant = new Klant { Naam = name };

                //we we voegen deze klant aan de database toe
                db.Klant.Add(Klant);

                //en we slaan de nieuwe dingen in de database op
                db.SaveChanges();

                Console.WriteLine("\nDe klanten zijn:");

                //we lopen door alle klanten heen. Op de achtergrond wordt er sql uitgevoerd.
                //db.clients is een property, net als de properties die je onderaan hebt aangemaakt
                foreach (var item in db.Klant)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine();
                Console.WriteLine("please enter the name of your new bank account");
                var account = Console.ReadLine();
                var Klant = new Klant { KlantID = KlantID, Title = account};
                db.Klant.Add(Account);
                db.SaveChanges();
                Console.WriteLine("\nDe rekeningen zijn:");
                foreach (var item in db.Klant)
                {
                    Console.WriteLine("rekeningnaam: " + item.Title);
                    Console.WriteLine("eigenaar: " + item.Klant.Name);
                    Console.WriteLine();
                }

                Console.WriteLine("Voer de naam in van de klant die je wilt zoeken");
                var zoekstring = Console.ReadLine();
                var GevondenKlant = db.Klant.Where(x => x.Name.Contains(zoekstring)).First();
                Console.Write(GevondenKlant.Name);
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
