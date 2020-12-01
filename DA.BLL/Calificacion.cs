using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Calificacion
    {
        /// <summary>
        /// Dal manager Calificacion
        /// </summary>
        private readonly DAL.Calificacion _dalManagerCalificacion = new DAL.Calificacion();

        /// <summary>
        /// Agrega un nuevo Calificacion al sistema.
        /// </summary>
        /// <param name="pCalificacion">Calificacion a agregar.</param>
        /// <param name="pPartido"></param>
        /// <param name="idArbitro"></param>
        /// <param name="idTipoArbitro"></param>
        /// <returns></returns>
        public Resultado Agregar(BE.Calificacion pCalificacion, BE.Partido pPartido, int idArbitro, int idTipoArbitro)
        {
            var resultado = _dalManagerCalificacion.Insertar(pCalificacion, pPartido, idArbitro, idTipoArbitro);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta la calificación.");
        }

        /// <summary>
        /// Edita un Calificacion.
        /// </summary>
        /// <param name="pCalificacion">Calificacion a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Calificacion pCalificacion)
        {
            ResultadoBd resultado = _dalManagerCalificacion.Actualizar(pCalificacion);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar la calificación.");
        }

        /// <summary>
        /// Quita un Calificacion.
        /// </summary>
        /// <param name="pCalificacion">Calificacion a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Calificacion pCalificacion)
        {
            ResultadoBd resultado = _dalManagerCalificacion.Borrar(pCalificacion);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar la calificación.");

        }

        public BE.Calificacion ObtenerCalificacionPorId(int idCalificacion)
        {
            BE.Calificacion beCalificacion = _dalManagerCalificacion.ObtenerCalificacionPorId(idCalificacion);

            return beCalificacion;
        }


    }
}
