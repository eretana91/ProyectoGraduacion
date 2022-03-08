using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FisioterapiaUlatskawa.Models
{
    public class EnfermedadesViewModel
    {
        [Key]
        public int idEnfermedad { get; set; }

        [Display(Name = "Enfermedad")]
       [StringLength(maximumLength: 50, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string nombreEnfermedad { get; set; }

        [Display(Name = "Cédula")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string cedula { get; set; }

        public List<EnfermedadesViewModel> Detalles { get; set; }
    } 
}