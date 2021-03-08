using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class PartidoArbitro
    {
        /// <summary>
        /// Dal manager PartidoArbitro
        /// </summary>
        private readonly DAL.PartidoArbitro _dalManagerPartidoArbitro = new DAL.PartidoArbitro();
   
        

        /// <summary>
        /// Agrega un nuevo PartidoArbitro al sistema.
        /// </summary>
        /// <param name="pPartidoArbitro">PartidoArbitro a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.PartidoArbitro pPartidoArbitro)
        {
            var resultado = _dalManagerPartidoArbitro.Insertar(pPartidoArbitro);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el PartidoArbitro.");
        }

        /// <summary>
        /// Edita un PartidoArbitro.
        /// </summary>
        /// <param name="pPartidoArbitro">PartidoArbitro a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.PartidoArbitro pPartidoArbitro)
        {
            ResultadoBd resultado = _dalManagerPartidoArbitro.Actualizar(pPartidoArbitro);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el PartidoArbitro.");
        }

        /// <summary>
        /// Quita un PartidoArbitro.
        /// </summary>
        /// <param name="pPartidoArbitro">PartidoArbitro a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.PartidoArbitro pPartidoArbitro)
        {
            ResultadoBd resultado = _dalManagerPartidoArbitro.Borrar(pPartidoArbitro);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el PartidoArbitro.");

        }

        /// <summary>
        /// Obtiene todos los PartidoArbitros.
        /// </summary>
        /// <returns></returns>
        public List<BE.PartidoArbitro> ObtenerPartidoArbitros()
        {
            BLL.Partido bllPartido = new BLL.Partido();
            BLL.Arbitro bllArbitro = new BLL.Arbitro();
            BLL.TipoArbitro bllTipoArbitro = new BLL.TipoArbitro();
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();

            List<BE.PartidoArbitro> lstPartidoArbitros = _dalManagerPartidoArbitro.Leer();

            foreach (BE.PartidoArbitro bePartidoArbitro in lstPartidoArbitros)
            {
                bePartidoArbitro.Partido = bllPartido.ObtenerPartidoPorId(bePartidoArbitro.Partido.Id);
                bePartidoArbitro.Arbitro = bllArbitro.ObtnerArbitroPorId(bePartidoArbitro.Arbitro.Id);
                bePartidoArbitro.TipoArbitro = bllTipoArbitro.ObtnerTipoArbitroPorId(bePartidoArbitro.TipoArbitro.Id);
                bePartidoArbitro.Calificacion = bllCalificacion.ObtenerCalificacionPorId(bePartidoArbitro.Calificacion.Id);
            }

            return lstPartidoArbitros;
        }

        //public BE.PartidoArbitro ObtnerPartidoArbitroPorId(int idPartidoArbitro)
        //{
        //    BE.PartidoArbitro bePartidoArbitro = _dalManagerPartidoArbitro.ObtenerPartidoArbitroPorId(idPartidoArbitro);

        //    bePartidoArbitro.Deporte = _bllDeporte.ObtnerDeportePorId(bePartidoArbitro.Deporte.Id);

        //    return bePartidoArbitro;

        //}      
        
        //public BE.PartidoArbitro ObtnerPartidoArbitroPorIdReducido(int idPartidoArbitro)
        //{
        //    BE.PartidoArbitro bePartidoArbitro = _dalManagerPartidoArbitro.ObtenerPartidoArbitroPorId(idPartidoArbitro);

        //   // bePartidoArbitro.Deporte = _bllDeporte.ObtnerDeportePorId(bePartidoArbitro.Deporte.Id);

        //    return bePartidoArbitro;

        //}    
        
        //public BE.PartidoArbitro ObtenerPartidoArbitroPorPartidoYArbitroId(int idPartido, int idArbitro)
        //{
        //    return _dalManagerPartidoArbitro.ObtenerPartidoArbitroPorPartidoYArbitroId(idPartido, idArbitro);

        //}
    }
}
