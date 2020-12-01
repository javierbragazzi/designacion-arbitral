using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class NivelRegla
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un NivelRegla.
        /// </summary>
        /// <param name="pNivelRegla">NivelRegla.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.NivelRegla pNivelRegla)
        {

            return _accesoBaseDeDatos.Insertar(pNivelRegla);
        }

 
        /// <summary>
        /// Actualiza un NivelRegla.
        /// </summary>
        /// <param name="pNivelRegla">NivelRegla.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.NivelRegla pNivelRegla)
        {
            return _accesoBaseDeDatos.Actualizar(pNivelRegla); 
        }

        /// <summary>
        /// Borra un NivelRegla.
        /// </summary>
        /// <param name="pNivelRegla">NivelRegla.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.NivelRegla pNivelRegla)
        {
            return _accesoBaseDeDatos.Borrar(pNivelRegla);
        }

       
        public BE.NivelRegla ObtenerNivelReglaPorId(int idNivelRegla)
        {
            var dtNivelRegla = _accesoBaseDeDatos.Seleccionar(new BE.NivelRegla(){Id = idNivelRegla}, true);
     
            if (dtNivelRegla.Rows.Count == 0)
                return null;

            var row = dtNivelRegla.Rows[0];
            var aNivelRegla = new BE.NivelRegla
            {
                Id = Convert.ToInt32(row["Id"]),
                //NombreNivel  = row["NombreNivel"].ToString().Trim(),
                Categoria = new BE.Categoria() { Id = Convert.ToInt32(row["IdCategoria"]) },
                TipoArbitro = new BE.TipoArbitro() { Id = Convert.ToInt32(row["IdTipoArbitro"]) },
     
            };

            return aNivelRegla;

        }

        public List<BE.NivelRegla> ObtenerReglasPorNivelId(int idNivel)
        {
            var ls = new List<BE.NivelRegla>();
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdNivel", idNivel);

            string query = @"Select *
                             from NivelRegla nr
                             where nr.IdNivel =  @IdNivel";

            var dt = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dt.Rows.Count == 0)
                return null;

            foreach (DataRow row in dt.Rows)
            {
                var aNivelRegla = new BE.NivelRegla
                {
                    Id = Convert.ToInt32(row["Id"]),
                    //NombreNivel  = row["NombreNivel"].ToString().Trim(),
                    Categoria = new BE.Categoria() { Id = Convert.ToInt32(row["IdCategoria"]) },
                    TipoArbitro = new BE.TipoArbitro() { Id = Convert.ToInt32(row["IdTipoArbitro"]) },
                };

                ls.Add(aNivelRegla);
            }

            return ls;
        }

        public List<BE.NivelRegla> Leer()
        {
            var ls = new List<BE.NivelRegla>();

            BE.NivelRegla beNivelRegla = new BE.NivelRegla();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.NivelRegla(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aNivelRegla = new BE.NivelRegla
                {
                    Id = Convert.ToInt32(row["Id"]),
                    //NombreNivel  = row["NombreNivel"].ToString().Trim(),
                    Categoria = new BE.Categoria() { Id = Convert.ToInt32(row["IdCategoria"]) },
                    TipoArbitro = new BE.TipoArbitro() { Id = Convert.ToInt32(row["IdTipoArbitro"]) },
                };

                ls.Add(aNivelRegla);
            }

            return ls;
        }
    }
}
