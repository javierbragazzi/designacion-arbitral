using System;

namespace DA.BE
{

    [Tabla("Calificacion")]
    public class Calificacion : EntidadBase
    {
        public int ReglasPuntaje
        {
            [Columna("ReglasPuntaje", "ReglasPuntaje", typeof(int), false, false)]
            get;
            set;
        }

        public int DisciplinaPuntaje
        {
            [Columna("DisciplinaPuntaje", "DisciplinaPuntaje", typeof(int), false, false)]
            get;
            set;
        }

        public int CondicionFisicaPuntaje
        {
            [Columna("CondicionFisicaPuntaje", "CondicionFisicaPuntaje", typeof(int), false, false)]
            get;
            set;
        }

        public int JugadasPuntaje
        {
            [Columna("JugadasPuntaje", "JugadasPuntaje", typeof(int), false, false)]
            get;
            set;
        }

        public double DificultadPartidoPuntaje
        {
            [Columna("DificultadPartidoPuntaje", "DificultadPartidoPuntaje", typeof(int), false, false)]
            get;
            set;
        }
        

        public double ObtenerPuntajeTotal()
        {
            double prom = (ReglasPuntaje + DisciplinaPuntaje + CondicionFisicaPuntaje + JugadasPuntaje) / 4;

            prom += DificultadPartidoPuntaje;

            if (prom > 10)
                return 10;
            else
                return Truncate(prom, 2);


        }

        private float Truncate(double value, int digits)
        {
            double mult = Math.Pow(10.0, digits);
            double result = Math.Truncate( mult * value ) / mult;
            return (float) result;
        }

    }
}
