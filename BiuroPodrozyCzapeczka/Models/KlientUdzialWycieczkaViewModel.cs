using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiuroPodrozyCzapeczka.Models
{
    public class KlientUdzialWycieczkaViewModel
    {
        public Klient Klient { get; set; }
        public List<Udzial> Udzial { get; set; }
        public List<Wycieczka> Wycieczka { get; set; }
        public KlientUdzialWycieczkaViewModel(Klient Klient,List<Udzial>Udzial,List<Wycieczka>Wycieczka)
        {
            this.Klient = Klient;
            this.Udzial = Udzial;
            this.Wycieczka = Wycieczka;
        }
    }
}