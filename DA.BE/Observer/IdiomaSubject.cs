using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.BE.Observer
{
    public class IdiomaSubject : Subject
    {
        private string _descripcion;

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
                Notify(this);
            }
        }

        public Idioma Idioma { get; set; }
    }
}
