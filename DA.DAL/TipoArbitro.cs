using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class TipoArbitro
    {
         /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un TipoArbitro.
        /// </summary>
        /// <param name="pTipoArbitro">TipoArbitro.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.TipoArbitro pTipoArbitro)
        {

            return _accesoBaseDeDatos.Insertar(pTipoArbitro);
        }
        
        /// <summary>
        /// Actualiza un TipoArbitro.
        /// </summary>
        /// <param name="pTipoArbitro">TipoArbitro.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.TipoArbitro pTipoArbitro)
        {
            return _accesoBaseDeDatos.Actualizar(pTipoArbitro); 
        }

        /// <summary>
        /// Borra un TipoArbitro.
        /// </summary>
        /// <param name="pTipoArbitro">TipoArbitro.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.TipoArbitro pTipoArbitro)
        {
            return _accesoBaseDeDatos.Borrar(pTipoArbitro);
        }

       
        public BE.TipoArbitro ObtenerTipoArbitroPorId(int idTipoArbitro)
        {
            var dtTipoArbitro = _accesoBaseDeDatos.Seleccionar(new BE.TipoArbitro(){Id = idTipoArbitro}, true);
     
            if (dtTipoArbitro.Rows.Count == 0)
                return null;

            var row = dtTipoArbitro.Rows[0];
            var aTipoArbitro = new BE.TipoArbitro
            {
                Id = Convert.ToInt32(row["Id"]),
                Descripcion  = row["Descripcion"].ToString().Trim(),
                Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
                
            };

            return aTipoArbitro;

        }

        public List<BE.TipoArbitro> Leer()
        {
            var ls = new List<BE.TipoArbitro>();

            BE.TipoArbitro beTipoArbitro = new BE.TipoArbitro();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.TipoArbitro(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aTipoArbitro = new BE.TipoArbitro
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion  = row["Descripcion"].ToString().Trim(),
                    Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },

                };

                ls.Add(aTipoArbitro);
            }

            return ls;
        }

        public BE.TipoArbitro ObtenerTipoArbitroPorPartidoYArbitroId(int idPartido, int idArbitro)
        {
            var ls = new List<BE.TipoArbitro>();
            var pars = new IDbDataParameter[2];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPartido", idPartido);
            pars[1] = _accesoBaseDeDatos.CrearParametro("@IdArbitro", idArbitro);

            string query = @"   select ta.*
                                from TipoArbitro ta,
		                             PartidoArbitro pa
                                where ta.Id = pa.IdTipoArbitro
                                and   pa.IdPartido = @IdPartido	                            
                                and   pa.IdArbitro = @IdArbitro
	                            ";

            var dt = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dt.Rows.Count == 0)
                return null;
            var row = dt.Rows[0];
         //   foreach (DataRow row in dt.Rows)
         //   {
                var aTipoArbitro = new BE.TipoArbitro
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion  = row["Descripcion"].ToString().Trim(),
                    Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
                    
                };

                //ls.Add(aTipoArbitro);
            //}

            return aTipoArbitro;
          
        }
    }
}
