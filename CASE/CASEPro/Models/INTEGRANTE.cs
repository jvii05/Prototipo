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
    
    public partial class INTEGRANTE
    {
        public decimal USUARIO_ID { get; set; }
        public decimal PROYECTO_ID { get; set; }
        public decimal ROL_ID { get; set; }
    
        public virtual PROYECTO PROYECTO { get; set; }
        public virtual ROLE ROLE { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
