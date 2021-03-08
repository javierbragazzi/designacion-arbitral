using System;
using System.Collections.Generic;
using System.Linq;

namespace DA.BE
{
    [Tabla("Partido")]
    public class Partido : EntidadBase, IComparable<Partido>
    {
        public Equipo Equipo1
        {
            [Columna("IdEquipo", "Equipo1", typeof(int), false, false)]
            get;
            set;
        }

        public Equipo Equipo2
        {
            [Columna("IdEquipo", "Equipo2", typeof(int), false, false)]
            get;
            set;
        }

        public int Prioridad
        {
            [Columna("Prioridad", "Prioridad", typeof(int), false, false)]
            get;
            set;
        }

        public DateTime Fecha
        {
            [Columna("Fecha", "Fecha", typeof(DateTime), false, false)]
            get;
            set;
        }

        public Fecha FechaDelCampeonato
        {
            [Columna("IdFecha", "FechaDelCampeonato", typeof(int), false, false)]
            get;
            set;
        }

        //public string NombreArbitroPrincipal
        //{
        //    get
        //    {
        //        return ArbitrosYTipos.FirstOrDefault(x => ((BE.TipoArbitro) x.Value).Descripcion == "Principal").Key.ObtenerNombreCompleto();
        //    }
        //    set
        //    {
        //        if (value == null) 
        //            throw new ArgumentNullException(nameof(value));
        //    }
        //}

        //public string NombreArbitroAsistente
        //{
        //    get
        //    {
        //        return ArbitrosYTipos.FirstOrDefault(x => ((BE.TipoArbitro) x.Value).Descripcion == "Asistente").Key.ObtenerNombreCompleto();
        //    }
        //    set
        //    {
        //        if (value == null) 
        //            throw new ArgumentNullException(nameof(value));
        //    }
        //}

        //public double PuntajeArbitroPrincipal
        //{
        //    get
        //    {
        //        if (CalificacionesArbitros.Count != 0)
        //            return CalificacionesArbitros
        //                .FirstOrDefault(x => ((BE.TipoArbitro) x.Key).Descripcion == "Principal").Value
        //                .ObtenerPuntajeTotal();
        //        else
        //            return 0;
        //    }
        //    set
        //    {
        //        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        //    }
        //}

        //public double PuntajeArbitroAsistente
        //{
        //    get
        //    {
        //        if (CalificacionesArbitros.Count != 0)
        //            return CalificacionesArbitros
        //                .FirstOrDefault(x => ((BE.TipoArbitro) x.Key).Descripcion == "Asistente").Value
        //                .ObtenerPuntajeTotal();
        //        else
        //            return 0;
        //    }
        //    set
        //    {
        //        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        //    }
        //}

        public Dictionary<BE.Arbitro, BE.TipoArbitro> ArbitrosYTipos { get; set; }

        public Dictionary<BE.TipoArbitro, BE.Calificacion> CalificacionesArbitros { get; set; }

        public Partido()
        {
            //ArbitrosYTipos = new Dictionary<Arbitro, TipoArbitro>();
            //CalificacionesArbitros =  new Dictionary<TipoArbitro, Calificacion>();
        }

        public int CompareTo(Partido otherMatch)
        {
            if (this.Prioridad > otherMatch.Prioridad)
            {
                return 1;
            }
            else
            {
                return -1;
            }
               
        }
    }
}
