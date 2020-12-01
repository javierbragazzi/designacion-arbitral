using System;
using System.Collections.Generic;
using DA.BE;
using DA.SS;

namespace DA.BLL
{
    public class Arbitro
    {
        /// <summary>
        /// Dal manager Arbitro
        /// </summary>
        private readonly DAL.Arbitro _dalManagerArbitro = new DAL.Arbitro();

   
        private readonly BLL.Bitacora _bllBitacora = new BLL.Bitacora();
        private readonly BLL.Deporte _bllDeporte = new BLL.Deporte();
        private readonly BLL.Nivel _bllNivel = new BLL.Nivel();


        /// <summary>
        /// Agrega un nuevo Arbitro al sistema.
        /// </summary>
        /// <param name="pArbitro">Arbitro a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Arbitro pArbitro)
        {
            Resultado result = CorrerValidaciones(pArbitro);
            if (!result.HayError)
            {
                _bllBitacora.GrabarBitacora(ManejadorSesion.Instancia.ObtenerSesion().Usuario, "ALTA ARBITRO", TipoEvento.ALTA);

                ResultadoBd resultado = _dalManagerArbitro.Insertar(pArbitro, _dalManagerArbitro.ObtenerArbitroPorId(pArbitro.Id), _bllBitacora.ObtenerBitacoraMaxId());

                if (resultado == ResultadoBd.OK)
                    return new Resultado(false, "Ok");
            }
            
            return new Resultado(true, result.Descripcion);
        }

        /// <summary>
        /// Edita un Arbitro.
        /// </summary>
        /// <param name="pArbitro">Arbitro a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Arbitro pArbitro)
        {
            Resultado result = CorrerValidaciones(pArbitro);
            if (!result.HayError)
            {
                _bllBitacora.GrabarBitacora(ManejadorSesion.Instancia.ObtenerSesion().Usuario, "MODIFICACION ARBITRO", TipoEvento.MODIFICACION);

                ResultadoBd resultado = _dalManagerArbitro.Actualizar(pArbitro, _dalManagerArbitro.ObtenerArbitroPorId(pArbitro.Id), _bllBitacora.ObtenerBitacoraMaxId());

                if (resultado == ResultadoBd.OK)
                    return new Resultado(false, "Ok");
            }

            return new Resultado(true, result.Descripcion);
        }

        /// <summary>
        /// Quita un Arbitro.
        /// </summary>
        /// <param name="pArbitro">Arbitro a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Arbitro pArbitro)
        {
            _bllBitacora.GrabarBitacora(ManejadorSesion.Instancia.ObtenerSesion().Usuario, "BAJA ARBITRO", TipoEvento.BAJA);

            ResultadoBd resultado = _dalManagerArbitro.Borrar(pArbitro, _dalManagerArbitro.ObtenerArbitroPorId(pArbitro.Id), _bllBitacora.ObtenerBitacoraMaxId());

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Arbitro.");

        }

        /// <summary>
        /// Obtiene todos los Arbitros.
        /// </summary>
        /// <returns></returns>
        public List<BE.Arbitro> ObtenerArbitros()
        {
            List<BE.Arbitro> lstArbitros = _dalManagerArbitro.Leer();

            foreach (BE.Arbitro unArbitro in lstArbitros)
            {
                unArbitro.Nivel = _bllNivel.ObtnerNivelPorId(unArbitro.Nivel.Id);
                
            }

            return lstArbitros;
        }

        public List<BE.Arbitro> ObtenerArbitrosConNivel()
        {
            List<BE.Arbitro> lstArbitros = _dalManagerArbitro.ObtenerArbitrosConNivel();

            foreach (BE.Arbitro unArbitro in lstArbitros)
            {
                unArbitro.Nivel = _bllNivel.ObtnerNivelPorId(unArbitro.Nivel.Id);
                unArbitro.UltimosEquiposDirigidos = this.ObtenerUltimosEquiposDirigidos(unArbitro.Id);
                unArbitro.UltimosPartidosDirigidos = this.ObtenerUltimosPartidosDirigidos(unArbitro.Id);
            }

            return lstArbitros;
        }

        /// <summary>
        /// Gets the last refereed teams.
        /// </summary>
        /// <param name="pId">The p identifier.</param>
        /// <returns></returns>
        public Queue<BE.Equipo> ObtenerUltimosEquiposDirigidos(int pId)
        {
            Queue<BE.Equipo> queue = new Queue<BE.Equipo>();

            BLL.Equipo bllEquipo = new BLL.Equipo();

            foreach (BE.Equipo equipo in bllEquipo.ObtenerUltimosEquiposDirigidos(pId))
            {
               // BE.Equipo team = bllEquipo.ObtnerEquipoPorId(equipo.Id);
                queue.Enqueue(equipo);
            }
            return queue;
        }

