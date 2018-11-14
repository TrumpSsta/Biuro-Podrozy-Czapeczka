using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BiuroPodrozyCzapeczka.Models
{
    public class PracownikModel
    {
        public int IdPracownika { get; set; }

        [Required]
        public string  IdPlacowki{ get; set; }

        [Required(ErrorMessage = "Imie nie może być puste")]
        [MinLength(3, ErrorMessage = "Minimalna długość Imienia wynosi 2")]

        [RegularExpression(
@"^[a-zA-Z\s]+$",
       ErrorMessage = "Podaj poprawne imie")]
            public string Imie { get; set; }
        
        [Required(ErrorMessage = "Nazwisko nie może być puste")]
        [MinLength(3, ErrorMessage = "Minimalna długość nazwiska wynosi 2")]
        [RegularExpression(
@"^[a-zA-Z\s]+$",
       ErrorMessage = "Podaj poprawne nazwisko")]
        public string Nazwisko { get; set; }
        [Phone]
        public string telefon { get; set; }

       
        [EmailAddress]
        public string Email { get; set; }
       
        [Range(1500, 8000)]
        public int   Pensja{ get; set; }

       

    }
}