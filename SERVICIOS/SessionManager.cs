using BE;
using System;

namespace SERVICES
{
    public class SessionManager
    {
        #region Atributos
        private BE_User _user;
        public BE_User User { get => _user; set => _user = value; }

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

        private static readonly object _sessionLock = new object();
        #endregion

        #region Métodos
        public static void Login(BE_User user)
        {
            lock (_sessionLock)
            {
                if (_session == null)
                {
                    _session = new SessionManager
                    {
                        _user = user,
                        StartDate = DateTime.Now
                    };
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
