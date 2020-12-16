using System;

namespace DA.BE
{
    [Tabla("Deporte")]
    public class Deporte : EntidadBase, IComparable<Deporte>
    {
        public string Descripcion
        {
            [Columna("Descripcion", "Descripcion", typeof(string), false, false)]
            get;
            set;
        }

        public int CompareTo(Deporte other)
        {
            return String.Compare(this.Descripcion, other.Descripcion, StringComparison.CurrentCulture);

        }
    }
}
