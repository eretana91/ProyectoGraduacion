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
    
    public partial class Inventarios
    {
        public int idProducto { get; set; }
        public Nullable<int> tipoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string codigoBarras { get; set; }
        public string precio { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<System.DateTime> fechaExpiracion { get; set; }
        public string notas { get; set; }
    
        public virtual TipoProducto TipoProducto1 { get; set; }
    }
}
