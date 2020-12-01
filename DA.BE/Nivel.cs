using System.Collections.Generic;

namespace DA.BE
{
    [Tabla("Nivel")]
    public class Nivel : EntidadBase
    {
        public string NombreNivel
        {
            [Columna("NombreNivel", "NombreNivel", typeof(string), false, false)]
            get;
            set;
        }

        public Deporte Deporte
        {
            [Columna("IdDeporte", "Deporte", typeof(int), false, false)]
            get;
            set;
        }

        public List<NivelRegla> ReglasDeNivel { get; set; }

    }
}
