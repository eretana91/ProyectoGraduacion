using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FisioterapiaUlatskawa.Models
{
    public class UsuariosViewModel
    {

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string cedula { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string nombre { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 200, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string apellidos { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string telefono { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El {0} no puede contener más de {1} dígitos.")]
        public string contrasenna { get; set; }


        [Display(Name = "Tipo Usuario")]
        [Required(ErrorMessage = "El campo de {0} es obligatorio.")]
        public Nullable<int> idTipoUsuario { get; set; }

        public List<SelectListItem> ListaTipoUsuario { get; set; }

        [NotMapped]
        public string LoginErrorMessage { get; set; }

    }
}