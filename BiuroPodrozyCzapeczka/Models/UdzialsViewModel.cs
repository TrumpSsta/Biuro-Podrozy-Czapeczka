using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiuroPodrozyCzapeczka.Models
{
    public class UdzialsViewModel
    {
        public int IdUdziału { get; set; }
        public int IdWycieczki { get; set; }
        public int IdKlienta { get; set; }
        public int IloscOsob { get; set; }
        public int Wplacone { get; set; }
    }
}