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
    
    public partial class LICENCIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LICENCIA()
        {
            this.USUARIO = new HashSet<USUARIO>();
        }
    
        public int idLicencia { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> Costo { get; set; }
        public Nullable<int> Creditos { get; set; }
        public string Renovacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }
    }
}
