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
    
    public partial class zestawWycieczek_Result
    {
        public int IdWycieczki { get; set; }
        public int IdPlacowki { get; set; }
        public int IdHotelu { get; set; }
        public string Panstwo { get; set; }
        public string Miasto { get; set; }
        public Nullable<System.DateTime> Datawycieczki { get; set; }
        public Nullable<int> Wydatki { get; set; }
        public Nullable<int> Cena { get; set; }
        public Nullable<System.DateTime> KoniecWycieczki { get; set; }
        public Nullable<System.DateTime> DataWplaty { get; set; }
    }
}