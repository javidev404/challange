using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardsApp.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerson { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string Lastname { get; set; }
        [MaxLength(200)]
        [Required]
        public string Adress { get; set; }
        public virtual ICollection<Card> Cards { get; set; }

        [MaxLength(50)]
        [Required]
        public string DNI { get; set; }
    }
}
