using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RDFindAuto.Models
{
    [Table("Modelos")]
    public class Modelo
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int IDModelo { get; set; }
        [Display(Name = "Marca")]
        public int IDMarca { get; set; }
        [Display(Name = "Modelo")]
        public string modeloDesc { get; set; }

        [ForeignKey("IDMarca")]
        [Display(Name="Marca")]
        public virtual Marca marca { get; set; }
    }
}