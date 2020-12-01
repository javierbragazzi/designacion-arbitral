using System.Collections.Generic;

namespace DA.BE
{
    [Tabla("Fixture")]
    public class Fixture : EntidadBase
    {
        public string Descripcion
        {
            [Columna("Descripcion", "Descripcion", typeof(string), false, false)]
            get;
            set;
        }

        public List<Fecha> Fechas { get; set; }
    }
}
