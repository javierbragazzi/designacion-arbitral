namespace DA.BE
{
    [Tabla("Categoria")]
    public class Categoria : EntidadBase
    {
        public string Descripcion
        {
            [Columna("Descripcion", "Descripcion", typeof(string), false, false)]
            get;
            set;
        }

        public Deporte Deporte
        {
            [Columna("IdDeporte", "Deporte", typeof(int), false, false)]
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Categoria)) return false;
            return Equals((Categoria)obj);
        }

        protected bool Equals(Categoria other)
        {
            return this.Id == other.Id;
        }


        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Categoria left, Categoria right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Categoria left, Categoria right)
        {
            return !Equals(left, right);
        }

    }
}
