using BE;
using System;

namespace SERVICES
{
    public class SessionManager
    {
        #region Atributos
        private BE_Login _userLogin;
        public BE_Login UserLogin { get => _userLogin; set => _userLogin = value; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private static SessionManager _session;

        public static SessionManager GetInstance
        {
            get
            {
                if (_session == null)
                {
                    throw new Exception("La sesión no está iniciada.");
                }
                return _session;
            }
        }

        private static object _sessionLock = new object();
        #endregion

        #region Métodos
        public static void Login(BE_Login login)
        {
            lock (_sessionLock)
            {
                if (_session == null)
                {
                    _session = new SessionManager();
                    _session._userLogin = login;
                    _session.StartDate = DateTime.Now;
                }
                else
                {
                    throw new Exception("La sesión ya está iniciada.");
                }
            }
        }

        public static void Logout()
        {
            lock (_sessionLock)
            {
                if (_session != null)
                {
                    _session = null;
                }
                else
                {
                    throw new Exception("La sesión no está iniciada.");
                }
            }
        }
        #endregion
    }
}
