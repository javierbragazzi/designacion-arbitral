namespace DA.BE
{
    [Tabla("Traduccion")]
    public class Traduccion : EntidadBase
    {
        public string TextoTraducido
        {
            [Columna("TextoTraducido", "TextoTraducido", typeof(string), false, false)]
            get;
            set;
        }
    }
}
