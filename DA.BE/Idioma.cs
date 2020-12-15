using System.Collections.Generic;
using DA.BE.Observer;

namespace DA.BE
{
    [Tabla("Idioma")]
    public class Idioma : EntidadBase
    {
        public string Descripcion
        {
            [Columna("Descripcion", "Descripcion", typeof(string), false, false)]
            get;
            set;
        }

        public List<Leyenda> Leyendas { get; set; }

        public IdiomaSubject IdiomaSubject { get; set; }

        public Idioma()
        {
            IdiomaSubject = new IdiomaSubject();
        }
    }
}
