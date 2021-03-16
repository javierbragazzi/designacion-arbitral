namespace DA.BLL
{
    using DA.SS;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Designacion" />.
    /// </summary>
    public class Designacion
    {
        #region Properties

        /// <summary>
        /// Gets or sets the _arbitrosListaAux.
        /// </summary>
        private List<BE.Arbitro> _arbitrosListaAux { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Assigns the primary Arbitro.
        /// </summary>
        /// <param name="partidos">The Partidoes.</param>
        /// <param name="logicalArbitro">The logical Arbitro.</param>
        /// <param name="tipoArbitro">.</param>
        public void AsignarArbitros(List<PartidoHelperUI> partidos, BLL.Arbitro logicalArbitro, BE.TipoArbitro tipoArbitro)
        {
            BLL.Partido logicalPartido = new BLL.Partido();
            BLL.PartidoArbitro bllPartidoArbitro = new PartidoArbitro();

            foreach (PartidoHelperUI partido in partidos)
            {
                foreach (BE.Arbitro arbitro in _arbitrosListaAux)
                {
                    Logger.Log.Info("Partido: " + partido.Equipo1.Nombre + " vs. " + partido.Equipo2.Nombre);
                    Logger.Log.Info("Arbitro: " + arbitro.Apellido + " " + arbitro.Nombre);
                    Logger.Log.Info("Tipo de Arbitro: " + tipoArbitro.Descripcion);
                    if (arbitro.Habilitado == true)
                    {
                        if (logicalArbitro.PuedeDirigir(arbitro, partido, tipoArbitro))
                        {
                            Logger.Log.Info("Resultado: Asignado.");
                            Logger.Log.Info("---------------------------------------");

                            partido.ArbitrosYTipos.Add(arbitro, tipoArbitro);

                            ////Descomentar para que guarde la asignacion.*************************************
                            //BE.PartidoArbitro partidoArbitro = new BE.PartidoArbitro();
                            //partidoArbitro.Partido = partido.ConvertirAPartido();
                            //partidoArbitro.Arbitro = arbitro;
                            //partidoArbitro.TipoArbitro = tipoArbitro;
                            //partidoArbitro.Procesado = false;
                            //partidoArbitro.Calificacion = null;

                            //bllPartidoArbitro.Agregar(partidoArbitro);
                            _arbitrosListaAux.Remove(arbitro);
                            break;
                        }
                    }
                    else
                    {
                        Logger.Log.Info("Resultado: Estado de arbitro no disponible.");
                        Logger.Log.Info("---------------------------------------");
                    }
                }

            }
        }

        /// <summary>
        /// Does the asignation.
        /// </summary>
        /// <param name="partidos">The Partidoes.</param>
        /// <param name="arbitros">The Arbitros.</param>
        /// <param name="deporte">.</param>
        /// <returns>.</returns>
        public List<PartidoHelperUI> RealizarDesignacion(List<PartidoHelperUI> partidos, List<BE.Arbitro> arbitros, BE.Deporte deporte)
        {
            BLL.Arbitro logicalArbitro = new BLL.Arbitro();

            //List<BE.Arbitro> arbitroListAux = new List<BE.Arbitro>(arbitros);
            _arbitrosListaAux = new List<BE.Arbitro>(arbitros);
            BLL.TipoArbitro logicalTipoArbitro = new BLL.TipoArbitro();
            List<BE.TipoArbitro> tipoArbitros = logicalTipoArbitro.ObtenerTipoArbitros();

            Logger.Log.Info("-------COMIENZO DE LA ASIGNACION-------");
            Logger.Log.Info("---------------------------------------");

            foreach (BE.TipoArbitro tipoArbitro in tipoArbitros)
            {
                AsignarArbitros(partidos, logicalArbitro, tipoArbitro);
            }
            return partidos;
        }

        #endregion
    }
}
