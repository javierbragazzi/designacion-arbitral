namespace DA.BE
{
    [Tabla("TipoArbitro")]
    public class TipoArbitro : EntidadBase
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
            return Equals((TipoArbitro)obj);
        }
     
        protected bool Equals(TipoArbitro other)
        {
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(TipoArbitro left, TipoArbitro right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TipoArbitro left, TipoArbitro right)
        {
            return !Equals(left, right);
        }
    }
}
