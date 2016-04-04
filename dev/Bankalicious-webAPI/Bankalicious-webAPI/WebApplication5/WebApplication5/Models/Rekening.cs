using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [Table("Rekening")]
    public class Rekening
    {
        public int RekeningID { get; set; }
        public int Balans { get; set; }
        public int RekeningType { get; set; }
    }
}