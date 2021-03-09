using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class PartidoArbitro
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un PartidoArbitro.
        /// </summary>
        /// <param name="pPartidoArbitro">PartidoArbitro.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.PartidoArbitro pPartidoArbitro)
        {
            //INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (1, 1, 1, 9, 0)
            string query = string.Format(@"INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES ({0},{1},{2},{3},'{4}')",
                pPartidoArbitro.Partido.Id,
                pPartidoArbitro.Arbitro.Id,
                pPartidoArbitro.TipoArbitro.Id,
                pPartidoArbitro.Calificacion == null ? "NULL" : pPartidoArbitro.Calificacion.Id.ToString(),
                pPartidoArbitro.Procesado.ToString()
            );

            return _accesoBaseDeDatos.Ejecutar(query);
        }
        
        /// <summary>
        /// Actualiza un PartidoArbitro.
        /// </summary>
        /// <param name="pPartidoArbitro">PartidoArbitro.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.PartidoArbitro pPartidoArbitro)
        {
            return _accesoBaseDeDatos.Actualizar(pPartidoArbitro); 
        }

        /// <summary>
        /// Borra un PartidoArbitro.
        /// </summary>
        /// <param name="pPartidoArbitro">PartidoArbitro.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.PartidoArbitro pPartidoArbitro)
        {
            return _accesoBaseDeDatos.Borrar(pPartidoArbitro);
        }

       
        public List<BE.PartidoArbitro> Leer()
        {
            var ls = new List<BE.PartidoArbitro>();

            string query = @"SELECT *
                             FROM PartidoArbitro";

            var dt = _accesoBaseDeDatos.Seleccionar(query);

            foreach (DataRow row in dt.Rows)
            {
                var aPartidoArbitro = new BE.PartidoArbitro
                {
                    TipoArbitro  = new BE.TipoArbitro(){ Id = Convert.ToInt32(row["IdTipoArbitro"])},
                    Arbitro  = new BE.Arbitro(){ Id = Convert.ToInt32(row["IdArbitro"])},
                    Partido = new BE.Partido(){ Id = Convert.ToInt32(row["IdPartido"])},
                    Procesado = Convert.ToBoolean(row["Procesado"].ToString().Trim()),

                };

                aPartidoArbitro.Calificacion = Convert.IsDBNull(row["IdCalificacion"]) ? null : new BE.Calificacion(){ Id = Convert.ToInt32(row["IdCalificacion"])};

                ls.Add(aPartidoArbitro);
            }

            return ls;
        }

        public List<BE.PartidoArbitro> ObtenerPartidoArbitroPorPartidoId(int idPartido)
        {
            var ls = new List<BE.PartidoArbitro>();
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPartido", idPartido);

            string query = @"   select ta.*
                                from PartidoArbitro ta
                                where ta.IdPartido = @IdPartido";

            var dt = _accesoBaseDeDatos. Seleccionar(query, pars);

            if (dt.Rows.Count == 0)
                return null;
         
            foreach (DataRow row in dt.Rows)
            {
                var aPartidoArbitro = new BE.PartidoArbitro
                {
                    TipoArbitro  = new BE.TipoArbitro(){ Id = Convert.ToInt32(row["IdTipoArbitro"])},
                    Arbitro  = new BE.Arbitro(){ Id = Convert.ToInt32(row["IdArbitro"])},
                    Partido = new BE.Partido(){ Id = Convert.ToInt32(row["IdPartido"])},
                    Procesado = Convert.ToBoolean(row["Procesado"].ToString().Trim()),

                };
                aPartidoArbitro.Calificacion = Convert.IsDBNull(row["IdCalificacion"]) ? null : new BE.Calificacion(){ Id = Convert.ToInt32(row["IdCalificacion"])};

                ls.Add(aPartidoArbitro);
            }

            return ls;

        }

        public List<BE.PartidoArbitro> ObtenerPartidosArbitroPorArbitroId(int idArbitro)
        {
            var ls = new List<BE.PartidoArbitro>();
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdArbitro", idArbitro);

            string query = @"   select ta.*
                                from PartidoArbitro ta
                                where ta.IdArbitro = @IdArbitro";

            var dt = _accesoBaseDeDatos. Seleccionar(query, pars);

            if (dt.Rows.Count == 0)
                return null;
         
            foreach (DataRow row in dt.Rows)
            {
                var aPartidoArbitro = new BE.PartidoArbitro
                {
                    TipoArbitro  = new BE.TipoArbitro(){ Id = Convert.ToInt32(row["IdTipoArbitro"])},
                    Arbitro  = new BE.Arbitro(){ Id = Convert.ToInt32(row["IdArbitro"])},
                    Partido = new BE.Partido(){ Id = Convert.ToInt32(row["IdPartido"])},
                    Procesado = Convert.ToBoolean(row["Procesado"].ToString().Trim()),

                };
                aPartidoArbitro.Calificacion = Convert.IsDBNull(row["IdCalificacion"]) ? null : new BE.Calificacion(){ Id = Convert.ToInt32(row["IdCalificacion"])};

                ls.Add(aPartidoArbitro);
            }

            return ls;

        }

        public BE.PartidoArbitro ObtenerPartidoArbitroPorPartidoIdYArbitroId(int idPartido, int idArbitro)
        {
            var ls = new List<BE.PartidoArbitro>();
            var pars = new IDbDataParameter[2];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPartido", idPartido);
            pars[1] = _accesoBaseDeDatos.CrearParametro("@IdArbitro", idArbitro);

            string query = @"   select pa.*
                                from PartidoArbitro pa
                                where   pa.IdPartido = @IdPartido	                            
                                and   pa.IdArbitro = @IdArbitro
                             ";

            var dt = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dt.Rows.Count == 0)
                return null;
            var row = dt.Rows[0];
       
            var aPartidoArbitro = new BE.PartidoArbitro
            {
                TipoArbitro  = new BE.TipoArbitro(){ Id = Convert.ToInt32(row["IdTipoArbitro"])},
                Arbitro  = new BE.Arbitro(){ Id = Convert.ToInt32(row["IdArbitro"])},
                Partido = new BE.Partido(){ Id = Convert.ToInt32(row["IdPartido"])},
                Procesado = Convert.ToBoolean(row["Procesado"].ToString().Trim()),

            };

            aPartidoArbitro.Calificacion = Convert.IsDBNull(row["IdCalificacion"]) ? null : new BE.Calificacion(){ Id = Convert.ToInt32(row["IdCalificacion"])};

            return aPartidoArbitro;

        }
    }
}
