using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Deporte
    {
         /// <summary>
        /// Dal manager Deporte
        /// </summary>
        private readonly DAL.Deporte _dalManagerDeporte = new DAL.Deporte();

   
        /// <summary>
        /// Agrega un nuevo Deporte al sistema.
        /// </summary>
        /// <param name="pDeporte">Deporte a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Deporte pDeporte)
        {
            var resultado = _dalManagerDeporte.Insertar(pDeporte);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Deporte.");
        }

        /// <summary>
        /// Edita un Deporte.
        /// </summary>
        /// <param name="pDeporte">Deporte a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Deporte pDeporte)
        {
            ResultadoBd resultado = _dalManagerDeporte.Actualizar(pDeporte);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Deporte.");
        }

        /// <summary>
        /// Quita un Deporte.
        /// </summary>
        /// <param name="pDeporte">Deporte a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Deporte pDeporte)
        {
            ResultadoBd resultado = _dalManagerDeporte.Borrar(pDeporte);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Deporte.");

        }

        /// <summary>
        /// Obtiene todos los Deportes.
        /// </summary>
        /// <returns></returns>
        public List<BE.Deporte> ObtenerDeportes()
        {
            List<BE.Deporte> lstDeportes = _dalManagerDeporte.Leer();

            return lstDeportes;
        }


        public BE.Deporte ObtnerDeportePorId(int idDeporte)
        {
            BE.Deporte beDeporte = _dalManagerDeporte.ObtenerDeportePorId(idDeporte);

            return beDeporte;

        }
    }
    
}
