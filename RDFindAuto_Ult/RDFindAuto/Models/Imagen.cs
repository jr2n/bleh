using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RDFindAuto.Models
{
    [Table("Imagenes")]
    public class Imagen
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int IDImagen { get; set; }
        [Display(Name = "Publicación")]
        public int IDPublicacion { get; set; }
        [Display(Name = "Imagen")]
        public string imagenDesc { get; set; }
        public virtual Publicacion publicacion { get; set; }
    }
}