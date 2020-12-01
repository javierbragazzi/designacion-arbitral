namespace DA.BE
{
    [Tabla("NivelRegla")]
    public class NivelRegla : EntidadBase
    {
        //public string NombreNivel
        //{
        //    [Columna("NombreNivel", "NombreNivel", typeof(string), false, false)]
        //    get;
        //    set;
        //}

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
