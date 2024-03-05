using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spedizioni.Models
{
    public class Utente
    {
        public int IDUtente { get; set; }
        [Required(ErrorMessage = "Il campo Username è obbligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "L'username deve essere compreso tra i 3 e i 50 caratteri")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Il campo Password è obbligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Ruolo { get; set; } // Aggiungi una proprietà Role

    }
}