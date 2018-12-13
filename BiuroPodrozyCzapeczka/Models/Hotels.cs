using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BiuroPodrozyCzapeczka.Models
{
    public class Hotels
    {
        [Key]
        [Required]
        public int IdHotelu { get; set; }


        [Required(ErrorMessage = "Imie nie może być puste")]
        [MinLength(3, ErrorMessage = "Minimalna długość Nazwy Hotelu wynosi 2")]


        public string Nazwahotelu { get; set; }


        [Required(ErrorMessage = "Imie nie może być puste")]
        [MinLength(3, ErrorMessage = "Minimalna długość Nazwy Atrakcji wynosi 2")]


        public string Panstwo { get; set; }



        [Required(ErrorMessage = "Imie nie może być puste")]
        [MinLength(3, ErrorMessage = "Minimalna długość Nazwy Atrakcji wynosi 2")]
         public string Miasto { get; set; }

        [Required]
        public int Adres { get; set; }
    }
}