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
    
    public partial class Placowka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Placowka()
        {
            this.Pracownik = new HashSet<Pracownik>();
            this.Wycieczka = new HashSet<Wycieczka>();
        }
    
        public int IdPlacowki { get; set; }
        public string Wojewodztwo { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string Numer { get; set; }
        public Nullable<int> IloscPracownikow { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pracownik> Pracownik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wycieczka> Wycieczka { get; set; }
    }
}
