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
    
    public partial class USUARIO
    {
        public USUARIO()
        {
            this.CASOS_USOS = new HashSet<CASOS_USOS>();
            this.INTEGRANTES = new HashSet<INTEGRANTE>();
            this.REQUERIMIENTOS = new HashSet<REQUERIMIENTO>();
            this.REQUERIMIENTOS1 = new HashSet<REQUERIMIENTO>();
        }
    
        public decimal ID { get; set; }
        public string EMAIL { get; set; }
        public string CONTRASENA { get; set; }
        public string ESTADO { get; set; }
    
        public virtual ICollection<CASOS_USOS> CASOS_USOS { get; set; }
        public virtual ICollection<INTEGRANTE> INTEGRANTES { get; set; }
        public virtual ICollection<REQUERIMIENTO> REQUERIMIENTOS { get; set; }
        public virtual ICollection<REQUERIMIENTO> REQUERIMIENTOS1 { get; set; }
    }
}
