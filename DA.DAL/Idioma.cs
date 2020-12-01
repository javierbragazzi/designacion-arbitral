using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class Idioma
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Idioma.
        /// </summary>
        /// <param name="pIdioma">Idioma.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Idioma pIdioma)
        {

            return _accesoBaseDeDatos.Insertar(pIdioma);
        }


        /// <summary>
        /// Actualiza un Idioma.
        /// </summary>
        /// <param name="pIdioma">Idioma.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Idioma pIdioma)
        {
            return _accesoBaseDeDatos.Actualizar(pIdioma);
        }

        /// <summary>
        /// Borra un Idioma.
        /// </summary>
        /// <param name="pIdioma">Idioma.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Idioma pIdioma)
        {
            return _accesoBaseDeDatos.Borrar(pIdioma);
        }

        /// <summary>
        /// Obtiene un Idioma por Id de Idioma.
        /// </summary>
        /// <param name="idIdioma">Nombre del Idioma.</param>
        /// <returns></returns>
        public BE.Idioma ObtenerIdiomaPorId(int idIdioma)
        {
            var dtIdioma = _accesoBaseDeDatos.Seleccionar(new BE.Idioma() { Id = idIdioma }, true);

            if (dtIdioma.Rows.Count == 0)
                return null;

            var row = dtIdioma.Rows[0];
            var aIdioma = new BE.Idioma
            {
                Id = Convert.ToInt32(row["Id"]),
                Descripcion = row["Descripcion"].ToString().Trim(),

            };

            return aIdioma;

        }

        public BE.Idioma ObtenerIdiomaDeUsuario(int idUsuario)
        {
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdUsuario", idUsuario);

            string query = @"SELECT idi.*
                            FROM Usuario usu
                            INNER JOIN Idioma idi ON ( usu.IdIdioma = idi.Id )
                            WHERE usu.Id = @IdUsuario ";

            var dtIdioma = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dtIdioma.Rows.Count == 0)
                return null;

            var row = dtIdioma.Rows[0];
            var aIdioma = new BE.Idioma
            {
                Id = Convert.ToInt32(row["Id"]),
                Descripcion = row["Descripcion"].ToString().Trim(),
                

            };

            return aIdioma;

        }

        public List<BE.Idioma> Leer()
        {
            var ls = new List<BE.Idioma>();

            BE.Idioma beIdioma = new BE.Idioma();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Idioma(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aIdioma = new BE.Idioma
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion = row["Descripcion"].ToString().Trim(),
                };

                ls.Add(aIdioma);
            }

            return ls;
        }

    }
}
