using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCredentials
{
    public class UserSession
    {
        private static readonly UserSession _instance = new UserSession();

        private UserSession()
        {
        }

        public static UserSession Instance
        {
            get { return _instance; }
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
        public string id { get; set; }
        public bool Session { get; set; } = false;

        public void ClearSession()
        {
            Username = null;
            Password = null;
            Rol = null;
            Email = null;
            id = null;
            Session = false;
        }
    }
}
