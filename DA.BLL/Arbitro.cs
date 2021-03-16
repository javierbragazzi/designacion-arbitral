namespace DA.BLL
{
    using DA.SS;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Arbitro" />.
    /// </summary>
    public class Arbitro
    {
        #region Fields

        /// <summary>
        /// Defines the _bllBitacora.
        /// </summary>
        private readonly BLL.Bitacora _bllBitacora = new BLL.Bitacora();

        /// <summary>
        /// Defines the _bllDeporte.
        /// </summary>
        private readonly BLL.Deporte _bllDeporte = new BLL.Deporte();

        /// <summary>
        /// Defines the _bllNivel.
        /// </summary>
        private readonly BLL.Nivel _bllNivel = new BLL.Nivel();

        /// <summary>
        /// Defines the _dalManagerArbitro.
        /// </summary>
        private readonly DAL.Arbitro _dalManagerArbitro = new DAL.Arbitro();

        #endregion

        #region Methods

        /// <summary>
        /// Agrega un nuevo Arbitro al sistema.
        /// </summary>
        /// <param name="pArbitro">Arbitro a agregar.</param>
        /// <returns>.</returns>
        public Resultado Agregar(BE.Arbitro pArbitro)
        {
            Resultado result = CorrerValidaciones(pArbitro);
            if (!result.HayError)
            {

                ResultadoBd resultado = _dalManagerArbitro.Insertar(pArbitro, _dalManagerArbitro.ObtenerArbitroPorId(pArbitro.Id), _bllBitacora.ObtenerBitacoraMaxId());

                if (resultado == ResultadoBd.OK)
                {
                    _bllBitacora.GrabarBitacora(ManejadorSesion.Instancia.ObtenerSesion().Usuario, "Alta de Árbitro", new BE.TipoEvento() { Id = 5, Descripcion = "Alta" });

                    return new Resultado(false, "Ok");
                }
            }

            return new Resultado(true, result.Descripcion);
        }

        /// <summary>
        /// The CorrerValidaciones.
        /// </summary>
        /// <param name="arbitro">The arbitro<see cref="BE.Arbitro"/>.</param>
        /// <returns>The <see cref="Resultado"/>.</returns>
        public Resultado CorrerValidaciones(BE.Arbitro arbitro)
        {
            Resultado resultado = ValidarMayoriaDeEdad(arbitro);
            if (resultado.HayError)
            {
                return resultado;
            }

            resultado = ValidarTituloValidoDeArgentina(arbitro);
            if (resultado.HayError)
            {
                return resultado;
            }
            resultado = ValidarExamenTeorico(arbitro);
            if (resultado.HayError)
            {
                return resultado;
            }
            resultado = ValidarExamenFisico(arbitro);

            return resultado;
        }

        /// <summary>
        /// Edita un Arbitro.
        /// </summary>
        /// <param name="pArbitro">Arbitro a editar.</param>
        /// <returns>.</returns>
        public Resultado Editar(BE.Arbitro pArbitro)
        {
            Resultado result = CorrerValidaciones(pArbitro);
            if (!result.HayError)
            {
                _bllBitacora.GrabarBitacora(ManejadorSesion.Instancia.ObtenerSesion().Usuario, "Modificación de Árbitro", new BE.TipoEvento() { Id = 7, Descripcion = "Modificación" });

                ResultadoBd resultado = _dalManagerArbitro.Actualizar(pArbitro, _dalManagerArbitro.ObtenerArbitroPorId(pArbitro.Id), _bllBitacora.ObtenerBitacoraMaxId());

                if (resultado == ResultadoBd.OK)
                    return new Resultado(false, "Ok");
            }

            return new Resultado(true, result.Descripcion);
        }

        /// <summary>
        /// Obtiene todos los Arbitros.
        /// </summary>
        /// <returns>.</returns>
        public List<BE.Arbitro> ObtenerArbitros()
        {
            List<BE.Arbitro> lstArbitros = _dalManagerArbitro.Leer();

            foreach (BE.Arbitro unArbitro in lstArbitros)
            {
                unArbitro.Nivel = _bllNivel.ObtnerNivelPorId(unArbitro.Nivel.Id);

            }

            return lstArbitros;
        }

        /// <summary>
        /// The ObtenerArbitrosConNivel.
        /// </summary>
        /// <returns>The <see cref="List{BE.Arbitro}"/>.</returns>
        public List<BE.Arbitro> ObtenerArbitrosConNivel()
        {
            List<BE.Arbitro> lstArbitros = _dalManagerArbitro.ObtenerArbitrosConNivel();

            foreach (BE.Arbitro unArbitro in lstArbitros)
            {
                unArbitro.Nivel = _bllNivel.ObtnerNivelPorId(unArbitro.Nivel.Id);
                //unArbitro.UltimosEquiposDirigidos = this.ObtenerUltimosEquiposDirigidos(unArbitro.Id);
                //unArbitro.UltimosPartidosDirigidos = this.ObtenerUltimosPartidosDirigidos(unArbitro.Id);
            }

            return lstArbitros;
        }

        /// <summary>
        /// The ObtenerArbitrosPorPartidoId.
        /// </summary>
        /// <param name="idPartido">The idPartido<see cref="int"/>.</param>
        /// <returns>The <see cref="List{BE.Arbitro}"/>.</returns>
        public List<BE.Arbitro> ObtenerArbitrosPorPartidoId(int idPartido)
        {
            List<BE.Arbitro> lstArbitros = _dalManagerArbitro.ObtenerArbitrosPorPartidoId(idPartido);

            foreach (BE.Arbitro unArbitro in lstArbitros)
            {
                unArbitro.Deporte = _bllDeporte.ObtnerDeportePorId(unArbitro.Id);
            }

            return lstArbitros;
        }

        /// <summary>
        /// Obtiene todos los Arbitros.
        /// </summary>
        /// <returns>.</returns>
        public List<BE.Arbitro> ObtenerArbitrosReducido()
        {
            List<BE.Arbitro> lstArbitros = _dalManagerArbitro.Leer();
            BLL.Genero bllGenero = new Genero();

            foreach (BE.Arbitro unArbitro in lstArbitros)
            {
                if (unArbitro.Nivel != null)
                {
                    unArbitro.Nivel = _bllNivel.ObtnerNivelReducidoPorId(unArbitro.Nivel.Id);
                }

                if (unArbitro.Deporte != null)
                {
                    unArbitro.Deporte = _bllDeporte.ObtnerDeportePorId(unArbitro.Deporte.Id);
                }

                if (unArbitro.Genero != null)
                {
                    unArbitro.Genero = bllGenero.ObtnerGeneroPorId(unArbitro.Genero.Id);
                }
            }

            return lstArbitros;
        }

        /// <summary>
        /// The ObtenerUltimosEquiposDirigidos.
        /// </summary>
        /// <param name="arbitroId">The arbitroId<see cref="int"/>.</param>
        /// <returns>The <see cref="List{BE.Equipo}"/>.</returns>
        public List<BE.Equipo> ObtenerUltimosEquiposDirigidos(int arbitroId)
        {
            List<BE.Equipo> list = new List<BE.Equipo>();

            BLL.Equipo bllEquipo = new BLL.Equipo();

            foreach (BE.Equipo equipo in bllEquipo.ObtenerUltimosEquiposDirigidos(arbitroId))
            {
                list.Add(equipo);
            }
            return list;
        }

        /// <summary>
        /// The ObtenerUltimosPartidosDirigidos.
        /// </summary>
        /// <param name="arbitroId">The arbitroId<see cref="int"/>.</param>
        /// <returns>The <see cref="List{BE.Partido}"/>.</returns>
        public List<BE.Partido> ObtenerUltimosPartidosDirigidos(int arbitroId)
        {
            List<BE.Partido> list = new List<BE.Partido>();
            BLL.Partido bllPartido = new BLL.Partido();

            foreach (BE.Partido item in bllPartido.ObtenerPartidosDirigidosUltimos15Dias(arbitroId))
            {
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// The ObtnerArbitroPorId.
        /// </summary>
        /// <param name="idArbitro">The idArbitro<see cref="int"/>.</param>
        /// <returns>The <see cref="BE.Arbitro"/>.</returns>
        public BE.Arbitro ObtnerArbitroPorId(int idArbitro)
        {
            BE.Arbitro beArbitro = _dalManagerArbitro.ObtenerArbitroPorId(idArbitro);

            beArbitro.Deporte = _bllDeporte.ObtnerDeportePorId(beArbitro.Deporte.Id);

            return beArbitro;
        }

        /// <summary>
        /// The ObtnerArbitrosYTiposPorPartidoId.
        /// </summary>
        /// <param name="idPartido">The idPartido<see cref="int"/>.</param>
        /// <returns>The <see cref="Dictionary{BE.Arbitro, BE.TipoArbitro}"/>.</returns>
        public Dictionary<BE.Arbitro, BE.TipoArbitro> ObtnerArbitrosYTiposPorPartidoId(int idPartido)
        {
            List<BE.Arbitro> lstArbitros = _dalManagerArbitro.ObtenerArbitrosPorPartidoId(idPartido);
            Dictionary<BE.Arbitro, BE.TipoArbitro> dictionary = new Dictionary<BE.Arbitro, BE.TipoArbitro>();
            BLL.TipoArbitro bllTipoArbitro = new TipoArbitro();

            foreach (BE.Arbitro unArbitro in lstArbitros)
            {
                unArbitro.Deporte = _bllDeporte.ObtnerDeportePorId(unArbitro.Id);
                dictionary.Add(unArbitro, bllTipoArbitro.ObtenerTipoArbitroPorPartidoYArbitroId(idPartido, unArbitro.Id));
            }

            return dictionary;
        }

        /// <summary>
        /// The PuedeDirigir.
        /// </summary>
        /// <param name="arbitro">The arbitro<see cref="BE.Arbitro"/>.</param>
        /// <param name="partido">The partido<see cref="PartidoHelperUI"/>.</param>
        /// <param name="tipoArbitro">The tipoArbitro<see cref="BE.TipoArbitro"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool PuedeDirigir(BE.Arbitro arbitro, PartidoHelperUI partido, BE.TipoArbitro tipoArbitro)
        {
            BLL.NivelRegla levelRule = new NivelRegla();

            if (this.EquipoDirigido(partido, arbitro)) { return false; }
            if (this.DirigidoLosUltimos15Dias(partido, arbitro)) { return false; }
            if (levelRule.PuedeDirigirPartidoComoTipoArbitro(arbitro, partido, tipoArbitro)) { return true; }
            return true;
        }

        /// <summary>
        /// Quita un Arbitro.
        /// </summary>
        /// <param name="pArbitro">Arbitro a quitar.</param>
        /// <returns>.</returns>
        public Resultado Quitar(BE.Arbitro pArbitro)
        {
            _bllBitacora.GrabarBitacora(ManejadorSesion.Instancia.ObtenerSesion().Usuario, "Baja de Árbitro", new BE.TipoEvento() { Id = 6, Descripcion = "Baja" });

            ResultadoBd resultado = _dalManagerArbitro.Borrar(pArbitro, _dalManagerArbitro.ObtenerArbitroPorId(pArbitro.Id), _bllBitacora.ObtenerBitacoraMaxId());

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Arbitro.");
        }

        /// <summary>
        /// The DirigidoLosUltimos15Dias.
        /// </summary>
        /// <param name="partido">The partido<see cref="PartidoHelperUI"/>.</param>
        /// <param name="arbitro">The arbitro<see cref="BE.Arbitro"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool DirigidoLosUltimos15Dias(PartidoHelperUI partido, BE.Arbitro arbitro)
        {
            List<BE.Partido> lstUltimosPartidosDirigidos = ObtenerUltimosPartidosDirigidos(arbitro.Id);

            if (lstUltimosPartidosDirigidos != null)
            {
                foreach (var partidoViejo in lstUltimosPartidosDirigidos)
                {
                    if (partidoViejo.Equipo1.Equals(partido.Equipo1))
                    {
                        Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " dirigió a " + partido.Equipo1.Nombre + " en los últimos 15 días.");
                        Logger.Log.Info("---------------------------------------");
                        return true;
                    }
                    if (partidoViejo.Equipo1.Equals(partido.Equipo2))
                    {
                        Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " dirigió a " + partido.Equipo2.Nombre + " en los últimos 15 días.");
                        Logger.Log.Info("---------------------------------------");
                        return true;
                    }
                    if (partidoViejo.Equipo2.Equals(partido.Equipo1))
                    {
                        Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " dirigió a " + partido.Equipo1.Nombre + " en los últimos 15 dias.");
                        Logger.Log.Info("---------------------------------------");
                        return true;
                    }
                    if (partidoViejo.Equipo2.Equals(partido.Equipo2))
                    {
                        Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " dirigió a " + partido.Equipo2.Nombre + " en los últimos 15 dias.");
                        Logger.Log.Info("---------------------------------------");
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// The EquipoDirigido.
        /// </summary>
        /// <param name="partido">The partido<see cref="PartidoHelperUI"/>.</param>
        /// <param name="arbitro">The arbitro<see cref="BE.Arbitro"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool EquipoDirigido(PartidoHelperUI partido, BE.Arbitro arbitro)
        {
            foreach (var team in ObtenerUltimosEquiposDirigidos(arbitro.Id))
            {
                if (partido.Equipo1.Equals(team))
                {
                    Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " dirigió a " + partido.Equipo1.Nombre + " equipo en la última fecha.");
                    Logger.Log.Info("---------------------------------------");
                    return true;
                }
                if (partido.Equipo2.Equals(team))
                {
                    Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " dirigió a " + partido.Equipo2.Nombre + " equipo en la última fecha.");
                    Logger.Log.Info("---------------------------------------");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// The ValidarExamenFisico.
        /// </summary>
        /// <param name="arbitro">The arbitro<see cref="BE.Arbitro"/>.</param>
        /// <returns>The <see cref="Resultado"/>.</returns>
        private Resultado ValidarExamenFisico(BE.Arbitro arbitro)
        {
            if (arbitro.ExamenFisicoAprobado == true)
                return new Resultado(false, "Examen Físico aprobado.");

            return new Resultado(true, "El árbitro no se puede dar de alta/modificar, no posee examén físico aprobado.");
        }

        /// <summary>
        /// The ValidarExamenTeorico.
        /// </summary>
        /// <param name="arbitro">The arbitro<see cref="BE.Arbitro"/>.</param>
        /// <returns>The <see cref="Resultado"/>.</returns>
        private Resultado ValidarExamenTeorico(BE.Arbitro arbitro)
        {
            if (arbitro.ExamenTeoricoAprobado == true)
                return new Resultado(false, "Examen Teórico aprobado.");

            return new Resultado(true, "El árbitro no se puede dar de alta/modificar, no posee examén teórico de AFA aprobado.");
        }

        /// <summary>
        /// The ValidarMayoriaDeEdad.
        /// </summary>
        /// <param name="arbitro">The arbitro<see cref="BE.Arbitro"/>.</param>
        /// <returns>The <see cref="Resultado"/>.</returns>
        private Resultado ValidarMayoriaDeEdad(BE.Arbitro arbitro)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - arbitro.FechaNacimiento.Year;
            if (arbitro.FechaNacimiento > now.AddYears(-age))
            {
                age--;
            }
            if (age >= 18)
            {
                return new Resultado(false, "Es mayor de 18 años.");
            }

            return new Resultado(true, "El árbitro no se puede dar de alta/modificar, no posee mayoría de edad.");
        }

        /// <summary>
        /// The ValidarTituloValidoDeArgentina.
        /// </summary>
        /// <param name="arbitro">The arbitro<see cref="BE.Arbitro"/>.</param>
        /// <returns>The <see cref="Resultado"/>.</returns>
        private Resultado ValidarTituloValidoDeArgentina(BE.Arbitro arbitro)
        {
            if (arbitro.PoseeTituloValidoArgentina == true)
                return new Resultado(false, "Posee titulo válido para Argentina.");

            return new Resultado(true, "El árbitro no se puede dar de alta/modificar, no posee titulo válido para Argentina.");
        }

        #endregion
    }
}
