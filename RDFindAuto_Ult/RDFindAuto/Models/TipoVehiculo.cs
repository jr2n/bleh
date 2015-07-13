using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RDFindAuto.Models
{
    [Table("TipoVehiculo")]
    public class TipoVehiculo
    {
        public TipoVehiculo()
        {
            this.Publicaciones = new HashSet<Publicacion>();
        }
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int IDTipoVehiculo { get; set; }
        [Display(Name = "Tipo Vehiculo")]
        public string tipoVehiculodesc { get; set; }

        public virtual ICollection<Publicacion> Publicaciones { get; set; }
    }
}