using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.SS;

namespace DA.DAL
{
    public class Deporte
    {
         /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Deporte.
        /// </summary>
        /// <param name="pDeporte">Deporte.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Deporte pDeporte)
        {

            return _accesoBaseDeDatos.Insertar(pDeporte);
        }

 
        /// <summary>
        /// Actualiza un Deporte.
        /// </summary>
        /// <param name="pDeporte">Deporte.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Deporte pDeporte)
        {
            return _accesoBaseDeDatos.Actualizar(pDeporte); 
        }

        /// <summary>
        /// Borra un Deporte.
        /// </summary>
        /// <param name="pDeporte">Deporte.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Deporte pDeporte)
        {
            return _accesoBaseDeDatos.Borrar(pDeporte);
        }

       
        public BE.Deporte ObtenerDeportePorId(int idDeporte)
        {
            var dtDeporte = _accesoBaseDeDatos.Seleccionar(new BE.Deporte(){Id = idDeporte}, true);
     
            if (dtDeporte.Rows.Count == 0)
                return null;

            var row = dtDeporte.Rows[0];
            var aDeporte = new BE.Deporte
            {
                Id = Convert.ToInt32(row["Id"]),
                Descripcion  = row["Descripcion"].ToString().Trim(),

            };

            return aDeporte;

        }

        public List<BE.Deporte> Leer()
        {
            var ls = new List<BE.Deporte>();

            BE.Deporte beDeporte = new BE.Deporte();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Deporte(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aDeporte = new BE.Deporte
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion  = row["Descripcion"].ToString().Trim(),

                };

                ls.Add(aDeporte);
            }

            return ls;
        }

    }
}
