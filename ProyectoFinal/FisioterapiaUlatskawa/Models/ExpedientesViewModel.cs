using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FisioterapiaUlatskawa.Models
{
    public class ExpedientesViewModel
    {
        [Key]
        [Display(Name = "Expediente")]
        public int idExpediente { get; set; }
        public List<SelectListItem> ListaExpediente { get; set; }

        [Display(Name = "Usuario")]
        public List<SelectListItem> ListaUsuarios { get; set; }


        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public string cedula { get; set; }


        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public Nullable<System.DateTime> fechaN { get; set; }


        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public string ciudad { get; set; }

        [Display(Name = "Cantón")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public string canton { get; set; }

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public string distrito { get; set; }

        [Display(Name = "Diagnóstico")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [DataType(DataType.MultilineText)]
        public string diagnostico { get; set; }

        [Display(Name = "Antecedentes")]
        [DataType(DataType.MultilineText)]
        public string antecendente { get; set; }


        [Display(Name = "Medicamentos utilizados")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public string mediUtilizados { get; set; }

        [Display(Name = "Antecedentes Quirúrgicos")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public string anteQuirurgicos { get; set; }

        [Display(Name = "Fracturas")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public string fracturas { get; set; }

        [Display(Name = "Antecedentes Familiares")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public string anteFamiliares { get; set; }



    }
}