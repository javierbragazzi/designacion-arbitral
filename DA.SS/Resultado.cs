namespace DA.SS
{
    public class Resultado
    {
        public bool HayError { get; set; }

        public string Descripcion { get; set; }

        public TipoMensaje TipoMensaje { get; set; }

        public string Titulo { get; set; }  

        public Resultado(bool hayError, string descripcion)
        {
            HayError = hayError;
            Descripcion = descripcion;
        }


        public Resultado(bool hayError, string descripcion, TipoMensaje tipoMensaje, string titulo)
        {
            HayError = hayError;
            Descripcion = descripcion;
            TipoMensaje = tipoMensaje;
            Titulo = titulo;
        }
    }
}
