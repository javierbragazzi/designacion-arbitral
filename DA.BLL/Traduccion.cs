using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Traduccion
    {
        private readonly DAL.Traduccion _dalManagerTraduccion = new DAL.Traduccion();

        public Resultado Agregar(BE.Traduccion pTraduccion, int idIdioma, int idLeyenda)
        {
            var resultado = _dalManagerTraduccion.Insertar(pTraduccion, idIdioma, idLeyenda);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Traduccion.");
        }

        public Resultado Editar(BE.Traduccion pTraduccion)
        {
            ResultadoBd resultado = _dalManagerTraduccion.Actualizar(pTraduccion);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Traduccion.");
        }

        public Resultado Quitar(BE.Traduccion pTraduccion)
        {
            ResultadoBd resultado = _dalManagerTraduccion.Borrar(pTraduccion);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Traduccion.");

        }

        public List<BE.Traduccion> ObtenerTraduccions()
        {
            List<BE.Traduccion> lstTraduccions = _dalManagerTraduccion.Leer();

            return lstTraduccions;
        }
    }
}
