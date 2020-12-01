using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class Fecha
    {
         /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Fecha.
        /// </summary>
        /// <param name="pFecha">Fecha.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Fecha pFecha)
        {

            return _accesoBaseDeDatos.Insertar(pFecha);
        }

 
        /// <summary>
        /// Actualiza un Fecha.
        /// </summary>
        /// <param name="pFecha">Fecha.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Fecha pFecha)
        {
            return _accesoBaseDeDatos.Actualizar(pFecha); 
        }

        /// <summary>
        /// Borra un Fecha.
        /// </summary>
        /// <param name="pFecha">Fecha.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Fecha pFecha)
        {
            return _accesoBaseDeDatos.Borrar(pFecha);
        }
        
        public BE.Fecha ObtenerFechaPorId(int idFecha)
        {
            var dtFecha = _accesoBaseDeDatos.Seleccionar(new BE.Fecha(){Id = idFecha}, true, false);
     
            if (dtFecha.Rows.Count == 0)
                return null;

            var row = dtFecha.Rows[0];
            var aFecha = new BE.Fecha
            {
                Id = Convert.ToInt32(row["Id"]),
                FechaDesde= Convert.ToDateTime(row["FechaDesde"].ToString().Trim()),
                FechaHasta= Convert.ToDateTime(row["FechaHasta"].ToString().Trim()),
                Nombre = row["Nombre"].ToString().Trim(),
                Fixture = new BE.Fixture() { Id = Convert.ToInt32(row["IdFixture"]) },
                Numero = Convert.ToInt32(row["Numero"]),
                Designado = Convert.ToBoolean(row["Designado"]),
                Partidos = new List<BE.Partido>()
     
            };

            return aFecha;

        }

        public List<BE.Fecha> ObtenerFechasPorIdFixture(int idFixture)
        {
            var ls = new List<BE.Fecha>();
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdFixture", idFixture);

            string query = @" Select *
                             from Fecha f
                             where f.IdFixture =  @IdFixture";

            var dt = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dt.Rows.Count == 0)
                return null;

            foreach (DataRow row in dt.Rows)
            {
                var aFecha = new BE.Fecha
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FechaDesde= Convert.ToDateTime(row["FechaDesde"].ToString().Trim()),
                    FechaHasta= Convert.ToDateTime(row["FechaHasta"].ToString().Trim()),
                    Nombre = row["Nombre"].ToString().Trim(),
                    Fixture = new BE.Fixture() { Id = Convert.ToInt32(row["IdFixture"]) },
                    Numero = Convert.ToInt32(row["Numero"]),
                    Designado = Convert.ToBoolean(row["Designado"]),
                    Partidos = new List<BE.Partido>()
                };

                ls.Add(aFecha);
            }

            return ls;
        }

        public List<BE.Fecha> Leer()
        {
            var ls = new List<BE.Fecha>();

            BE.Fecha beFecha = new BE.Fecha();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Fecha(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aFecha = new BE.Fecha
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FechaDesde= Convert.ToDateTime(row["FechaDesde"].ToString().Trim()),
                    FechaHasta= Convert.ToDateTime(row["FechaHasta"].ToString().Trim()),
                    Nombre = row["Nombre"].ToString().Trim(),
                    Fixture = new BE.Fixture() { Id = Convert.ToInt32(row["IdFixture"]) },
                    Numero = Convert.ToInt32(row["Numero"]),
                    Designado = Convert.ToBoolean(row["Designado"]),
                    Partidos = new List<BE.Partido>()
                };

                ls.Add(aFecha);
            }

            return ls;
        }

        public List<BE.Fecha> ObtenerFechasNoDesignadas(int idDeporte)
        {

            var ls = new List<BE.Fecha>();
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdDeporte", idDeporte);

            string query = @" select *
	                          from Fecha f
	                          where f.Id in (
						                        select min(fec.Id) as minimo
						                        from Fecha fec
												inner join Fixture fix ON ( fec.IdFixture = fix.Id )
												inner join Campeonato ca ON ( fix.Id = ca.IdFixture )
												inner join Categoria cat ON ( cat.Id = ca.IdCategoria )
						                        where fec.Designado = 0
												and cat.IdDeporte = @IdDeporte
						                        group by fec.IdFixture
												)";

            var dt = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dt.Rows.Count == 0)
                return null;

            foreach (DataRow row in dt.Rows)
            {
                var aFecha = new BE.Fecha
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FechaDesde= Convert.ToDateTime(row["FechaDesde"].ToString().Trim()),
                    FechaHasta= Convert.ToDateTime(row["FechaHasta"].ToString().Trim()),
                    Nombre = row["Nombre"].ToString().Trim(),
                    Fixture = new BE.Fixture() { Id = Convert.ToInt32(row["IdFixture"]) },
                    Numero = Convert.ToInt32(row["Numero"]),
                    Designado = Convert.ToBoolean(row["Designado"]),
                    Partidos = new List<BE.Partido>()
                };

                ls.Add(aFecha);
            }

            return ls;
        }
    }
}
