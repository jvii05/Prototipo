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
    
    public partial class DETALLE_TIPOS
    {
        public DETALLE_TIPOS()
        {
            this.CASO_USO_DETALLES = new HashSet<CASO_USO_DETALLES>();
            this.PROYECTO_DETALLES = new HashSet<PROYECTO_DETALLES>();
            this.REQUERIMIENTO_DETALLES = new HashSet<REQUERIMIENTO_DETALLES>();
        }
    
        public decimal ID { get; set; }
        public string NOMBRE { get; set; }
    
        public virtual ICollection<CASO_USO_DETALLES> CASO_USO_DETALLES { get; set; }
        public virtual ICollection<PROYECTO_DETALLES> PROYECTO_DETALLES { get; set; }
        public virtual ICollection<REQUERIMIENTO_DETALLES> REQUERIMIENTO_DETALLES { get; set; }
    }
}
