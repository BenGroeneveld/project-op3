using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [Table("Pas")]
    public class Pas
    {
        public int PasID { get; set; }
        public int RekeningID { get; set; }
        public int KlantID { get; set; }
        public int Actief { get; set; }
        public int Pincode { get; set; }
    }
}