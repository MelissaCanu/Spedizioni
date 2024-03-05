using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Spedizioni.Models;

namespace Spedizioni.Controllers
{
    public class SpedizioneController : Controller
    {

        // GET: Spedizione - view per inserire nuova spedizione
        public ActionResult NuovaSpedizione()
        {
            return View();
        }

        //POST: Spedizione - ricevo i dati inviati dal form, valido e salvo in db
        //se success reindirizzo a pagina di conferma
        [HttpPost]
        //ValidateAntiForgeryToken per evitare attacchi CSRF (Cross-Site Request Forgery)
        [ValidateAntiForgeryToken] //poi aggiungo @Html.AntiForgeryToken() nella view


        //Bind: specifico quali campi del modello posso ricevere dal form (per evitare attacchi di overposting)
        public ActionResult NuovaSpedizione([Bind(Include = "IDCliente,DataSpedizione,Peso,NominativoDestinatario,CostoSpedizione,CittaDestinazione,IndirizzoDestinatario,DataConsegnaPrevista")] Spedizione spedizione)
        {
            if (ModelState.IsValid)
            {
                //salvo nuova spedizione nel db


                //reindirizzo a pagina di conferma
                return RedirectToAction("SpedizioneSalvata");
            }
            //se il modello non è valido, torno alla view con i dati inseriti
            return View(spedizione);
        }

        //GET: Spedizione/SpedizioneSalvata
        public ActionResult SpedizioneSalvata()
        {
            //pagina di conferma per il salvataggio del cliente 
            return View();
        }

        [HttpPost]

        //controllo che la data sia maggiore a quella odierna
        public JsonResult IsValidData(DateTime DataSpedizione)
        {
            bool isValid = DataSpedizione >= DateTime.Today;
            return Json(isValid, JsonRequestBehavior.AllowGet);
        }

        //controllo che la data di consegna stimata sia maggiore a quella odierna
        public JsonResult IsValidData2(DateTime DataConsegnaPrevista)
        {
            bool isValid = DataConsegnaPrevista >= DateTime.Today;
            return Json(isValid, JsonRequestBehavior.AllowGet);
        }

    }
}