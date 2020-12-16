namespace DA.BE
{

    [Tabla("DVV")]
    public class DVV : EntidadBase
    {

        public string NombreTabla
        {
            [Columna("NombreTabla", "NombreTabla", typeof(string), false, false)]
            get;
            set;
        }

        public string Valor
        {
            [Columna("Valor", "Valor", typeof(string), false, false)]
            get;
            set;
        }

    }
}
