using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Fecha
    {
        /// <summary>
        /// Dal manager Fecha
        /// </summary>
        private readonly DAL.Fecha _dalManagerFecha = new DAL.Fecha();
   


        /// <summary>
        /// Agrega un nuevo Fecha al sistema.
        /// </summary>
        /// <param name="pFecha">Fecha a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Fecha pFecha)
        {
            var resultado = _dalManagerFecha.Insertar(pFecha);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Fecha.");
        }

        /// <summary>
        /// Edita un Fecha.
        /// </summary>
        /// <param name="pFecha">Fecha a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Fecha pFecha)
        {
            ResultadoBd resultado = _dalManagerFecha.Actualizar(pFecha);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Fecha.");
        }

        /// <summary>
        /// Quita un Fecha.
        /// </summary>
        /// <param name="pFecha">Fecha a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Fecha pFecha)
        {
            ResultadoBd resultado = _dalManagerFecha.Borrar(pFecha);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Fecha.");

        }

        /// <summary>
        /// Obtiene todos los Fechas.
        /// </summary>
        /// <returns></returns>
        public List<BE.Fecha> ObtenerFechas()
        {
            BLL.Fixture bllFixture = new BLL.Fixture();
            BLL.Partido bllPartido = new BLL.Partido();
            List<BE.Fecha> lstFechas = _dalManagerFecha.Leer();

            foreach (BE.Fecha beFecha in lstFechas)
            {
                beFecha.Fixture = bllFixture.ObtnerFixturePorId(beFecha.Fixture.Id);
                beFecha.Partidos = bllPartido.ObtenerPartidosPorIdFecha(beFecha.Fixture.Id);
                
            }

            return lstFechas;
        }

        public BE.Fecha ObtenerFechaPorId(int idFecha)
        {
            BLL.Fixture bllFixture = new BLL.Fixture();
            BLL.Partido bllPartido = new BLL.Partido();
            BE.Fecha beFecha = _dalManagerFecha.ObtenerFechaPorId(idFecha);

            beFecha.Fixture = bllFixture.ObtnerFixturePorId(beFecha.Fixture.Id);
            beFecha.Partidos = bllPartido.ObtenerPartidosPorIdFecha(beFecha.Fixture.Id);

            return beFecha;

        }

        public BE.Fecha ObtenerFechaPorIdReducido(int idFecha)
        {
            BE.Fecha beFecha = _dalManagerFecha.ObtenerFechaPorId(idFecha);

            beFecha.Fixture.Id = beFecha.Fixture.Id;

            return beFecha;

        }

        public List<BE.Fecha> ObtenerFechasPorIdFixture(int idFixture)
        {

            BLL.Partido bllPartido = new BLL.Partido();
            List<BE.Fecha> lstFechas = _dalManagerFecha.ObtenerFechasPorIdFixture(idFixture);

            foreach (BE.Fecha beFecha in lstFechas)
            {
                //beFecha.Fixture = _bllFixture.ObtnerFixturePorId(beFecha.Fixture.Id);
                beFecha.Fixture.Id = beFecha.Fixture.Id;
                beFecha.Partidos = bllPartido.ObtenerPartidosPorIdFecha(beFecha.Fixture.Id);
            }

            return lstFechas;
        }

        public List<BE.Fecha> ObtenerFechasNoDesignadas(int idDeporte)
        {
            BLL.Campeonato bllCampeonato = new BLL.Campeonato();
            BLL.Partido bllPartido = new BLL.Partido();
            List<BE.Fecha> lstFechas = _dalManagerFecha.ObtenerFechasNoDesignadas(idDeporte);

            foreach (BE.Fecha beFecha in lstFechas)
            {
                beFecha.Fixture.Id = beFecha.Fixture.Id;
                //beFecha.Fixture = bllFixture.ObtnerFixturePorId();
                beFecha.Partidos = bllPartido.ObtenerPartidosPorIdFecha(beFecha.Id);
                beFecha.NombreParaMostrar = beFecha.Nombre + " - " + bllCampeonato.ObtenerNombreCampeonatoPorFixture(beFecha.Fixture.Id);
            }

            return lstFechas;
        }
    }
}
