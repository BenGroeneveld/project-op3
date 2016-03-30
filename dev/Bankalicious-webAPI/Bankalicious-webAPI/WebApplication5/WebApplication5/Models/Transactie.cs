using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Transactie
    {
        public int TransactieID { get; set; }
        public int RekeningID { get; set; }
        public int Balans { get; set; }
        public int PasID { get; set; }
    }
}