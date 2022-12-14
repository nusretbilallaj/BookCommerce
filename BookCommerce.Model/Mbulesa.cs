using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCommerce.Model
{
    [Table("Mbulesa")]
    public class Mbulesa
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Kerkohet emri")]
        public string Emri { get; set; }
    }
}
