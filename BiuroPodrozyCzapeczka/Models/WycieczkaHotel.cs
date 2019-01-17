using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiuroPodrozyCzapeczka.Models
{
    public class WycieczkaHotel
    {
        public int IdWycieczki { get; set; }
        public Nullable<int> Cena { get; set; }
        public string NazwaHotelu { get; set; }
        public string Panstwo { get; set; }

    }
}