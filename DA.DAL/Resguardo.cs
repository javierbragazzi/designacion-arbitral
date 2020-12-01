using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class Resguardo
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Resguardo.
        /// </summary>
        /// <param name="pResguardo">Resguardo.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Resguardo pResguardo)
        {

            return _accesoBaseDeDatos.Insertar(pResguardo);
        }


        /// <summary>
        /// Actualiza un Resguardo.
        /// </summary>
        /// <param name="pResguardo">Resguardo.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Resguardo pResguardo)
        {
            return _accesoBaseDeDatos.Actualizar(pResguardo);
        }

        /// <summary>
        /// Borra un Resguardo.
        /// </summary>
        /// <param name="pResguardo">Resguardo.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Resguardo pResguardo)
        {
            return _accesoBaseDeDatos.Borrar(pResguardo);
        }

        /// <summary>
        /// Obtiene un Resguardo por Id de Resguardo.
        /// </summary>
        /// <param name="idResguardo">Nombre del Resguardo.</param>
        /// <returns></returns>
        public BE.Resguardo ObtenerResguardoPorId(int idResguardo)
        {
            var dtResguardo = _accesoBaseDeDatos.Seleccionar(new BE.Resguardo() { Id = idResguardo }, true);

            if (dtResguardo.Rows.Count == 0)
                return null;

            var row = dtResguardo.Rows[0];
            var aResguardo = new BE.Resguardo
            {
                Id = Convert.ToInt32(row["Id"]),
                Directorio = row["Directorio"].ToString().Trim(),
                NombreArchivo = row["NombreArchivo"].ToString().Trim(),

            };

            return aResguardo;

        }
        
        public List<BE.Resguardo> Leer()
        {
            var ls = new List<BE.Resguardo>();

            BE.Resguardo beResguardo = new BE.Resguardo();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Resguardo(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aResguardo = new BE.Resguardo
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Directorio = row["Directorio"].ToString().Trim(),
                    NombreArchivo = row["NombreArchivo"].ToString().Trim(),
                };

                ls.Add(aResguardo);
            }

            return ls;
        }
    }
}
