using System;
using DA.BE;

namespace DA.SS
{
    /// <summary>
    /// Clase Sesion
    /// </summary>
    public class Sesion
    {
        /// <summary>
        /// Gets or sets the usuario.
        /// </summary>
        /// <value>
        /// The usuario.
        /// </value>
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Gets or sets the fecha inicio sesion.
        /// </summary>
        /// <value>
        /// The fecha inicio sesion.
        /// </value>
        public DateTime FechaInicioSesion { get; set; }

        public EstadoBaseDeDatos EstadoBaseDeDatos { get; set; }    
    }
}
