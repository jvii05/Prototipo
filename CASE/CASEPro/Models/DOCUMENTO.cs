//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CASEPro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DOCUMENTO
    {
        public decimal ID { get; set; }
        public string NOMBRE { get; set; }
        public string TIPO { get; set; }
        public string UBICACION { get; set; }
        public decimal REQUERIMIENTO_ID { get; set; }
    
        public virtual REQUERIMIENTO REQUERIMIENTO { get; set; }
    }
}
