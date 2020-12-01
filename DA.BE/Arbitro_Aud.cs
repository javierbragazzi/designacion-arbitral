
namespace DA.BE
{
    [Tabla("Arbitro_Aud")]
    public class Arbitro_Aud : Arbitro
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
