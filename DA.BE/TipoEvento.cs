namespace DA.BE
{
  
    [Tabla("TipoEvento")]
    public class TipoEvento : EntidadBase
    {
        public string Descripcion
        {
            [Columna("Descripcion", "Descripcion", typeof(string), false, false)]
            get;
            set;
        }

    }
}
