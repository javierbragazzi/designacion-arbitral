
namespace DA.BE
{
    [Tabla("ArbitroAud")]
    public class ArbitroAud : Arbitro
    {

        public int IdBitacora
        {

            [Columna("idBitacora", "idBitacora", typeof(int), false, false)]
            get;
            set;
        }
        public int IdArbitro
        {

            [Columna("idArbitro", "idArbitro", typeof(int), false, false)]
            get;
            set;
        }

    

    }
}
