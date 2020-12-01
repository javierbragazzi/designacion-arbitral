using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.DAL;
using DA.SS;

namespace DA.DAL
{
    public class UsuarioPermiso
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un UsuarioPermiso.
        /// </summary>
        /// <param name="pUsuarioPermiso">UsuarioPermiso.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.UsuarioPermiso pUsuarioPermiso)
        {

            return _accesoBaseDeDatos.Insertar(pUsuarioPermiso);
        }


        /// <summary>
        /// Actualiza un UsuarioPermiso.
        /// </summary>
        /// <param name="pUsuarioPermiso">UsuarioPermiso.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.UsuarioPermiso pUsuarioPermiso)
        {
            return _accesoBaseDeDatos.Actualizar(pUsuarioPermiso);
        }

        /// <summary>
        /// Borra un UsuarioPermiso.
        /// </summary>
        /// <param name="pUsuarioPermiso">UsuarioPermiso.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.UsuarioPermiso pUsuarioPermiso)
        {
            return _accesoBaseDeDatos.Borrar(pUsuarioPermiso);
        }
    }
}
