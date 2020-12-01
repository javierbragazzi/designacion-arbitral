using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class Categoria
    {
         /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Categoria.
        /// </summary>
        /// <param name="pCategoria">Categoria.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Categoria pCategoria)
        {

            return _accesoBaseDeDatos.Insertar(pCategoria);
        }

 
        /// <summary>
        /// Actualiza un Categoria.
        /// </summary>
        /// <param name="pCategoria">Categoria.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Categoria pCategoria)
        {
            return _accesoBaseDeDatos.Actualizar(pCategoria); 
        }

        /// <summary>
        /// Borra un Categoria.
        /// </summary>
        /// <param name="pCategoria">Categoria.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Categoria pCategoria)
        {
            return _accesoBaseDeDatos.Borrar(pCategoria);
        }

       
        public BE.Categoria ObtenerCategoriaPorId(int idCategoria)
        {
            var dtCategoria = _accesoBaseDeDatos.Seleccionar(new BE.Categoria(){Id = idCategoria}, true, true);
     
            if (dtCategoria.Rows.Count == 0)
                return null;

            var row = dtCategoria.Rows[0];
            var aCategoria = new BE.Categoria
            {
                Id = Convert.ToInt32(row["Id"]),
                Descripcion  = row["Descripcion"].ToString().Trim(),
                Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
     
            };

            return aCategoria;

        }

        public List<BE.Categoria> Leer()
        {
            var ls = new List<BE.Categoria>();

            BE.Categoria beCategoria = new BE.Categoria();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Categoria(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aCategoria = new BE.Categoria
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion  = row["Descripcion"].ToString().Trim(),
                    Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
                };

                ls.Add(aCategoria);
            }

            return ls;
        }

        public List<BE.Categoria> ObtenerCategoriaPorDeporteId(int deporteId)
        {
            var ls = new List<BE.Categoria>();
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdDeporte", deporteId);

            string query = @" select *
                              from Categoria cat
                              where cat.IdDeporte =  @IdDeporte";

            var dt = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dt.Rows.Count == 0)
                return null;

            foreach (DataRow row in dt.Rows)
            {
                var aCategoria = new BE.Categoria
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion  = row["Descripcion"].ToString().Trim(),
                    Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
                };

                ls.Add(aCategoria);
            }

            return ls;
        }
    }
}
