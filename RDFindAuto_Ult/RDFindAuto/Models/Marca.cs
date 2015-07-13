using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RDFindAuto.Models
{
    [Table("Marcas")]
    public class Marca
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int IDMarca { get; set; }
        [Display(Name = "Marca")]
        [Required(ErrorMessage="Debe especificar la marca del vehiculo")]
        public string marcaDesc { get; set; }
        public string URLImg { get; set; }
    }
}