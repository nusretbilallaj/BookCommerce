using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookCommerce.Model
{
    [Table("Produkti")]
    public class Produkti
    {
        public int Id { get; set; }
        [Required]
        public string Emri { get; set; }
        [Required]
        public string Pershkrimi { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        [Range(1,1000)]
        public double CmimiBaze { get; set; }
        [Range(1, 1000)]
        public double Cmimi { get; set; }
        [Range(1, 1000)]
        public double Cmimi50 { get; set; }
        [Range(1, 1000)]
        public double Cmimi100 { get; set; }
        [Range(1, 1000)]
        public string ImagePath { get; set; }

        public int KategoriaId { get; set; }
        [ForeignKey("KategoriaId")]
        [ValidateNever]
        public Kategoria Kategoria { get; set; }
        public int MbulesaId { get; set; }
        [ForeignKey("MbulesaId")]
        [ValidateNever]
        public Mbulesa Mbulesa { get; set; }
    }
}
