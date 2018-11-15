using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BiuroPodrozyCzapeczka.Models
{
    public class AtrakcjasCreateViewModel
    {
        [Required]
        public int IdAtrakcji { get; set; }


        [Required(ErrorMessage = "Imie nie może być puste")]
        [MinLength(3, ErrorMessage = "Minimalna długość Nazwy Atrakcji wynosi 2")]

       
        public string NazwaAtrakcji { get; set; }


        [Required(ErrorMessage = "Imie nie może być puste")]
        [MinLength(3, ErrorMessage = "Minimalna długość Nazwy Atrakcji wynosi 2")]


        public string AdresAtrakcji { get; set; }

        

        [Range(0, 4000)]
        public int CenaAtrakcji { get; set; }
        [Required]
        public int IdZwiedzania { get; set; }

    }

    public class AtrakcjasEditViewModel
    {
        [Required]
        public int IdAtrakcji { get; set; }


        [Required(ErrorMessage = "Imie nie może być puste")]
        [MinLength(3, ErrorMessage = "Minimalna długość Nazwy Atrakcji wynosi 2")]


        public string NazwaAtrakcji { get; set; }


        [Required(ErrorMessage = "Imie nie może być puste")]
        [MinLength(3, ErrorMessage = "Minimalna długość Nazwy Atrakcji wynosi 2")]


        public string AdresAtrakcji { get; set; }



        [Range(0, 4000)]
        public int CenaAtrakcji { get; set; }
        [Required]
        public int IdZwiedzania { get; set; }

    }
}