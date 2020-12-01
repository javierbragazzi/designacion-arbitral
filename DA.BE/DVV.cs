namespace DA.BE
{
    /// <summary>
    /// Clase DVV
    /// </summary>
    /// <seealso cref="DA.BE.EntidadBase" />
    [Tabla("DVV")]
    public class DVV : EntidadBase
    {

        /// <summary>
        /// Gets or sets the nombre tabla.
        /// </summary>
        /// <value>
        /// The nombre tabla.
        /// </value>
        public string NombreTabla
        {
            [Columna("NombreTabla", "NombreTabla", typeof(string), false, false)]
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the valor.
        /// </summary>
        /// <value>
        /// The valor.
        /// </value>
        public string Valor
        {
            [Columna("Valor", "Valor", typeof(string), false, false)]
            get;
            set;
        }

    }
}
