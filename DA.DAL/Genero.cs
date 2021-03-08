using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class Genero
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Genero.
        /// </summary>
        /// <param name="pGenero">Genero.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Genero pGenero)
        {

            return _accesoBaseDeDatos.Insertar(pGenero);
        }

        /// <summary>
        /// Actualiza un Genero.
        /// </summary>
        /// <param name="pGenero">Genero.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Genero pGenero)
        {
            return _accesoBaseDeDatos.Actualizar(pGenero);
        }

        /// <summary>
        /// Borra un Genero.
        /// </summary>
        /// <param name="pGenero">Genero.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Genero pGenero)
        {
            return _accesoBaseDeDatos.Borrar(pGenero);
        }


        public BE.Genero ObtenerGeneroPorId(int idGenero)
        {
            //var dtGenero = _accesoBaseDeDatos.Seleccionar(new BE.Genero() {Id = idGenero}, true);
            var dtGenero = _accesoBaseDeDatos.Seleccionar(new BE.Genero() {Id = idGenero}, true, true);

            if (dtGenero.Rows.Count == 0)
                return null;

            var row = dtGenero.Rows[0];
            var aGenero = new BE.Genero
            {
                Id = Convert.ToInt32(row["Id"]),
                Descripcion = row["Descripcion"].ToString().Trim(),

            };

            return aGenero;

        }

        public List<BE.Genero> Leer()
        {
            var ls = new List<BE.Genero>();

            BE.Genero beGenero = new BE.Genero();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Genero(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aGenero = new BE.Genero
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion = row["Descripcion"].ToString().Trim(),

                };

                ls.Add(aGenero);
            }

            return ls;
        }

    }
}
