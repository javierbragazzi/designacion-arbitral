using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class Partido
    {
         /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Partido.
        /// </summary>
        /// <param name="pPartido">Partido.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Partido pPartido)
        {

            return _accesoBaseDeDatos.Insertar(pPartido);
        }

 
        /// <summary>
        /// Actualiza un Partido.
        /// </summary>
        /// <param name="pPartido">Partido.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Partido pPartido)
        {
            return _accesoBaseDeDatos.Actualizar(pPartido); 
        }

        /// <summary>
        /// Borra un Partido.
        /// </summary>
        /// <param name="pPartido">Partido.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Partido pPartido)
        {
            return _accesoBaseDeDatos.Borrar(pPartido);
        }

       
        public BE.Partido ObtenerPartidoPorId(int idPartido)
        {
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPartido", idPartido);

            string query = @"    SELECT [Id]
                                ,[IdEquipo1]
                                ,[IdEquipo2]
                                ,[Prioridad]
                                ,[Fecha]
                                ,[IdFecha]
                             FROM [DesignacionArbitral].[dbo].[Partido] p
                             where p.Id = @IdPartido";
            


            var dtPartido = _accesoBaseDeDatos.Seleccionar(query, pars);
            
            if (dtPartido.Rows.Count == 0)
                return null;

            var row = dtPartido.Rows[0];
            var aPartido = new BE.Partido
            {
                Id = Convert.ToInt32(row["Id"]),
                FechaDelCampeonato = new BE.Fecha() { Id = Convert.ToInt32(row["IdFecha"]) },
                Fecha = Convert.ToDateTime(row["Fecha"].ToString().Trim()),
                Equipo1 = new BE.Equipo() { Id = Convert.ToInt32(row["IdEquipo1"]) },
                Equipo2 = new BE.Equipo() { Id = Convert.ToInt32(row["IdEquipo2"]) },
                Prioridad = Convert.ToInt32(row["Prioridad"]),
     
            };

            return aPartido;

        }

        public List<BE.Partido> ObtenerPartidosPorIdFecha(int idFecha)
        {
            var ls = new List<BE.Partido>();
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdFecha", idFecha);

            string query = @" Select *
                             from Partido p
                             where p.IdFecha = @IdFecha";

            var dt = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dt.Rows.Count == 0)
                return null;

            foreach (DataRow row in dt.Rows)
            {
                var aPartido = new BE.Partido
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FechaDelCampeonato = new BE.Fecha() { Id = Convert.ToInt32(row["IdFecha"]) },
                    Fecha = Convert.ToDateTime(row["Fecha"].ToString().Trim()),
                    Equipo1 = new BE.Equipo() { Id = Convert.ToInt32(row["IdEquipo1"]) },
                    Equipo2 = new BE.Equipo() { Id = Convert.ToInt32(row["IdEquipo2"]) },
                    Prioridad = Convert.ToInt32(row["Prioridad"]),
                };

                ls.Add(aPartido);
            }

            return ls;
        }

        public List<BE.Partido> Leer()
        {
            var ls = new List<BE.Partido>();

            BE.Partido bePartido = new BE.Partido();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Partido(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aPartido = new BE.Partido
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FechaDelCampeonato = new BE.Fecha() { Id = Convert.ToInt32(row["IdFecha"]) },
                    Fecha = Convert.ToDateTime(row["Fecha"].ToString().Trim()),
                    Equipo1 = new BE.Equipo() { Id = Convert.ToInt32(row["IdEquipo1"]) },
                    Equipo2 = new BE.Equipo() { Id = Convert.ToInt32(row["IdEquipo2"]) },
                    Prioridad = Convert.ToInt32(row["Prioridad"]),
                };

                ls.Add(aPartido);
            }

            return ls;
        }

        public List<SS.PartidoHelperUI> ObtenerPartidosConCalificacion() 
        {
            var ls = new List<PartidoHelperUI>();

            string query = @"     SELECT DISTINCT par.* , pa.IdCalificacion, ta.Id as 'IdTipoArbitro', ta.Descripcion, cal.ReglasPuntaje, cal.DisciplinaPuntaje, cal.CondicionFisicaPuntaje, cal.JugadasPuntaje ,cal.DificultadPartidoPuntaje
                                  FROM PartidoArbitro pa,
	                                   Partido par,
									   Calificacion cal,
									   TipoArbitro ta
                                  WHERE pa.IdPartido = par.Id
								  AND cal.Id= pa.IdCalificacion
								  AND pa.IdTipoArbitro = ta.Id
                                  AND pa.IdCalificacion IS NOT NULL";

            var dt = _accesoBaseDeDatos.Seleccionar(query);

            if (dt.Rows.Count == 0)
                return null;

            int idPartidoAnt = -1;
            PartidoHelperUI aPartido = new PartidoHelperUI();

            foreach (DataRow row in dt.Rows)
            {
                if (idPartidoAnt != Convert.ToInt32(row["Id"]))
                {
                    aPartido = new PartidoHelperUI
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        FechaDelCampeonato = new BE.Fecha() {Id = Convert.ToInt32(row["IdFecha"])},
                        Fecha = Convert.ToDateTime(row["Fecha"].ToString().Trim()),
                        Equipo1 = new BE.Equipo() {Id = Convert.ToInt32(row["IdEquipo1"])},
                        Equipo2 = new BE.Equipo() {Id = Convert.ToInt32(row["IdEquipo2"])},
                        Prioridad = Convert.ToInt32(row["Prioridad"]),
                    };

                    BE.Calificacion calificacion = new BE.Calificacion()
                    {
                        Id = Convert.ToInt32(row["IdCalificacion"]),
                        ReglasPuntaje = Convert.ToInt32(row["ReglasPuntaje"]),
                        DisciplinaPuntaje = Convert.ToInt32(row["DisciplinaPuntaje"]),
                        JugadasPuntaje = Convert.ToInt32(row["JugadasPuntaje"]),
                        CondicionFisicaPuntaje = Convert.ToInt32(row["CondicionFisicaPuntaje"]),
                        DificultadPartidoPuntaje = Convert.ToDouble(row["DificultadPartidoPuntaje"]),
                        
                    };

                    idPartidoAnt = aPartido.Id;

                    aPartido.CalificacionesArbitros.Add(new BE.TipoArbitro(){Id = Convert.ToInt32(row["IdTipoArbitro"]), Descripcion = row["Descripcion"].ToString().Trim(),} , calificacion);

                    
                }
                else
                {
                    BE.Calificacion calificacion = new BE.Calificacion()
                    {
                        Id = Convert.ToInt32(row["IdCalificacion"]),
                        ReglasPuntaje = Convert.ToInt32(row["ReglasPuntaje"]),
                        DisciplinaPuntaje = Convert.ToInt32(row["DisciplinaPuntaje"]),
                        JugadasPuntaje = Convert.ToInt32(row["JugadasPuntaje"]),
                        CondicionFisicaPuntaje = Convert.ToInt32(row["CondicionFisicaPuntaje"]),
                        DificultadPartidoPuntaje = Convert.ToDouble(row["DificultadPartidoPuntaje"]),
                        
                    };
                    aPartido.CalificacionesArbitros.Add(new BE.TipoArbitro(){Id = Convert.ToInt32(row["IdTipoArbitro"]), Descripcion = row["Descripcion"].ToString().Trim(),} , calificacion);
                    ls.Add(aPartido);
                }

                
            }

            return ls;

        }

        public List<PartidoHelperUI> ObtenerPartidosSinCalificacion() 
        {
            var ls = new List<PartidoHelperUI>();

            string query = @" SELECT DISTINCT TOP (10)  par.*
                              FROM PartidoArbitro pa,
	                               Partido par
                              WHERE pa.IdPartido = par.Id
                              AND pa.IdCalificacion IS NULL
                              and par.Fecha < SYSDATETIME()";

            var dt = _accesoBaseDeDatos.Seleccionar(query);

            if (dt.Rows.Count == 0)
                return null;

            int idPartidoAnt = -1;

            foreach (DataRow row in dt.Rows)
            {
                if (idPartidoAnt != Convert.ToInt32(row["Id"]))
                {
                    var aPartido = new PartidoHelperUI
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        FechaDelCampeonato = new BE.Fecha() {Id = Convert.ToInt32(row["IdFecha"])},
                        Fecha = Convert.ToDateTime(row["Fecha"].ToString().Trim()),
                        Equipo1 = new BE.Equipo() {Id = Convert.ToInt32(row["IdEquipo1"])},
                        Equipo2 = new BE.Equipo() {Id = Convert.ToInt32(row["IdEquipo2"])},
                        Prioridad = Convert.ToInt32(row["Prioridad"]),
                    };

                    ls.Add(aPartido);
                }

            }
            
            return ls;

        }

        public List<BE.Partido> ObtenerPartidosDirigidosUltimos15Dias(int idArbitro) 
        {
            var ls = new List<BE.Partido>();
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdArbitro", idArbitro);

            string query = @"SELECT p.*
                              FROM PartidoArbitro pa
                              INNER JOIN Partido p ON  ( pa.IdPartido = p.Id ) 
                              where pa.IdArbitro = @IdArbitro
                              AND 15 > DATEDIFF(DAY, p.Fecha ,getdate())
                              order by p.Fecha DESC";

            var dt = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dt.Rows.Count == 0)
                return null;

            foreach (DataRow row in dt.Rows)
            {
                var aPartido = new BE.Partido
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FechaDelCampeonato = new BE.Fecha() { Id = Convert.ToInt32(row["IdFecha"]) },
                    Fecha = Convert.ToDateTime(row["Fecha"].ToString().Trim()),
                    Equipo1 = new BE.Equipo() { Id = Convert.ToInt32(row["IdEquipo1"]) },
                    Equipo2 = new BE.Equipo() { Id = Convert.ToInt32(row["IdEquipo2"]) },
                    Prioridad = Convert.ToInt32(row["Prioridad"]),
                };

                ls.Add(aPartido);
            }

            return ls;

        }
    }
}
