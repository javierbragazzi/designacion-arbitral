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

            //foreach (BE.PartidoArbitro bePartidoArbitro in lstPartidoArbitros)
            //{
            //    bePartidoArbitro.Partido = bllPartido.ObtenerPartidoPorId(bePartidoArbitro.Partido.Id);
            //    bePartidoArbitro.Arbitro = bllArbitro.ObtnerArbitroPorId(bePartidoArbitro.Arbitro.Id);
            //    bePartidoArbitro.TipoArbitro = bllTipoArbitro.ObtnerTipoArbitroPorId(bePartidoArbitro.TipoArbitro.Id);
            //    bePartidoArbitro.Calificacion = bePartidoArbitro.Calificacion != null ? bllCalificacion.ObtenerCalificacionPorId(bePartidoArbitro.Calificacion.Id) : null;
            //}

            return lstPartidoArbitros;
        }

        public List<BE.PartidoArbitro> ObtenerPartidoArbitroPorPartidoId(int idPartido)
        {
            BLL.Partido bllPartido = new BLL.Partido();
            BLL.Arbitro bllArbitro = new BLL.Arbitro();
            BLL.TipoArbitro bllTipoArbitro = new BLL.TipoArbitro();
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();

            List<BE.PartidoArbitro> lstPartidoArbitros = _dalManagerPartidoArbitro.ObtenerPartidoArbitroPorPartidoId(idPartido);

            foreach (BE.PartidoArbitro bePartidoArbitro in lstPartidoArbitros)
            {
                bePartidoArbitro.Partido = bllPartido.ObtenerPartidoPorId(bePartidoArbitro.Partido.Id);
                bePartidoArbitro.Arbitro = bllArbitro.ObtnerArbitroPorId(bePartidoArbitro.Arbitro.Id);
                bePartidoArbitro.TipoArbitro = bllTipoArbitro.ObtnerTipoArbitroPorId(bePartidoArbitro.TipoArbitro.Id);
                bePartidoArbitro.Calificacion = bePartidoArbitro.Calificacion != null ? bllCalificacion.ObtenerCalificacionPorId(bePartidoArbitro.Calificacion.Id) : null;

            }

            return lstPartidoArbitros;

        }

        public List<BE.PartidoArbitro> ObtenerPartidosArbitroPorArbitroId(int idArbitro)
        {
            BLL.Partido bllPartido = new BLL.Partido();
            BLL.Arbitro bllArbitro = new BLL.Arbitro();
            BLL.TipoArbitro bllTipoArbitro = new BLL.TipoArbitro();
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();

            List<BE.PartidoArbitro> lstPartidoArbitros = _dalManagerPartidoArbitro.ObtenerPartidosArbitroPorArbitroId(idArbitro);

            foreach (BE.PartidoArbitro bePartidoArbitro in lstPartidoArbitros)
            {
                bePartidoArbitro.Partido = bllPartido.ObtenerPartidoPorId(bePartidoArbitro.Partido.Id);
                bePartidoArbitro.Arbitro = bllArbitro.ObtnerArbitroPorId(bePartidoArbitro.Arbitro.Id);
                bePartidoArbitro.TipoArbitro = bllTipoArbitro.ObtnerTipoArbitroPorId(bePartidoArbitro.TipoArbitro.Id);
                bePartidoArbitro.Calificacion = bePartidoArbitro.Calificacion != null ? bllCalificacion.ObtenerCalificacionPorId(bePartidoArbitro.Calificacion.Id) : null;

            }

            return lstPartidoArbitros;

        }

        public BE.PartidoArbitro ObtenerPartidoArbitroPorPartidoIdYArbitroId(int idPartido, int idArbitro)
        {
            BLL.Partido bllPartido = new BLL.Partido();
            BLL.Arbitro bllArbitro = new BLL.Arbitro();
            BLL.TipoArbitro bllTipoArbitro = new BLL.TipoArbitro();
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();

            BE.PartidoArbitro partidoArbitro = _dalManagerPartidoArbitro.ObtenerPartidoArbitroPorPartidoIdYArbitroId(idPartido, idArbitro);


            partidoArbitro.Partido = bllPartido.ObtenerPartidoPorId(partidoArbitro.Partido.Id);
            partidoArbitro.Arbitro = bllArbitro.ObtnerArbitroPorId(partidoArbitro.Arbitro.Id);
            partidoArbitro.TipoArbitro = bllTipoArbitro.ObtnerTipoArbitroPorId(partidoArbitro.TipoArbitro.Id);
            partidoArbitro.Calificacion = partidoArbitro.Calificacion != null ? bllCalificacion.ObtenerCalificacionPorId(partidoArbitro.Calificacion.Id) : null;


            return partidoArbitro;

        }

 
    }
}
