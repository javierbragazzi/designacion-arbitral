using System;
using System.Collections.Generic;

namespace DA.BE
{
    [Tabla("Arbitro")]
    public class Arbitro : EntidadBase, IComparable<Arbitro>
    {

        public string Nombre
        {
            [Columna("Nombre", "Nombre", typeof(string), false, false)]
            get;
            set;
        }

        public string Apellido
        {
            [Columna("Apellido", "Apellido", typeof(string), false, false)]
            get;
            set;
        }

        public DateTime FechaNacimiento
        {
            [Columna("FechaNacimiento", "FechaNacimiento", typeof(string), false, false)]
            get;
            set;
        }

        public Genero Genero
        {
            [Columna("Genero", "Genero", typeof(string), false, false)]
            get;
            set;
        }

        public string DNI
        {
            [Columna("Dni", "DNI", typeof(string), false, false)]
            get;
            set;
        }

        public int Ranking
        {
            [Columna("Ranking", "Ranking", typeof(int), false, false)]
            get;
            set;
        }

        public int AniosExperiencia
        {
            [Columna("AniosExperiencia", "AniosExperiencia", typeof(int), false, false)]
            get;
            set;
        }

        public int NotaAFA
        {
            [Columna("NotaAFA", "NotaAFA", typeof(int), false, false)]
            get;
            set;
        }

        public Nivel Nivel
        {
            [Columna("IdNivel", "Nivel", typeof(int), false, false)]
            get;
            set;
        }

        public Deporte Deporte
        {
            [Columna("IdDeporte", "Deporte", typeof(int), false, false)]
            get;
            set;
        }

        public bool? Habilitado
        {
            [Columna("Habilitado", "Habilitado", typeof(bool?), false, false)]
            get;
            set;
        }

        public bool? PoseeTituloValidoArgentina
        {
            [Columna("PoseeTituloValidoArgentina", "PoseeTituloValidoArgentina", typeof(bool?), false, false)]
            get;
            set;
        }

        public bool? PoseeLicenciaInternacional
        {
            [Columna("PoseeLicenciaInternacional", "PoseeLicenciaInternacional", typeof(bool?), false, false)]
            get;
            set;
        }

        public bool? ExamenFisicoAprobado
        {
            [Columna("ExamenFisicoAprobado", "ExamenFisicoAprobado", typeof(bool?), false, false)]
            get;
            set;
        }
        public bool? ExamenTeoricoAprobado
        {
            [Columna("ExamenTeoricoAprobado", "ExamenTeoricoAprobado", typeof(bool?), false, false)]
            get;
            set;
        }

        public string NombreCompleto => Nombre + " " + Apellido;

        public string ObtenerNombreCompleto()
        {
            return Nombre + " " + Apellido;
        }

        public string NombreCompletoTipoArbitro { get; set; }
        
        public Queue<Equipo> UltimosEquiposDirigidos { get; set; }

        public Queue<Partido> UltimosPartidosDirigidos { get; set; }


        public Arbitro() {
            this.UltimosPartidosDirigidos = new Queue<Partido>();
            this.UltimosEquiposDirigidos = new Queue<Equipo>();
        }

        public int CompareTo(BE.Arbitro otroArbitro)
        {
            if (this.Ranking > otroArbitro.Ranking)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public int CompareTo(BE.Deporte deporte)
        {
            return String.Compare(this.Deporte.Descripcion, deporte.Descripcion, StringComparison.CurrentCulture);
        }


        public override int GetHashCode()
        {

            return Id;
        }

        public static bool operator ==(BE.Arbitro left, BE.Arbitro right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BE.Arbitro left, BE.Arbitro right)
        {
            return !Equals(left, right);
        }

    }
}
