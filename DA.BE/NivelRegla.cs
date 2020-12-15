namespace DA.BE
{
    [Tabla("NivelRegla")]
    public class NivelRegla : EntidadBase
    {
        public Categoria Categoria
        {
            [Columna("IdCategoria", "Categoria", typeof(int), false, false)]
            get;
            set;
        }

        public TipoArbitro TipoArbitro
        {
            [Columna("IdTipoArbitro", "TipoArbitro", typeof(int), false, false)]
            get;
            set;
        }


    }
}
