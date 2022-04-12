using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FisioterapiaUlatskawa.Models
{
    public class BibliotecaViewModel
    {
        public int idVideo { get; set; }

        [Display(Name = "Dirección del Video")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 500, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public  string url{ get; set; }

        [Display(Name = "Título del Video")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 80, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string titulo { get; set; }


        [Display(Name = "Descripción del Video")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 500, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string descripcion { get; set; }

    }
}