namespace DA.BE
{
 [Tabla("Genero")]
    public class Genero : EntidadBase
    {
        public string Descripcion
        {
            [Columna("Descripcion", "Descripcion", typeof(string), false, false)]
            get;
            set;
        }

    }
}
