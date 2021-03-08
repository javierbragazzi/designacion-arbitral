
namespace DA.BE
{
    [Tabla("ArbitroAud")]
    public class ArbitroAud : Arbitro
    {

        public BE.Bitacora Bitacora
        {

            [Columna("IdBitacora", "Bitacora", typeof(long), false, false)]
            get;
            set;
        }

        //public int IdArbitro
        //{

        //    [Columna("idArbitro", "idArbitro", typeof(int), false, false)]
        //    get;
        //    set;
        //}

    

    }
}
