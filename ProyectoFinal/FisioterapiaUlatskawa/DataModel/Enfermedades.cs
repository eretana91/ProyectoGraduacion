//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FisioterapiaUlatskawa.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enfermedades
    {
        public int idEnfermedad { get; set; }
        public string nombreEnfermedad { get; set; }
        public string cedula { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
