using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_applicatie
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BankContext())
            {
                Console.WriteLine("naam van de nieuwe klant: ");
                String name = Console.ReadLine();
                Console.WriteLine("ID van de nieuwe klant: ");
                int klantid = Convert.ToInt32(Console.ReadLine());
                var klant = new Klant { Naam = name, KlantID = klantid };
                
                db.Klant.Add(klant);

                db.SaveChanges();

                
                Console.WriteLine();
                Console.WriteLine("please enter the Pasnr: ");
                int pasID = Convert.ToInt32(Console.ReadLine());
                var pas = new Pas { KlantID = klantid, PasID = pasID };
                db.Pas.Add(pas);
                db.SaveChanges();
               
                Console.WriteLine();
                Console.WriteLine("Please enter rekeningid");
                int rekeningid = Convert.ToInt32(Console.ReadLine());
                var rekening = new Rekening { };
                db.Rekening.Add(rekening);
               
                int transactieid = Convert.ToInt32(Console.ReadLine());
                var transactie = new Transactie { TransactieID = transactieid, RekeningID = rekeningid};
                db.Transactie.Add(transactie);
                Console.WriteLine("Voer de naam in van de klant die je wilt zoeken");
                var zoekstring = Console.ReadLine();
                var GevondenKlant = db.Klant.Where(x => x.Naam.Contains(zoekstring)).First();
                Console.Write(GevondenKlant.Naam);
                Console.ReadKey();
            }
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
        [Key]
        public int KlantID { get; set; }
        public string Adres { get; set; }
        public string Naam { get; set; }
        public string Achternaam { get; set; }
        public String Postcode { get; set; }
        public virtual List<Pas> pasLs { get; set; }
        public virtual List<Rekening> rekeningLs { get; set; }
        public virtual List<Transactie> transactieLs { get; set; }
        public virtual Pas pas { get; set; }
        public virtual Rekening rekening { get; set; }
        public virtual Transactie transactie { get; set; }
    }
    public class Pas
    {
        [Key]
        public int PasID { get; set; }
        public int RekeningID { get; set; }
        public int KlantID { get; set; }
        public int Actief { get; set; }
        public int Pincode { get; set; }
        public virtual List<Klant> klantLs { get; set; }
        public virtual List<Rekening> rekeningLs { get; set; }
        public virtual List<Transactie> transactieLs { get; set; }
        public virtual Klant klant { get; set; }
        public virtual Rekening rekening { get; set; }
        public virtual Transactie transactie { get; set; }
    }
    public class Rekening
    {
        [Key]
        public int RekeningID { get; set; }
        public double Balans { get; set; }
        public int RekeningType { get; set; }
        public virtual List<Klant> KlantLs { get; set; }
        public virtual List<Pas> pasLs { get; set; }
        public virtual List<Transactie> transactieLs { get; set; }
        public virtual Klant klant { get; set; }
        public virtual Pas pas { get; set; }
        public virtual Transactie transactie { get; set; }
    }
    public class Transactie
    {
        [Key]
        public int TransactieID { get; set; }
        public int RekeningID { get; set; }
        public double Balans { get; set; }
        public int PasID { get; set; }
        public virtual List<Klant> klantLs { get; set; }
        public virtual List<Rekening> rekeningLs { get; set; }
        public virtual List<Pas> pasLs { get; set; }
        public virtual Klant klant { get; set; }
        //public virtual Pas pas { get; set; }
        public virtual Rekening rekening { get; set; }
    }
    
}
