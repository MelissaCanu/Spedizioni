using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spedizioni.Models
{
    public class Cliente
    {   

        public int IDCliente { get; set; }

        [Display(Name = "Inserisci il nome o il nominativo dell'azienda")]
        [Required(ErrorMessage = "Il campo Nome/Nominativo è obbligatorio")]
        public string NomeNominativo { get; set; }

        public bool IsAzienda { get; set; }

        [Display(Name = "Inserisci il tuo codice fiscale" )]
        public string CodFisc { get; set; }

        [Display(Name = "Inserisci la tua P.Iva")]
        public string PIva {  get; set; }
    }
}