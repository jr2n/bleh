using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RDFindAuto.Models
{
    [Table("Colores")]
    public class Color
    {
        public Color()
        {
            this.Publicaciones = new HashSet<Publicacion>();
        }

        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int IDColor { get; set; }
        [Display(Name = "Color")]
        public string colorDesc { get; set; }
        public virtual ICollection<Publicacion> Publicaciones { get; set; }
    }
}