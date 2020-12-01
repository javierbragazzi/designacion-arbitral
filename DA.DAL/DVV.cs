using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class DVV
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un DVV.
        /// </summary>
        /// <param name="pDVV">DVV.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.DVV pDVV)
        {

            return _accesoBaseDeDatos.Insertar(pDVV);
        }


        /// <summary>
        /// Actualiza un DVV.
        /// </summary>
        /// <param name="pDVV">DVV.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.DVV pDVV)
        {
            return _accesoBaseDeDatos.Actualizar(pDVV);
        }

        /// <summary>
        /// Borra un DVV.
        /// </summary>
        /// <param name="pDVV">DVV.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.DVV pDVV)
        {
            return _accesoBaseDeDatos.Borrar(pDVV);
        }

        /// <summary>
        /// Obtiene un DVV por nombre de tabla.
        /// </summary>
        /// <param name="nombreTabla">Nombre del DVV.</param>
        /// <returns></returns>
        public BE.DVV ObtenerDVVPorNombreDeTabla(string nombreTabla)
        {
            var dtDVV = _accesoBaseDeDatos.Seleccionar(new BE.DVV() { NombreTabla = nombreTabla }, true);

            if (dtDVV.Rows.Count == 0)
                return null;

            var row = dtDVV.Rows[0];
            var aDVV = new BE.DVV
            {
                Id = Convert.ToInt32(row["Id"]),
                NombreTabla = row["NombreTabla"].ToString().Trim(),
                Valor = row["Valor"].ToString().Trim(),
               
            };

            return aDVV;

        }

        public List<BE.DVV> Leer()
        {
            var ls = new List<BE.DVV>();

            BE.DVV beDVV = new BE.DVV();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.DVV(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aDVV = new BE.DVV
                {
                    Id = Convert.ToInt32(row["Id"]),
                    NombreTabla = row["NombreTabla"].ToString().Trim(),
                    Valor = row["Valor"].ToString().Trim(),
                };

                ls.Add(aDVV);
            }

            return ls;
        }

    }
}
