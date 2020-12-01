namespace DA.BE
{
    [Tabla("Campeonato")]
    public class Campeonato : EntidadBase
    {
        public string Descripcion
        {
            [Columna("Descripcion", "Descripcion", typeof(string), false, false)]
            get;
            set;
        }

        public Fixture Fixture
        {
            [Columna("IdFixture", "Fixture", typeof(int), false, false)]
            get;
            set;
        }

        public Categoria Categoria
        {
            [Columna("IdCategoria", "Categoria", typeof(int), false, false)]
            get;
            set;
        }
    }
}
