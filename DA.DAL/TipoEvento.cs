using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{

    public class TipoEvento
    {
         /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un TipoEvento.
        /// </summary>
        /// <param name="pTipoEvento">TipoEvento.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.TipoEvento pTipoEvento)
        {

            return _accesoBaseDeDatos.Insertar(pTipoEvento);
        }
        
        /// <summary>
        /// Actualiza un TipoEvento.
        /// </summary>
        /// <param name="pTipoEvento">TipoEvento.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.TipoEvento pTipoEvento)
        {
            return _accesoBaseDeDatos.Actualizar(pTipoEvento); 
        }

        /// <summary>
        /// Borra un TipoEvento.
        /// </summary>
        /// <param name="pTipoEvento">TipoEvento.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.TipoEvento pTipoEvento)
        {
            return _accesoBaseDeDatos.Borrar(pTipoEvento);
        }

       
        public BE.TipoEvento ObtenerTipoEventoPorId(int idTipoEvento)
        {
            var dtTipoEvento = _accesoBaseDeDatos.Seleccionar(new BE.TipoEvento(){Id = idTipoEvento}, true);
     
            if (dtTipoEvento.Rows.Count == 0)
                return null;

            var row = dtTipoEvento.Rows[0];
            var aTipoEvento = new BE.TipoEvento
            {
                Id = Convert.ToInt32(row["Id"]),
                Descripcion  = row["Descripcion"].ToString().Trim(),

            };

            return aTipoEvento;

        }

        public List<BE.TipoEvento> Leer()
        {
            var ls = new List<BE.TipoEvento>();

            BE.TipoEvento beTipoEvento = new BE.TipoEvento();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.TipoEvento(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aTipoEvento = new BE.TipoEvento
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion  = row["Descripcion"].ToString().Trim(),

                };

                ls.Add(aTipoEvento);
            }

            return ls;
        }

    }
}
