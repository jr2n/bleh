using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RDFindAuto.Models
{
    [Table("Publicaciones")]
    public class Publicacion
    {
        public Publicacion()
        {
            this.Imagenes = new HashSet<Imagen>();
        }

        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int IDPublicacion { get; set; }
        [Display(Name = "Marca")]
        public int IDMarca { get; set; }
        [Display(Name = "Modelo")]
        public int IDModelo { get; set; }
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
        [Display(Name = "Color")]
        public int IDColor { get; set; }
        [Display(Name = "Tipo de Combustible")]
        public int IDTipoCombustible { get; set; }
        [Display(Name = "Tipo Vehiculo")]
        public int IDTipoVehiculo { get; set; }
        [Display(Name = "Condición")]
        public int IDCondicion { get; set; }
        [Display(Name = "Usuario")]
        public int IDUser { get; set; }
        [Display(Name = "Fecha Publicación")]
        public System.DateTime WDate { get; set; }
        [Display(Name = "Estatus")]
        public int Status { get; set; }

        public virtual Color color { get; set; }
        public virtual Condicion condicion { get; set; }
        public virtual ICollection<Imagen> Imagenes { get; set; }
        [ForeignKey("IDMarca")]
        public virtual Marca marca { get; set; }
        [ForeignKey("IDModelo")]
        public virtual Modelo modelo { get; set; }
        public virtual TipoCombustible tipoCombustible { get; set; }
        public virtual TipoVehiculo tiposVehiculo { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}