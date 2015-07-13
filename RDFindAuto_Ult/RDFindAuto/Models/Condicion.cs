using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RDFindAuto.Models
{
    [Table("Condiciones")]
    public class Condicion
    {
        public Condicion()
        {
            this.Publicaciones = new HashSet<Publicacion>();
        }

        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int IDCondicion { get; set; }
        [Display(Name = "Condición")]
        public string condicionDesc { get; set; }
        public virtual ICollection<Publicacion> Publicaciones { get; set; }
    }
}