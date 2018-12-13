using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiuroPodrozyCzapeczka.Models
{
    public class KlientUdzialViewModel
    {
        public IEnumerable<Klient> Klient { get; set; }
        public Klient Klient1 { get; set; }
        public IEnumerable<Udzial> Udzial { get; set; }
        public Udzial Udzial1 { get; set; }
        public KlientUdzialViewModel(IEnumerable<Klient> Klient, IEnumerable<Udzial> Udzial)
        {
            this.Klient = Klient;
            this.Udzial = Udzial;
          
        }

        public KlientUdzialViewModel()
        {
        }
        public KlientUdzialViewModel(int i)
        {
        }
    }
}