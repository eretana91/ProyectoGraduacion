using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FisioterapiaUlatskawa.Models
{
    public class InventariosViewModel

    {  
        [Key]
        [Display(Name = "Producto")]
        public int idProducto { get; set; }

        [Display(Name = "Tipo de Producto")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public Nullable<int> tipoProducto { get; set; }

        [Display(Name = "Tipo Producto")]
        public string nombreProducto { get; set; }
        public List<SelectListItem> ListaTipoProducto { get; set; }


        //[Display(Name = "Nombre del producto")]
        //[Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        //[StringLength(maximumLength: 200, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        //public string nombreProducto { get; set; }


        [Display(Name = "Código de barras")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 200, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string codigoBarras { get; set; }

      
        [Display(Name = "Precio del producto")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 200, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string precio { get; set; }


        [Display(Name = "Cantidad adquirida")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public Nullable<int> cantidad { get; set; }

        
        [Display(Name = "Feche de expiración")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fechaExpiracion { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Notas")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 200, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string notas { get; set; }
    }
}