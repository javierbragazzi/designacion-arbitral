using System;
using System.Collections.Generic;
using System.Data;
using DA.BE;
using DA.SS;

namespace DA.DAL
{
    /// <summary>
    /// Clase DAL de Usuario
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un usuario.
        /// </summary>
        /// <param name="pUsuario">Usuario.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Usuario pUsuario)
        {

            return _accesoBaseDeDatos.Insertar(pUsuario);
        }

 
        /// <summary>
        /// Actualiza un usuario.
        /// </summary>
        /// <param name="pUsuario">Usuario.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Usuario pUsuario)
        {
            return _accesoBaseDeDatos.Actualizar(pUsuario); 
        }

        /// <summary>
        /// Borra un usuario.
        /// </summary>
        /// <param name="pUsuario">Usuario.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Usuario pUsuario)
        {
            return _accesoBaseDeDatos.Borrar(pUsuario);
        }

        /// <summary>
        /// Obtiene un usuario por nombre de usuario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario.</param>
        /// <returns></returns>
        public BE.Usuario ObtenerUsuarioPorNombreDeUsuario(string nombreUsuario)
        {
            var dtUsuario = _accesoBaseDeDatos.Seleccionar(new BE.Usuario(){NombreUsuario = nombreUsuario, Activo = null}, true);
     
            if (dtUsuario.Rows.Count == 0)
                return null;

            var row = dtUsuario.Rows[0];
            var aUsuario = new BE.Usuario
            {
                Id = Convert.ToInt32(row["Id"]),
                Nombre = row["Nombre"].ToString().Trim(),
                Apellido = row["Apellido"].ToString().Trim(),
                NombreUsuario = row["NombreUsuario"].ToString().Trim(),
                Password = row["Password"].ToString().Trim(),
                Activo = Convert.ToBoolean(row["Activo"]),
                Idioma = new BE.Idioma() { Id = Convert.ToInt32(row["IdIdioma"]) },
                DVH = row["DVH"].ToString().Trim(),
            };

            aUsuario.NombreCompleto = aUsuario.Nombre + " " + aUsuario.Apellido;

            //var dtPerfil = _accesoBaseDeDatos.Seleccionar(new BE.Usuario() { NombreUsuario = nombreUsuario, Activo = null });

            return aUsuario;

        }

        public BE.Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            var dtUsuario = _accesoBaseDeDatos.Seleccionar(new BE.Usuario(){Id = idUsuario, Activo = null}, true);
     
            if (dtUsuario.Rows.Count == 0)
                return null;

            var row = dtUsuario.Rows[0];
            var aUsuario = new BE.Usuario
            {
                Id = Convert.ToInt32(row["Id"]),
                Nombre = row["Nombre"].ToString().Trim(),
                Apellido = row["Apellido"].ToString().Trim(),
                NombreUsuario = row["NombreUsuario"].ToString().Trim(),
                Password = row["Password"].ToString().Trim(),
                Activo = Convert.ToBoolean(row["Activo"]),
                Idioma = new BE.Idioma() { Id = Convert.ToInt32(row["IdIdioma"]) },
                DVH = row["DVH"].ToString().Trim(),
            };

            aUsuario.NombreCompleto = aUsuario.Nombre + " " + aUsuario.Apellido;

            //var dtPerfil = _accesoBaseDeDatos.Seleccionar(new BE.Usuario() { NombreUsuario = nombreUsuario, Activo = null });

            return aUsuario;

        }

        public List<BE.Usuario> Leer()
        {
            var ls = new List<BE.Usuario>();

            BE.Usuario beUsuario = new BE.Usuario();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Usuario(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aUsuario = new BE.Usuario
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = row["Nombre"].ToString().Trim(),
                    Apellido = row["Apellido"].ToString().Trim(),
                    NombreUsuario = row["NombreUsuario"].ToString().Trim(),
                    Password = row["Password"].ToString().Trim(),
                    Activo = Convert.ToBoolean(row["Activo"]),
                    Idioma = new BE.Idioma() { Id = Convert.ToInt32(row["IdIdioma"]) },
                    DVH = row["DVH"].ToString().Trim(),
                };

                aUsuario.NombreCompleto = aUsuario.Nombre + " " + aUsuario.Apellido;

                ls.Add(aUsuario);
            }

            return ls;
        }

    }

}
