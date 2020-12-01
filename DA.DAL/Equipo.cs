using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class Equipo
    {
                         /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Equipo.
        /// </summary>
        /// <param name="pEquipo">Equipo.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Equipo pEquipo)
        {

            return _accesoBaseDeDatos.Insertar(pEquipo);
        }

 
        /// <summary>
        /// Actualiza un Equipo.
        /// </summary>
        /// <param name="pEquipo">Equipo.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Equipo pEquipo)
        {
            return _accesoBaseDeDatos.Actualizar(pEquipo); 
        }

        /// <summary>
        /// Borra un Equipo.
        /// </summary>
        /// <param name="pEquipo">Equipo.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Equipo pEquipo)
        {
            return _accesoBaseDeDatos.Borrar(pEquipo);
        }

       
        public BE.Equipo ObtenerEquipoPorId(int idEquipo)
        {
            IDbDataParameter[] pars = null;
            var dtEquipo = _accesoBaseDeDatos.Seleccionar(new BE.Equipo(){Id = idEquipo});
     
            if (dtEquipo.Rows.Count == 0)
                return null;

            var row = dtEquipo.Rows[0];
            var aEquipo = new BE.Equipo
            {
                Id = Convert.ToInt32(row["Id"]),
                Nombre  = row["Nombre"].ToString().Trim(),
                Categoria = new BE.Categoria() { Id = Convert.ToInt32(row["IdCategoria"]) },
                Ponderacion = Convert.ToInt32(row["Ponderacion"])
     
            };

            return aEquipo;

        }

        public List<BE.Equipo> Leer()
        {
            var ls = new List<BE.Equipo>();

            BE.Equipo beEquipo = new BE.Equipo();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Equipo(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aEquipo = new BE.Equipo
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre  = row["Nombre"].ToString().Trim(),
                    Categoria = new BE.Categoria() { Id = Convert.ToInt32(row["IdCategoria"]) },
                    Ponderacion = Convert.ToInt32(row["Ponderacion"])
                };

                ls.Add(aEquipo);
            }

            return ls;
        }

        public List<BE.Equipo> ObtenerUltimosEquiposDirigidos(int idArbitro) 
        {
            var ls = new List<BE.Equipo>();
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdArbitro", idArbitro);

            string query = @" SELECT *
                              FROM Equipo eq
                              WHERE eq.Id IN(
				                              SELECT eq1.IdEquipo1 as IdEquipo
				                              FROM
					                             (SELECT TOP 2 P.IdEquipo1
					                             FROM PartidoArbitro pa
					                             INNER JOIN Partido p ON  ( pa.IdPartido = p.Id )
					                             where pa.IdArbitro = @IdArbitro
					                             order by p.Fecha DESC
					                             ) eq1
					                            UNION ALL
					                            SELECT eq2.IdEquipo2 as IdEquipo
				                              FROM
					                             (
					                            SELECT TOP 2  P.IdEquipo2
					                            FROM PartidoArbitro pa
					                            INNER JOIN Partido p ON  ( pa.IdPartido = p.Id )
					                            where pa.IdArbitro = @IdArbitro
					                            order by p.Fecha DESC
					                            )eq2
				                            )";

            var dt = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dt.Rows.Count == 0)
                return null;

            foreach (DataRow row in dt.Rows)
            {
                var aEquipo = new BE.Equipo()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre  = row["Nombre"].ToString().Trim(),
                    Categoria = new BE.Categoria() { Id = Convert.ToInt32(row["IdCategoria"]) },
                    Ponderacion = Convert.ToInt32(row["Ponderacion"])
                };

                ls.Add(aEquipo);
            }

            return ls;
        }


    }
}
