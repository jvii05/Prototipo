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
    
    public partial class CASO_USO_DETALLES
    {
        public decimal ID { get; set; }
        public decimal CASO_USO_ID { get; set; }
        public decimal DETALLE_TIPO_ID { get; set; }
        public string CONTENIDO { get; set; }
    
        public virtual CASOS_USOS CASOS_USOS { get; set; }
        public virtual DETALLE_TIPOS DETALLE_TIPOS { get; set; }
    }
}
