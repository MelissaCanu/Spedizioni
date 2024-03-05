using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spedizioni.Models;

namespace Spedizioni.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente - view per inserire nuovo cliente
        public ActionResult NuovoCliente()
        {   
            return View();
        }

        //POST: Cliente - ricevo i dati inviati dal form, valido e salvo in db
        //se success reindirizzo a pagina di conferma
        [HttpPost]
        public ActionResult NuovoCliente(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                //salvo nuovo cliente nel db


                //reindirizzo a pagina di conferma
                return RedirectToAction("ClienteSalvato");
            }
            //se il modello non è valido, torno alla view con i dati inseriti
            return View(cliente); 
        }

        //GET: Cliente/ClienteSalvato
        public ActionResult ClienteSalvato()
        {
            //pagina di conferma per il salvataggio del cliente 
            return View();
        }

        //aggiungi logica controllo codice fiscale e partita iva
    }
}