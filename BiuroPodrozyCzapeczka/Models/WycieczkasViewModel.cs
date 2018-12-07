using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiuroPodrozyCzapeczka.Models
{
    public class WycieczkasViewModel
    {
        public int IdWycieczki { get; set; }
        public int IdPlacówki { get; set; }
        public int IdHotelu { get; set; }
        public string Panstwo { get; set; }
        public string Miasto { get; set; }
        public DateTime DataWycieczki { get; set; }
        public int Wydatki { get; set; }
        public int Cena { get; set; }
        public DateTime KoniecWycieczki { get; set; }
        public DateTime DataWplaty { get; set; }
    }
}