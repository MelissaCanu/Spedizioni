using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace Spedizioni.Models { 

//Questo codice implementa il metodo GetRolesForUser per recuperare i ruoli di un utente dal database. Tutti gli altri metodi astratti del RoleProvider sono implementati per restituire un'eccezione NotImplementedException, il che significa che non sono attualmente supportati. Se in futuro decidi di utilizzare una di queste funzionalità, dovrai implementare il metodo corrispondente.

  //Per utilizzare il provider di ruoli personalizzato, devi aggiungere una sezione <roleManager> al file Web.config. Questa sezione deve includere un attributo defaultProvider che specifica il nome del provider di ruoli personalizzato. Inoltre, devi aggiungere un elemento <providers> che contiene un elemento <add> per il provider di ruoli personalizzato.
    public class CustomRoleProvider : RoleProvider
    {   
        //Questo metodo restituisce un array di ruoli per un utente specificato.
        //Il metodo accetta un parametro username e restituisce un array di stringhe che rappresentano i ruoli dell'utente.
        //Il metodo esegue una query SQL per recuperare i ruoli dell'utente dal database e restituisce i risultati come un array di stringhe.
        public override string[] GetRolesForUser(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Ruolo FROM Utenti WHERE Username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            List<string> roles = new List<string>();
                            while (reader.Read())
                            {
                                roles.Add(reader["Ruolo"].ToString());
                            }
                            return roles.ToArray();
                        }
                        else
                        {
                            return new string[] { };
                        }
                    }
                }
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
