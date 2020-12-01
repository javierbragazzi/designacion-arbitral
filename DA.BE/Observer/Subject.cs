using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BE.Observer
{
    public abstract class Subject
    {
        private static List<IObserverIdioma> _observers = new List<IObserverIdioma>();

        public static void AddObserver(IObserverIdioma observer)
        {
            _observers.Add(observer);
        }


        public static void RemoveObserver(IObserverIdioma observer)
        {
            _observers.Remove(observer);
        }

        public static void Notify(IdiomaSubject idioma)
        {
            foreach (var observer in _observers)
                observer.Update(idioma);
        }
    }
}
