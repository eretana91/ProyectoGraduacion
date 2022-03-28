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
        [Display(Name = "Paciente")]
        public int cedula { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public Nullable<int> fechaN { get; set; }

        [Display(Name = "Ciudad")]
        public string ciudad { get; set; }

        [Display(Name = "Canton")]
        public string canton { get; set; }

        [Display(Name = "Distrito")]
        public string distrito { get; set; }

        [Display(Name = "Diagnostico")]
        [DataType(DataType.MultilineText)]
        public string diagnostico { get; set; }

        [Display(Name = "Antecedentes")]
        [DataType(DataType.MultilineText)]
        public string antecedentes { get; set; }

        [Display(Name = "Medicamentos utilizados")]
        [DataType(DataType.MultilineText)]
        public string mediUtilizados { get; set; }

        [Display(Name = "Antecedentes Quirurgicos")]
        [DataType(DataType.MultilineText)]
        public string anteQuirurgicos { get; set; }

        [Display(Name = "Fracturas")]
        [DataType(DataType.MultilineText)]
        public string fracturas { get; set; }

        [Display(Name = "Antecedentes Familiares")]
        [DataType(DataType.MultilineText)]
        public string anteFamiliares { get; set; }


    }
}