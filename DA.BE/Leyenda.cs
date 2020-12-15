namespace DA.BE
{
    [Tabla("Leyenda")]
    public class Leyenda : EntidadBase
    {
        public string Etiqueta
        {
            [Columna("Etiqueta", "Etiqueta", typeof(string), false, false)]
            get;
            set;
        }

        public Traduccion Traduccion { get; set; }

        public Leyenda()
        {
            Traduccion = new Traduccion();
        }
    }
}
