using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RDFindAuto.Models
{
    [Table("Anucios")]
    public class Anucio
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name="ID")]
        public int IDAnucio { get; set; }
        [Display(Name = "Anucio")]
        public string anucioDesc { get; set; }
        public string URL { get; set; }
    }
}