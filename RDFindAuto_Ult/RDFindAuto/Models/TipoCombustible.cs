using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RDFindAuto.Models
{
    [Table("TipoCombustible")]
    public class TipoCombustible
    {
        public TipoCombustible()
        {
            this.Publicaciones = new HashSet<Publicacion>();
        }
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int IDTipoCombustible { get; set; }
        [Display(Name = "Tipo Combustible")]
        public string tipoCombustibledesc { get; set; }

        public virtual ICollection<Publicacion> Publicaciones { get; set; }
    }
}