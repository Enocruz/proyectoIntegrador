//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoIntegrador.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class IDENTIFICACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IDENTIFICACION()
        {
            this.RESULTADOS = new HashSet<RESULTADOS>();
        }
    
        public int idIdentificacion { get; set; }
        public int idSubcaso { get; set; }
        public string Detalle { get; set; }
        public Nullable<System.DateTime> Fecha_guardado { get; set; }
    
        public virtual SUBCASO SUBCASO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESULTADOS> RESULTADOS { get; set; }
    }
}
