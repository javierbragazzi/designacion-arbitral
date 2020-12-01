using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DA.BE;
using DA.BE.Observer;

namespace DA.SS
{
    public class SingletonIdioma
    {
        //private static SingletonIdioma _instance;

        //public IdiomaSubject IdiomaSubject { get; set; }

        //private SingletonIdioma()
        //{
        //    IdiomaSubject = new IdiomaSubject();
        //}

        //public static SingletonIdioma GetInstance()
        //{
        //    if (_instance != null)
        //        return _instance;
        //    else
        //    {
        //        _instance = new SingletonIdioma();
        //        return _instance;
        //    }
        //}

        /// <summary>
        /// Instancia
        /// </summary>
        private static readonly SingletonIdioma _instancia = new SingletonIdioma();

        /// <summary>
        /// Sesion
        /// </summary>
        public IdiomaSubject IdiomaSubject { get; set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="ManejadorSesion" /> class from being created.
        /// </summary>
        private SingletonIdioma()
        {
            IdiomaSubject = new IdiomaSubject();
        }

        /// <summary>
        /// Gets the instancia.
        /// </summary>
        /// <value>
        /// The instancia.
        /// </value>
        public static SingletonIdioma Instancia
        {
            get { return _instancia; }
        }

        public static IEnumerable<T> FindWindowChildren<T>(DependencyObject dObj) where T : DependencyObject
        {
            if (dObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dObj); i++)
                {
                    DependencyObject ch = VisualTreeHelper.GetChild(dObj, i);


                    if (ch != null && ch is T)
                    {
                        yield return (T) ch;
                    }

                    foreach (T nestedChild in FindWindowChildren<T>(ch))
                    {
                        yield return nestedChild;
                    }
                }
            }


        }

        public string ObtenerTraduccion(string etiqueta)
        {
            var idioma = Instancia.IdiomaSubject.Idioma;
            
            if (idioma != null)
            {
                //string traduccion = idioma.Leyendas.Find(delegate (Leyenda leye) { return leye.Etiqueta.Equals(etiqueta); }).Traduccion.TextoTraducido;
                BE.Leyenda leyenda = idioma.Leyendas.Find(delegate(Leyenda leye)
                {
                    return leye.Etiqueta.Equals(etiqueta);
                });

               // string traduccion = idioma.Leyendas.Find(delegate (Leyenda leye) { return leye.Etiqueta.Equals(etiqueta); }).Traduccion.TextoTraducido;
                if (leyenda == null)
                {
                    return "No se encontro la etiqueta";
                }
                else
                {
                    return leyenda.Traduccion.TextoTraducido;
                }
                
            }
            else
            {
                return "No se cargo el idioma";
            }
        }
    }
}
