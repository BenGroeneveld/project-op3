using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Rekening
    {
        public int RekeningID { get; set; }
        public int Balans { get; set; }
        public int RekeningType { get; set; }
       // public virtual Pas pas { get; set; }
    }
}