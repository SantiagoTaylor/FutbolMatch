﻿using System.Collections.Generic;
using System.Web.UI;

namespace SERVICES.Languages
{
    public static class ObservableLanguage
    {
        private static int currentLanguage = SessionManager.GetInstance.User.Language;

        private static List<IObserver> observers = new List<IObserver>();

        public static int CurrentLanguage
        {
            get { return currentLanguage; }
            set
            {
                currentLanguage = value;
                NotifyObservers();
            }
        }

        public static void Attach(IObserver observer)//identificar mejor al form, porque es un objeto
        {
            if (!observers.Exists(o => o.Equals(observer)))
            {
                observers.Add(observer);
                observer.Translate();
            }
        }

        public static void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        private static void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Translate();
            }
        }
    }
}
