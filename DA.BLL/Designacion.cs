using System;
using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Designacion
    {
        /// <summary>
        /// Does the asignation.
        /// </summary>
        /// <param name="partidos">The Partidoes.</param>
        /// <param name="arbitros">The Arbitros.</param>
        /// <param name="deporte"></param>
        /// <returns></returns>
        public List<BE.Partido> RealizarDesignacion(List<BE.Partido> partidos, List<BE.Arbitro> arbitros, BE.Deporte deporte)
        {

            BLL.Arbitro logicalArbitro = new BLL.Arbitro();

            //Listas Auxiliares//
            List<BE.Arbitro> arbitroListAux = new List<BE.Arbitro>(arbitros);
            BLL.TipoArbitro logicalTipoArbitro = new BLL.TipoArbitro();
            List<BE.TipoArbitro> tipoArbitros = logicalTipoArbitro.ObtenerTipoArbitros();

            Logger.Log.Info("-------COMIENZO DE LA ASIGNACION-------");
            //Logger.Log.Info("-------FECHA NUMERO " + Partidoes.PartidodayNumber + "------------------");
            Logger.Log.Info("---------------------------------------");
            foreach (BE.TipoArbitro tipoArbitro in tipoArbitros)
            {
                AsignarArbitros(partidos, arbitroListAux, logicalArbitro, tipoArbitro);
            }
            return partidos;
        }

        /// <summary>
        /// Assigns the primary Arbitro.
        /// </summary>
        /// <param name="partidos">The Partidoes.</param>
        /// <param name="arbitros">The Arbitros.</param>
        /// <param name="logicalArbitro">The logical Arbitro.</param>
        /// <param name="tipoArbitro"></param>
        public void AsignarArbitros(List<BE.Partido> partidos, List<BE.Arbitro> arbitros, BLL.Arbitro logicalArbitro, BE.TipoArbitro tipoArbitro)
        {
           //BLL.Partido logicalPartido = new BLL.Partido();
            foreach (BE.Partido partido in partidos)
            {
                foreach (BE.Arbitro arbitro in arbitros)
                {
                    Logger.Log.Info("Partido: " + partido.Equipo1.Nombre + " vs. " + partido.Equipo2.Nombre);
                    Logger.Log.Info("Arbitro: " + arbitro.Apellido + " " + arbitro.Nombre);
                    Logger.Log.Info("Tipo de Arbitro: " + tipoArbitro.Descripcion);
                    if (arbitro.Estado == true)
                    {
                        if (logicalArbitro.PuedeDirigir(arbitro, partido, tipoArbitro))
                        {
                            Logger.Log.Info("Resultado: Asignado.");
                            Logger.Log.Info("---------------------------------------");

                            //if (tipoArbitro.Descripcion == "Principal")
                            //{
                            //    partido.Principal = arbitro;
                            //}
                            //else
                            //{
                            //    partido.Asistente = arbitro;
                            //}

                            partido.ArbitrosYTipos.Add(arbitro, tipoArbitro);
                            ActualizarUltimosPartidosDirigidos(arbitro, partido);
                            ActualizarUltimosEquiposDirigidos(arbitro, partido);
                            
                            ////Descomentar para que guarde la asignacion.
                            //logicalPartido.AddReferedPartido(Arbitro.IdArbitro, Partido.IdPartido, TipoArbitro.IdTipoArbitro);
                            
                            arbitros.Remove(arbitro);
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
        /// Updates the last Arbitrod teams.
        /// </summary>
        /// <param name="arbitro">The Arbitro.</param>
        /// <param name="partido">The Partido.</param>
        private void ActualizarUltimosEquiposDirigidos(BE.Arbitro arbitro, BE.Partido partido)
        {
            if (arbitro.UltimosEquiposDirigidos.Count == 4)
            {
                arbitro.UltimosEquiposDirigidos.Dequeue();
                arbitro.UltimosEquiposDirigidos.Dequeue();
            }
            arbitro.UltimosEquiposDirigidos.Enqueue(partido.Equipo1);
            arbitro.UltimosEquiposDirigidos.Enqueue(partido.Equipo2);
        }

        /// <summary>
        /// Updates the last fifty days refered.
        /// </summary>
        /// <param name="arbitro">The Arbitro.</param>
        /// <param name="partido">The Partido.</param>
        private void ActualizarUltimosPartidosDirigidos(BE.Arbitro arbitro, BE.Partido partido)
        {
            bool dropPartido = true;
            TimeSpan ts;
            while (dropPartido && arbitro.UltimosPartidosDirigidos != null)
            {
                if (arbitro.UltimosPartidosDirigidos.Count != 0)
                {
                    BE.Partido oldPartido = arbitro.UltimosPartidosDirigidos.Peek();
                    ts = partido.Fecha - oldPartido.Fecha;
                    if ((ts.Days < 15) || (oldPartido == null))
                    {
                        dropPartido = false;
                    }
                    else
                    {
                        arbitro.UltimosPartidosDirigidos.Dequeue();
                    }
                }
                else
                {
                    dropPartido = false;
                }
            }
            arbitro.UltimosPartidosDirigidos.Enqueue(partido);
        }
    }
}
