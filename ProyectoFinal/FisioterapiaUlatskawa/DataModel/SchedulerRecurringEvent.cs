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
    
    public partial class SchedulerRecurringEvent
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> EventPID { get; set; }
        public string RecType { get; set; }
        public Nullable<double> EventLength { get; set; }
    }
}
