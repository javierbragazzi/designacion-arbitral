using System;
using System.Collections.Generic;
using System.Linq;
using DA.BE;

namespace DA.SS
{
        public class PartidoHelperUI 
        {
            public int Id { get; set; }

            public Equipo Equipo1 { get; set; }
        
            public Equipo Equipo2 { get; set; }
        
            public int Prioridad { get; set; }
      
            public DateTime Fecha { get; set; }
        
            public Fecha FechaDelCampeonato { get; set; }

            public string NombreArbitroPrincipal
            {
                get
                {
                    return ArbitrosYTipos.FirstOrDefault(x => ((BE.TipoArbitro)x.Value).Descripcion == "Principal").Key.ObtenerNombreCompleto();
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                }
            }

            public string NombreArbitroAsistente
            {
                get
                {
                    return ArbitrosYTipos.FirstOrDefault(x => ((BE.TipoArbitro)x.Value).Descripcion == "Asistente").Key.ObtenerNombreCompleto();
                }
                set
                {
                    if (value == null)
                        throw new ArgumentNullException(nameof(value));
                }
            }

            public double PuntajeArbitroPrincipal
            {
                get
                {
                    if (CalificacionesArbitros.Count != 0)
                        return CalificacionesArbitros
                            .FirstOrDefault(x => ((BE.TipoArbitro)x.Key).Descripcion == "Principal").Value
                            .ObtenerPuntajeTotal();
                    else
                        return 0;
                }
                set
                {
                    if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                }
            }

            public double PuntajeArbitroAsistente
            {
                get
                {
                    if (CalificacionesArbitros.Count != 0)
                        return CalificacionesArbitros
                            .FirstOrDefault(x => ((BE.TipoArbitro)x.Key).Descripcion == "Asistente").Value
                            .ObtenerPuntajeTotal();
                    else
                        return 0;
                }
                set
                {
                    if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                }
            }

            public Dictionary<BE.Arbitro, BE.TipoArbitro> ArbitrosYTipos { get; set; }

            public Dictionary<BE.TipoArbitro, BE.Calificacion> CalificacionesArbitros { get; set; }

            public PartidoHelperUI()
            {
                ArbitrosYTipos = new Dictionary<Arbitro, TipoArbitro>();
                CalificacionesArbitros = new Dictionary<TipoArbitro, Calificacion>();
            }

            public BE.Partido ConvertirAPartido()
            {
                return new Partido()
                {
                    Id = this.Id,
                    Equipo1 = this.Equipo1,
                    Equipo2 = this.Equipo2,
                    Fecha = this.Fecha,
                    FechaDelCampeonato = this.FechaDelCampeonato,
                    Prioridad = this.Prioridad
                };
            }

            public PartidoHelperUI(BE.Partido partido)
            {
                Id = partido.Id;
                Equipo1 = partido.Equipo1;
                Equipo2 = partido.Equipo2;
                Fecha = partido.Fecha;
                FechaDelCampeonato = partido.FechaDelCampeonato;
                Prioridad = partido.Prioridad;

                ArbitrosYTipos = new Dictionary<Arbitro, TipoArbitro>();
                CalificacionesArbitros = new Dictionary<TipoArbitro, Calificacion>();
            }


        }
    
}
