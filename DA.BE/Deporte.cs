namespace DA.BE
{
    [Tabla("Deporte")]
    public class Deporte : EntidadBase
    {
        public string Descripcion
        {
            [Columna("Descripcion", "Descripcion", typeof(string), false, false)]
            get;
            set;
        }
    }
}