        /// <summary>
        /// Gets the last fifty days refered.
        /// </summary>
        /// <param name="pId">The p identifier.</param>
        /// <returns></returns>
        public Queue<BE.Partido> ObtenerUltimosPartidosDirigidos(int pId)
        {
            Queue<BE.Partido> queue = new Queue<BE.Partido>();
            BLL.Partido bllPartido = new BLL.Partido();

            foreach (BE.Partido item in bllPartido.ObtenerPartidosDirigidosUltimos15Dias(pId))
            {
               // BE.Partido match = (BE.Match)_dalManagerMatch.GetEntityById(int.Parse(item.ToString()));
                queue.Enqueue(item);
            }
            return queue;
        }

        /// <summary>
        /// Obtiene todos los Arbitros.
        /// </summary>
        /// <returns></returns>
        public List<BE.Arbitro> ObtenerArbitrosReducido()
        {
            List<BE.Arbitro> lstArbitros = _dalManagerArbitro.Leer();

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
            }

            return lstArbitros;
        }

        public BE.Arbitro ObtnerArbitroPorId(int idArbitro)
        {
            BE.Arbitro beArbitro = _dalManagerArbitro.ObtenerArbitroPorId(idArbitro);

            beArbitro.Deporte = _bllDeporte.ObtnerDeportePorId(beArbitro.Deporte.Id);

            return beArbitro;

        }
        
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

        public List<BE.Arbitro> ObtenerArbitrosPorPartidoId(int idPartido)
        {
            List<BE.Arbitro> lstArbitros = _dalManagerArbitro.ObtenerArbitrosPorPartidoId(idPartido);

            foreach (BE.Arbitro unArbitro in lstArbitros)
            {
                unArbitro.Deporte = _bllDeporte.ObtnerDeportePorId(unArbitro.Id);
            }

            return lstArbitros;
        }

        public bool PuedeDirigir(BE.Arbitro arbitro, BE.Partido partido, BE.TipoArbitro tipoArbitro)
        {
            BLL.NivelRegla levelRule = new NivelRegla();

            if (this.EquipoDirigido(partido, arbitro)){return false;}
            if (this.DirigidoLosUltimos15Dias(partido, arbitro)){return false;}
            if (levelRule.PuedeDirigirPartidoComoTipoArbitro(arbitro, partido, tipoArbitro)){return true;}
            return true;
        }

        private bool EquipoDirigido(BE.Partido partido, BE.Arbitro arbitro)
        {
            foreach (var team in arbitro.UltimosEquiposDirigidos)
            {
                if (partido.Equipo1.Equals(team))
                {
                    Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " dirigio equipo " + partido.Equipo1.Nombre + ".");
                    Logger.Log.Info("---------------------------------------");
                    return true;
                }
                if (partido.Equipo2.Equals(team))
                {
                    Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " dirigio equipo " + partido.Equipo2.Nombre + ".");
                    Logger.Log.Info("---------------------------------------");
                    return true;
                }
            }
            return false;
        }

        private bool DirigidoLosUltimos15Dias(BE.Partido partido, BE.Arbitro arbitro)
        {

            if (arbitro.UltimosPartidosDirigidos != null)
            {
                foreach (var partidoViejo in arbitro.UltimosPartidosDirigidos)
                {
                    if (partidoViejo.Equipo1.Equals(partido.Equipo1))
                    {
                        Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " dirigio equipo " + partido.Equipo1.Nombre + " en los ultimos 15 dias.");
                        Logger.Log.Info("---------------------------------------");
                        return true;
                    }
                    if (partidoViejo.Equipo1.Equals(partido.Equipo2))
                    {
                        Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " dirigio equipo " + partido.Equipo2.Nombre + " en los ultimos 15 dias.");
                        Logger.Log.Info("---------------------------------------");
                        return true;
                    }
                    if (partidoViejo.Equipo2.Equals(partido.Equipo1))
                    {
                        Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " dirigio equipo " + partido.Equipo1.Nombre + " en los ultimos 15 dias.");
                        Logger.Log.Info("---------------------------------------");
                        return true;
                    }
                    if (partidoViejo.Equipo2.Equals(partido.Equipo2))
                    {
                        Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " dirigio equipo " + partido.Equipo2.Nombre + " en los ultimos 15 dias.");
                        Logger.Log.Info("---------------------------------------");
                        return true;
                    }
                }
            }
            return false;
        }

      

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

            return new Resultado(true, "No posee mayoría de edad.");
        }
        private Resultado ValidarTituloValidoDeArgentina(BE.Arbitro arbitro)
        {
            if (arbitro.TituloValidoArgentina == true)
                return new Resultado(false, "Posee titulo válido para Argentina.");

            return new Resultado(true, "No posee titulo válido para Argentina.");
        }
        private Resultado ValidarExamenTeorico(BE.Arbitro arbitro)
        {
            if (arbitro.ExamenTeorico == true)
                return new Resultado(false, "Examen Teórico aprobado.");

            return new Resultado(true, "Examen Teórico reprobado.");
        }
        private Resultado ValidarExamenFisico(BE.Arbitro arbitro)
        {
            if (arbitro.ExamenFisico == true)
                return new Resultado(false, "Examen Físico aprobado.");

            return new Resultado(true, "Examen Físico reprobado.");
        }

    }
}
