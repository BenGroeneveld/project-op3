using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Klant
    {
        [Key]
        public int KlantID { get; set; }
        public string Naam { get; set; }
        public string Achternaam { get; set; }
        public String Postcode { get; set; }
        public string Adres { get; set; }
        public virtual ICollection<Pas> Passen { get; set; }
    }
}