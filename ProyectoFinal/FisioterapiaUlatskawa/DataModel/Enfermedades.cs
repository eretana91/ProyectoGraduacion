//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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
