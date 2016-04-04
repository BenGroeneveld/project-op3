using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [Table("Transactie")]
    public class Transactie
    {
        public int TransactieID { get; set; }
        public int RekeningID { get; set; }
        public int Balans { get; set; }
        public int PasID { get; set; }
    }
}