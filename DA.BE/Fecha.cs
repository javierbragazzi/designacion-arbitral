using System;
using System.Collections.Generic;

namespace DA.BE
{
    [Tabla("Fecha")]
    public class Fecha : EntidadBase
    {
        public string Nombre
        {
            [Columna("Nombre", "Nombre", typeof(string), false, false)]
            get;
            set;
        }

        public int Numero
        {
            [Columna("Numero", "Numero", typeof(int), false, false)]
            get;
            set;
        }

        public DateTime? FechaDesde
        {
            [Columna("FechaDesde", "FechaDesde", typeof(DateTime?), false, false)]
            get;
            set;
        }

        public DateTime? FechaHasta
        {
            [Columna("FechaHasta", "FechaHasta", typeof(DateTime?), false, false)]
            get;
            set;
        }

        public bool Designado
        {
            [Columna("Designado", "Designado", typeof(bool), false, false)]
            get;
            set;
        }

        public Fixture Fixture
        {
            [Columna("IdFixture", "Fixture", typeof(int), false, false)]
            get;
            set;
        }

        public string NombreParaMostrar { get; set; }

        public List<Partido> Partidos = new List<Partido>();

        protected bool Equals(Fecha other)
        {
            return Id == other.Id && string.Equals(Nombre, other.Nombre, StringComparison.InvariantCultureIgnoreCase) && Numero == other.Numero;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Fecha)) return false;
            return Equals((Fecha) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Nombre != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(Nombre) : 0);
                hashCode = (hashCode * 397) ^ Numero;
                return hashCode;
            }
        }

        public static bool operator ==(Fecha left, Fecha right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Fecha left, Fecha right)
        {
            return !Equals(left, right);
        }

 }
}
