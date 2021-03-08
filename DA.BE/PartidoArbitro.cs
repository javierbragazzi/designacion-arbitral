namespace DA.BE
{
 
    [Tabla("PartidoArbitro")]
    public class PartidoArbitro : EntidadBase
    {
        public Partido Partido
        {
            [Columna("IdPartido", "Partido", typeof(long), false, false)]
            get;
            set;
        }

        public Arbitro Arbitro
        {
            [Columna("IdArbitro", "Arbitro", typeof(long), false, false)]
            get;
            set;
        }

        public TipoArbitro TipoArbitro
        {
            [Columna("IdTipoArbitro", "TipoArbitro", typeof(long), false, false)]
            get;
            set;
        }

        public Calificacion Calificacion
        {
            [Columna("IdCalificacion", "Calificacion", typeof(long), false, false)]
            get;
            set;
        }

        public bool? Procesado
        {
            [Columna("Procesado", "Procesado", typeof(bool?), false, false)]
            get;
            set;
        }


    }
}
