using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class TipoEvento
    {
         /// <summary>
        /// Dal manager TipoEvento
        /// </summary>
        private readonly DAL.TipoEvento _dalManagerTipoEvento = new DAL.TipoEvento();
         
        /// <summary>
        /// Agrega un nuevo TipoEvento al sistema.
        /// </summary>
        /// <param name="pTipoEvento">TipoEvento a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.TipoEvento pTipoEvento)
        {
            var resultado = _dalManagerTipoEvento.Insertar(pTipoEvento);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el TipoEvento.");
        }

        /// <summary>
        /// Edita un TipoEvento.
        /// </summary>
        /// <param name="pTipoEvento">TipoEvento a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.TipoEvento pTipoEvento)
        {
            ResultadoBd resultado = _dalManagerTipoEvento.Actualizar(pTipoEvento);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el TipoEvento.");
        }

        /// <summary>
        /// Quita un TipoEvento.
        /// </summary>
        /// <param name="pTipoEvento">TipoEvento a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.TipoEvento pTipoEvento)
        {
            ResultadoBd resultado = _dalManagerTipoEvento.Borrar(pTipoEvento);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el TipoEvento.");

        }

        /// <summary>
        /// Obtiene todos los TipoEventos.
        /// </summary>
        /// <returns></returns>
        public List<BE.TipoEvento> ObtenerTipoEventos()
        {
            List<BE.TipoEvento> lstTipoEventos = _dalManagerTipoEvento.Leer();

            return lstTipoEventos;
        }

        public BE.TipoEvento ObtnerTipoEventoPorId(int idTipoEvento)
        {
            BE.TipoEvento beTipoEvento = _dalManagerTipoEvento.ObtenerTipoEventoPorId(idTipoEvento);

            return beTipoEvento;

        }      
        
        
    }
}
