using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardsApp.Models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCard { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string Number { get; set; }
        [MaxLength(50)]
        [Required]
        public string cardHolder { get; set; }
        [ForeignKey("Person")]
        public int IdPerson { get; set; }
        [ForeignKey("IdPerson")]
        public virtual Person Person { get; set; }
        [Required]
        public long Limit { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public DateTime Expiration { get; set; }
        [Required]
        public Brand Brand { get; set; }

    }

    //existen tres Brands de Card de crédito, a saber: “SQUA”, “SCO”, “PERE”
    public enum Brand
    {
        SQUA,
        SCO,
        PERE
    }
}
