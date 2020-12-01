namespace DA.BE
{
    [Tabla("Resguardo")]
    public class Resguardo : EntidadBase
    {
   
        public string NombreArchivo
        {
            [Columna("NombreArchivo", "NombreArchivo", typeof(string), false, false)]
            get;
            set;
        }

        public string Directorio
        {
            [Columna("Directorio", "Directorio", typeof(string), false, false)]
            get;
            set;
        }
    }
}
