using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.SS;

namespace DA.BLL
{
    public class UsuarioPermiso
    {
        /// <summary>
        /// Dal manager UsuarioPermiso
        /// </summary>
        private readonly DAL.UsuarioPermiso _dalManagerUsuarioPermiso = new DAL.UsuarioPermiso();

        /// <summary>
        /// Agrega un nuevo UsuarioPermiso al sistema.
        /// </summary>
        /// <param name="pUsuarioPermiso">UsuarioPermiso a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.UsuarioPermiso pUsuarioPermiso)
        {
            var resultado = _dalManagerUsuarioPermiso.Insertar(pUsuarioPermiso);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el UsuarioPermiso.");
        }

        /// <summary>
        /// Edita un UsuarioPermiso.
        /// </summary>
        /// <param name="pUsuarioPermiso">UsuarioPermiso a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.UsuarioPermiso pUsuarioPermiso)
        {
            ResultadoBd resultado = _dalManagerUsuarioPermiso.Actualizar(pUsuarioPermiso);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el UsuarioPermiso.");
        }

        /// <summary>
        /// Quita un UsuarioPermiso.
        /// </summary>
        /// <param name="pUsuarioPermiso">UsuarioPermiso a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.UsuarioPermiso pUsuarioPermiso)
        {
            ResultadoBd resultado = _dalManagerUsuarioPermiso.Borrar(pUsuarioPermiso);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el UsuarioPermiso.");

        }
    }
}
