using System;

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
