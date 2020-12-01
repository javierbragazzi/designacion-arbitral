using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.SS;

namespace DA.BLL
{
    public class TipoArbitro
    {
         /// <summary>
        /// Dal manager TipoArbitro
        /// </summary>
        private readonly DAL.TipoArbitro _dalManagerTipoArbitro = new DAL.TipoArbitro();
   
         private readonly BLL.Deporte _bllDeporte = new BLL.Deporte();

        /// <summary>
        /// Agrega un nuevo TipoArbitro al sistema.
        /// </summary>
        /// <param name="pTipoArbitro">TipoArbitro a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.TipoArbitro pTipoArbitro)
        {
            var resultado = _dalManagerTipoArbitro.Insertar(pTipoArbitro);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el TipoArbitro.");
        }

        /// <summary>
        /// Edita un TipoArbitro.
        /// </summary>
        /// <param name="pTipoArbitro">TipoArbitro a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.TipoArbitro pTipoArbitro)
        {
            ResultadoBd resultado = _dalManagerTipoArbitro.Actualizar(pTipoArbitro);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el TipoArbitro.");
        }

        /// <summary>
        /// Quita un TipoArbitro.
        /// </summary>
        /// <param name="pTipoArbitro">TipoArbitro a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.TipoArbitro pTipoArbitro)
        {
            ResultadoBd resultado = _dalManagerTipoArbitro.Borrar(pTipoArbitro);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el TipoArbitro.");

        }

        /// <summary>
        /// Obtiene todos los TipoArbitros.
        /// </summary>
        /// <returns></returns>
        public List<BE.TipoArbitro> ObtenerTipoArbitros()
        {
            List<BE.TipoArbitro> lstTipoArbitros = _dalManagerTipoArbitro.Leer();

            foreach (BE.TipoArbitro beTipoArbitro in lstTipoArbitros)
            {
                beTipoArbitro.Deporte = _bllDeporte.ObtnerDeportePorId(beTipoArbitro.Deporte.Id);
            }

            return lstTipoArbitros;
        }

        public BE.TipoArbitro ObtnerTipoArbitroPorId(int idTipoArbitro)
        {
            BE.TipoArbitro beTipoArbitro = _dalManagerTipoArbitro.ObtenerTipoArbitroPorId(idTipoArbitro);

            beTipoArbitro.Deporte = _bllDeporte.ObtnerDeportePorId(beTipoArbitro.Deporte.Id);

            return beTipoArbitro;

        }      
        
        public BE.TipoArbitro ObtnerTipoArbitroPorIdReducido(int idTipoArbitro)
        {
            BE.TipoArbitro beTipoArbitro = _dalManagerTipoArbitro.ObtenerTipoArbitroPorId(idTipoArbitro);

           // beTipoArbitro.Deporte = _bllDeporte.ObtnerDeportePorId(beTipoArbitro.Deporte.Id);

            return beTipoArbitro;

        }    
        
        public BE.TipoArbitro ObtenerTipoArbitroPorPartidoYArbitroId(int idPartido, int idArbitro)
        {
            return _dalManagerTipoArbitro.ObtenerTipoArbitroPorPartidoYArbitroId(idPartido, idArbitro);

        }

        
    }
}
