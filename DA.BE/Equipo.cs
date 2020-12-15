namespace DA.BE
{
    [Tabla("Equipo")]
    public class Equipo : EntidadBase
    {
        public string Nombre
        {
            [Columna("Nombre", "Nombre", typeof(string), false, false)]
            get;
            set;
        }

        public int? Ponderacion
        {
            [Columna("Ponderacion", "Ponderacion", typeof(int?), false, false)]
            get;
            set;
        }

        public Categoria Categoria
        {
            [Columna("IdCategoria", "Categoria", typeof(int), false, false)]
            get;
            set;
        }

        public Equipo()
        {
            Ponderacion = null;
        }
        

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Equipo)) return false;
            return Equals((Equipo)obj);
        }
        
        protected bool Equals(Equipo other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Equipo left, Equipo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Equipo left, Equipo right)
        {
            return !Equals(left, right);
        }
    }
}
