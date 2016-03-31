using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Pas
    {
        public int PasID { get; set; }
        public int RekeningID { get; set; }
        public int KlantID { get; set; }
        public int Actief { get; set; }
        public int Pincode { get; set; }

        //public virtual Klant Klanten { get; set; }
        //public virtual Rekening Rekeningen { get; set; }
    }
}