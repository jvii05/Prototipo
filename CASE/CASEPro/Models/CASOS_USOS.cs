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
    
    public partial class CASOS_USOS
    {
        public CASOS_USOS()
        {
            this.CASO_USO_DEPENDENCIAS = new HashSet<CASO_USO_DEPENDENCIAS>();
            this.CASO_USO_DEPENDENCIAS1 = new HashSet<CASO_USO_DEPENDENCIAS>();
            this.CASO_USO_DETALLES = new HashSet<CASO_USO_DETALLES>();
            this.REQUERIMIENTOS = new HashSet<REQUERIMIENTO>();
        }
    
        public decimal ID { get; set; }
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public string CONTEXTO { get; set; }
        public decimal IMPORTANCIA { get; set; }
        public string CURSONORMAL { get; set; }
        public decimal CREADOR_ID { get; set; }
    
        public virtual ICollection<CASO_USO_DEPENDENCIAS> CASO_USO_DEPENDENCIAS { get; set; }
        public virtual ICollection<CASO_USO_DEPENDENCIAS> CASO_USO_DEPENDENCIAS1 { get; set; }
        public virtual ICollection<CASO_USO_DETALLES> CASO_USO_DETALLES { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        public virtual ICollection<REQUERIMIENTO> REQUERIMIENTOS { get; set; }
    }
}
