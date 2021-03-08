namespace DA.SS
{
    public class PuntajeArbitro
    {
        public int IdArbitro { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public int IdNivel { get; set; }

        public string NombreNivel { get; set; }

        public int CantidadPartidos { get; set; }

        public double PuntajePromedio { get; set; }

        public Situacion Situacion { get; set; }

        public int IdNivelNuevo { get; set; }

        public string NombreNivelNuevo { get; set; }

        public string Motivo { get; set; }

        public string NombreCompleto => Nombre + " " + Apellido;

        public string ObtenerNombreCompleto()
        {
            return Nombre + " " + Apellido;
        }

    }
}
