using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Partido
    {
        /// <summary>
        /// Dal manager Partido
        /// </summary>
        private readonly DAL.Partido _dalManagerPartido = new DAL.Partido();
   
        /// <summary>
        /// Agrega un nuevo Partido al sistema.
        /// </summary>
        /// <param name="pPartido">Partido a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Partido pPartido)
        {
            var resultado = _dalManagerPartido.Insertar(pPartido);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Partido.");
        }

        /// <summary>
        /// Edita un Partido.
        /// </summary>
        /// <param name="pPartido">Partido a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Partido pPartido)
        {
            ResultadoBd resultado = _dalManagerPartido.Actualizar(pPartido);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Partido.");
        }

        /// <summary>
        /// Quita un Partido.
        /// </summary>
        /// <param name="pPartido">Partido a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Partido pPartido)
        {
            ResultadoBd resultado = _dalManagerPartido.Borrar(pPartido);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Partido.");

        }

        /// <summary>
        /// Obtiene todos los Partidos.
        /// </summary>
        /// <returns></returns>
        public List<BE.Partido> ObtenerPartidos()
        {
            BLL.Equipo bllEquipo = new BLL.Equipo();
            BLL.Fecha bllFecha = new BLL.Fecha();
            List<BE.Partido> lstPartidos = _dalManagerPartido.Leer();

            foreach (BE.Partido bePartido in lstPartidos)
            {
                bePartido.Equipo1 = bllEquipo.ObtnerEquipoPorId(bePartido.Equipo1.Id);
                bePartido.Equipo2 = bllEquipo.ObtnerEquipoPorId(bePartido.Equipo2.Id);
                bePartido.FechaDelCampeonato = bllFecha.ObtenerFechaPorId(bePartido.FechaDelCampeonato.Id);
            }

            return lstPartidos;
        }

        public List<PartidoHelperUI> ObtenerPartidosConCalificacion()
        {
            BLL.Equipo bllEquipo = new BLL.Equipo();
            BLL.Fecha bllFecha = new BLL.Fecha();
            List<PartidoHelperUI> lstPartidos = _dalManagerPartido.ObtenerPartidosConCalificacion();
            BLL.Arbitro bllArbitro = new BLL.Arbitro();
            BLL.Calificacion bllCalificacion = new Calificacion();

            foreach (PartidoHelperUI partido in lstPartidos)
            {
                partido.Equipo1 = bllEquipo.ObtnerEquipoPorId(partido.Equipo1.Id);
                partido.Equipo2 = bllEquipo.ObtnerEquipoPorId(partido.Equipo2.Id);
                partido.FechaDelCampeonato = bllFecha.ObtenerFechaPorIdReducido(partido.FechaDelCampeonato.Id);
                partido.ArbitrosYTipos = bllArbitro.ObtnerArbitrosYTiposPorPartidoId(partido.Id);

    
            }

            return lstPartidos;
        }

        public List<PartidoHelperUI> ObtenerPartidosSinCalificacion()
        {
            BLL.Equipo bllEquipo = new BLL.Equipo();
            BLL.Fecha bllFecha = new BLL.Fecha();
            List<PartidoHelperUI> lstPartidos = _dalManagerPartido.ObtenerPartidosSinCalificacion();
            BLL.Arbitro bllArbitro = new BLL.Arbitro();

            foreach (PartidoHelperUI partido in lstPartidos)
            {
                partido.Equipo1 = bllEquipo.ObtnerEquipoPorIdReducido(partido.Equipo1.Id);
                partido.Equipo2 = bllEquipo.ObtnerEquipoPorIdReducido(partido.Equipo2.Id);
                partido.FechaDelCampeonato = bllFecha.ObtenerFechaPorIdReducido(partido.FechaDelCampeonato.Id);
                partido.ArbitrosYTipos = bllArbitro.ObtnerArbitrosYTiposPorPartidoId(partido.Id);
            }

            return lstPartidos;
        }

        public BE.Partido ObtenerPartidoPorId(int idPartido)
        {
            BLL.Equipo bllEquipo = new BLL.Equipo();
            BLL.Fecha bllFecha = new BLL.Fecha();
            BE.Partido bePartido = _dalManagerPartido.ObtenerPartidoPorId(idPartido);

            bePartido.Equipo1 = bllEquipo.ObtnerEquipoPorId(bePartido.Equipo1.Id);
            bePartido.Equipo2 = bllEquipo.ObtnerEquipoPorId(bePartido.Equipo2.Id);
            bePartido.FechaDelCampeonato = bllFecha.ObtenerFechaPorIdReducido(bePartido.FechaDelCampeonato.Id);

            return bePartido;

        }

        public List<BE.Partido> ObtenerPartidosPorIdFecha(int idFecha)
        {
            BLL.Equipo bllEquipo = new BLL.Equipo();
            BLL.Fecha bllFecha = new BLL.Fecha();
            List<BE.Partido> lstPartidos = _dalManagerPartido.ObtenerPartidosPorIdFecha(idFecha);

            foreach (BE.Partido bePartido in lstPartidos)
            {
                bePartido.Equipo1 = bllEquipo.ObtnerEquipoPorId(bePartido.Equipo1.Id);
                bePartido.Equipo2 = bllEquipo.ObtnerEquipoPorId(bePartido.Equipo2.Id);
                bePartido.FechaDelCampeonato = bllFecha.ObtenerFechaPorIdReducido(bePartido.FechaDelCampeonato.Id);
            }

            return lstPartidos;
        }

        public List<BE.Partido> ObtenerPartidosDirigidosUltimos15Dias(int idArbitro)
        {
            BLL.Equipo bllEquipo = new BLL.Equipo();
            BLL.Fecha bllFecha = new BLL.Fecha();
            List<BE.Partido> lstPartidos = _dalManagerPartido.ObtenerPartidosDirigidosUltimos15Dias(idArbitro);

            if (lstPartidos != null)
            {
                foreach (BE.Partido bePartido in lstPartidos)
                {
                    bePartido.Equipo1 = bllEquipo.ObtnerEquipoPorId(bePartido.Equipo1.Id);
                    bePartido.Equipo2 = bllEquipo.ObtnerEquipoPorId(bePartido.Equipo2.Id);
                    bePartido.FechaDelCampeonato = bllFecha.ObtenerFechaPorIdReducido(bePartido.FechaDelCampeonato.Id);
                }
            }
            else
                return new List<BE.Partido>();

            return lstPartidos;
        }


    }
}
