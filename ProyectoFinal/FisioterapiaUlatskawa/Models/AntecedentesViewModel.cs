using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FisioterapiaUlatskawa.Models
{
    public class AntecedentesViewModel
    {
        [Key]
        public int idAntecedente { get; set; }

        [Display(Name = "Antecedente")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string nombreAntecedente { get; set; }

        [Display(Name = "Cédula")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string cedula { get; set; }

        public List<AntecedentesViewModel> Detalles { get; set; }
    }
}