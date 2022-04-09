using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FisioterapiaUlatskawa.Models
{
    public class PagosViewModel
    {
        [Key]
        [Display(Name = "Pago")]
        public int idPago { get; set; }


        [Display(Name = "Tipo de Pago")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public Nullable<int> tipoPago { get; set; }

        [Display(Name = "Tipo de Pago")]
        public string nombrePago { get; set; }
        public List<SelectListItem> ListaTipoPago { get; set; }

        [Display(Name = "Monto")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public Nullable<double> monto { get; set; }

        [Display(Name = "Banco")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string banco { get; set; }

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string cedula { get; set; }

        [Display(Name = "Fecha Pago")]
     
        public Nullable<System.DateTime> fechaPago { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Notas")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 200, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string notas { get; set; }

        [Display(Name = "Desde")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]

        public Nullable<System.DateTime> fechaDesde { get; set; }


        [Display(Name = "Hasta")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]

        public Nullable<System.DateTime> fechaHasta { get; set; }


        public PagosViewModel Pagos { get; set; }
    }
}