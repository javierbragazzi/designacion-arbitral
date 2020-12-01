using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class Traduccion
    {
         /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Traduccion.
        /// </summary>
        /// <param name="pTraduccion">Traduccion.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Traduccion pTraduccion)
        {

            return _accesoBaseDeDatos.Insertar(pTraduccion);
        }


        /// <summary>
        /// Actualiza un Traduccion.
        /// </summary>
        /// <param name="pTraduccion">Traduccion.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Traduccion pTraduccion)
        {
            return _accesoBaseDeDatos.Actualizar(pTraduccion);
        }

        /// <summary>
        /// Borra un Traduccion.
        /// </summary>
        /// <param name="pTraduccion">Traduccion.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Traduccion pTraduccion)
        {
            return _accesoBaseDeDatos.Borrar(pTraduccion);
        }

        public List<BE.Traduccion> Leer()
        {
            var ls = new List<BE.Traduccion>();

            BE.Traduccion beTraduccion = new BE.Traduccion();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Traduccion(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aTraduccion = new BE.Traduccion
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TextoTraducido = row["TextoTraducido"].ToString().Trim(),
                };

                ls.Add(aTraduccion);
            }

            return ls;
        }
    }
    
}
