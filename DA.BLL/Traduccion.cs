using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Traduccion
    {
            /// <summary>
        /// Dal manager Traduccion
        /// </summary>
        private readonly DAL.Traduccion _dalManagerTraduccion = new DAL.Traduccion();

        /// <summary>
        /// Agrega un nuevo Traduccion al sistema.
        /// </summary>
        /// <param name="pTraduccion">Traduccion a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Traduccion pTraduccion)
        {
            var resultado = _dalManagerTraduccion.Insertar(pTraduccion);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Traduccion.");
        }

        /// <summary>
        /// Edita un Traduccion.
        /// </summary>
        /// <param name="pTraduccion">Traduccion a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Traduccion pTraduccion)
        {
            ResultadoBd resultado = _dalManagerTraduccion.Actualizar(pTraduccion);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Traduccion.");
        }

        /// <summary>
        /// Quita un Traduccion.
        /// </summary>
        /// <param name="pTraduccion">Traduccion a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Traduccion pTraduccion)
        {
            ResultadoBd resultado = _dalManagerTraduccion.Borrar(pTraduccion);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Traduccion.");

        }

        /// <summary>
        /// Obtiene todos los Traduccions.
        /// </summary>
        /// <returns></returns>
        public List<BE.Traduccion> ObtenerTraduccions()
        {
            List<BE.Traduccion> lstTraduccions = _dalManagerTraduccion.Leer();

            return lstTraduccions;
        }
    }
}
