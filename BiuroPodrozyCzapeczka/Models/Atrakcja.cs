//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiuroPodrozyCzapeczka.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Atrakcja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Atrakcja()
        {
            this.Zwiedzanie = new HashSet<Zwiedzanie>();
        }
    
        public int IdAtrakcji { get; set; }
        public string NazwaAtrakcji { get; set; }
        public string AdresAtrakcji { get; set; }
        public Nullable<int> CenaAtrakcji { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zwiedzanie> Zwiedzanie { get; set; }
    }
}
