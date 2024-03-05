using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Spedizioni.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            System.Diagnostics.Debug.WriteLine($"Tentativo di login con username: {username}");

            if (Membership.ValidateUser(username, password))
            {
                System.Diagnostics.Debug.WriteLine("Validazione utente riuscita.");

                FormsAuthentication.SetAuthCookie(username, false);
                string[] roles = Roles.GetRolesForUser(username);

                System.Diagnostics.Debug.WriteLine($"Ruoli per l'utente {username}: {string.Join(", ", roles)}");

                if (roles.Contains("admin"))
                {
                    return RedirectToAction("AdminHome", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Validazione utente fallita.");
                return RedirectToAction("LoginFailed");
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult LoginFailed()
        {
            ViewBag.Message = "Login failed. Please try again.";
            return View();
        }

    }
}
