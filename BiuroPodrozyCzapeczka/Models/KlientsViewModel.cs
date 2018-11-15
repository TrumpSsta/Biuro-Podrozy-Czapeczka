using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BiuroPodrozyCzapeczka.Models
{
    public class KlientsViewModel
    {
        [Required]
        public int IdKlienta { get; set; }


        [Required(ErrorMessage = "Imie nie może być puste")]
        [MinLength(3, ErrorMessage = "Minimalna długość Imienia wynosi 2")]
        [RegularExpression(
@"^[a-zA-Z\s]+$",
       ErrorMessage = "Podaj poprawne imie")]
        public string Imię { get; set; }

        [Required(ErrorMessage = "Nazwisko nie może być puste")]
        [MinLength(3, ErrorMessage = "Minimalna długość nazwiska wynosi 2")]
        [RegularExpression(
@"^[a-zA-Z\s]+$",
       ErrorMessage = "Podaj poprawne nazwisko")]
        public string Nazwisko { get; set; }
        [EmailAddress]
        public string Mail { get; set; }


        [Phone]
        public string Telefon { get; set; }
        
        public int Suma { get; set; }
    }
}