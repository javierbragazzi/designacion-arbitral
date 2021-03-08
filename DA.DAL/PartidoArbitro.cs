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

            return _accesoBaseDeDatos.Insertar(pPartidoArbitro);
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

            BE.PartidoArbitro bePartidoArbitro = new BE.PartidoArbitro();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.PartidoArbitro(), false);

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

        public List<BE.PartidoArbitro> ObtenerPartidoArbitroPorArbitroId(int idArbitro)
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

        //public BE.PartidoArbitro ObtenerPartidoArbitroPorPartidoYArbitroId(int idPartido, int idArbitro)
        //{
        //    var ls = new List<BE.PartidoArbitro>();
        //    var pars = new IDbDataParameter[2];
        //    pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPartido", idPartido);
        //    pars[1] = _accesoBaseDeDatos.CrearParametro("@IdArbitro", idArbitro);

        //    string query = @"   select ta.*
        //                        from PartidoArbitro ta,
        //                       PartidoArbitro pa
        //                        where ta.Id = pa.IdPartidoArbitro
        //                        and   pa.IdPartido = @IdPartido	                            
        //                        and   pa.IdArbitro = @IdArbitro
        //                     ";

        //    var dt = _accesoBaseDeDatos.Seleccionar(query, pars);

        //    if (dt.Rows.Count == 0)
        //        return null;
        //    var row = dt.Rows[0];
        // //   foreach (DataRow row in dt.Rows)
        // //   {
        //        var aPartidoArbitro = new BE.PartidoArbitro
        //        {
        //            Id = Convert.ToInt32(row["Id"]),
        //            Descripcion  = row["Descripcion"].ToString().Trim(),
        //            Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },

        //        };

        //        //ls.Add(aPartidoArbitro);
        //    //}

        //    return aPartidoArbitro;

        //}
    }
}
