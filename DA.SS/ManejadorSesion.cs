using System;
using DA.BE;

namespace DA.SS
{
    /// <summary>
    /// Clase para manejar las sesiones.
    /// </summary>
    public class ManejadorSesion
    {
        /// <summary>
        /// Instancia
        /// </summary>
        private static readonly ManejadorSesion _instancia = new ManejadorSesion();

        /// <summary>
        /// Sesion
        /// </summary>
        private Sesion _sesion;

        /// <summary>
        /// Prevents a default instance of the <see cref="ManejadorSesion" /> class from being created.
        /// </summary>
        private ManejadorSesion()
        {

        }

        /// <summary>
        /// Gets the instancia.
        /// </summary>
        /// <value>
        /// The instancia.
        /// </value>
        public static ManejadorSesion Instancia
        {
            get
            {
                return _instancia;
            }
        }

        /// <summary>
        /// Establece la sesion.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        public void EstablecerSesion(Usuario usuario, EstadoBaseDeDatos estadoBaseDeDatos)
        {
            _sesion = new Sesion
            {
                Usuario = usuario,
                FechaInicioSesion = DateTime.Now,
                EstadoBaseDeDatos = estadoBaseDeDatos
            };
        }

        /// <summary>
        /// Borra la sesion.
        /// </summary>
        public void BorrarSesion()
        {
            _sesion = null;
        }

        /// <summary>
        /// Obtiene la sesion actual.
        /// </summary>
        /// <returns></returns>
        public Sesion ObtenerSesion()
        {
            return _sesion;
        }
    }
}
