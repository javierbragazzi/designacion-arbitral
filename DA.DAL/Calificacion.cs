using System;
using System.Collections.Generic;
using System.Data;
using DA.BE;
using DA.SS;

namespace DA.DAL
{
    public class Calificacion
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Calificacion.
        /// </summary>
        /// <param name="pCalificacion">Calificacion.</param>
        /// <param name="pPartido"></param>
        /// <param name="idArbitro"></param>
        /// <param name="idTipoArbitro"></param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Calificacion pCalificacion, BE.Partido pPartido, int idArbitro, int idTipoArbitro)
        {
            
            var pars = new IDbDataParameter[8];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@ReglasPuntaje", pCalificacion.ReglasPuntaje);
            pars[1] = _accesoBaseDeDatos.CrearParametro("@DisciplinaPuntaje", pCalificacion.DisciplinaPuntaje);
            pars[2] = _accesoBaseDeDatos.CrearParametro("@CondicionFisicaPuntaje", pCalificacion.CondicionFisicaPuntaje);
            pars[3] = _accesoBaseDeDatos.CrearParametro("@JugadasPuntaje", pCalificacion.JugadasPuntaje);
            pars[4] = _accesoBaseDeDatos.CrearParametro("@DificultadPartidoPuntaje", pCalificacion.DificultadPartidoPuntaje);
            pars[5] = _accesoBaseDeDatos.CrearParametro("@IdPartido", pPartido.Id);
            pars[6] = _accesoBaseDeDatos.CrearParametro("@IdArbitro", idArbitro);
            pars[7] = _accesoBaseDeDatos.CrearParametro("@IdTipoArbitro", idTipoArbitro);
            
    
            string query = @"   INSERT INTO Calificacion (ReglasPuntaje, DisciplinaPuntaje, CondicionFisicaPuntaje, JugadasPuntaje, DificultadPartidoPuntaje)
                                VALUES (@ReglasPuntaje,@DisciplinaPuntaje,@CondicionFisicaPuntaje,@JugadasPuntaje,@DificultadPartidoPuntaje);
                                
                                UPDATE PartidoArbitro 
                                SET IdCalificacion = (SELECT max(Id) FROM Calificacion)
                                WHERE IdPartido = @IdPartido
                                AND IdArbitro = @IdArbitro
                                AND IdTipoArbitro = @IdTipoArbitro ; ";

            ResultadoBd resultadoBd = _accesoBaseDeDatos.Ejecutar(query, pars);

            if (resultadoBd == ResultadoBd.OK)
            {
                return ResultadoBd.OK;
            }
            else
            {
                return ResultadoBd.ERROR;
            }


        }

 
        /// <summary>
        /// Actualiza un Calificacion.
        /// </summary>
        /// <param name="pCalificacion">Calificacion.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Calificacion pCalificacion)
        {
            return _accesoBaseDeDatos.Actualizar(pCalificacion); 
        }

        /// <summary>
        /// Borra un Calificacion.
        /// </summary>
        /// <param name="pCalificacion">Calificacion.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Calificacion pCalificacion)
        {
            return _accesoBaseDeDatos.Borrar(pCalificacion);
        }
        
        public BE.Calificacion ObtenerCalificacionPorId(int idCalificacion)
        {
            var dtCalificacion = _accesoBaseDeDatos.Seleccionar(new BE.Calificacion(){Id = idCalificacion}, true, false);
     
            if (dtCalificacion.Rows.Count == 0)
                return null;

            var row = dtCalificacion.Rows[0];
            var aCalificacion = new BE.Calificacion
            {
                Id = Convert.ToInt32(row["Id"]),
                ReglasPuntaje = Convert.ToInt32(row["ReglasPuntaje"]),
                DisciplinaPuntaje  = Convert.ToInt32(row["DisciplinaPuntaje"]),
                JugadasPuntaje = Convert.ToInt32(row["JugadasPuntaje"]),
                CondicionFisicaPuntaje = Convert.ToInt32(row["CondicionFisicaPuntaje"]),
                DificultadPartidoPuntaje = Convert.ToInt32(row["DificultadPartidoPuntaje"]),
              
            };

            return aCalificacion;

        }

        public List<PuntajeArbitro> ObtenerPuntajeDeTemporada()
        {   
            List<PuntajeArbitro> ls = new List<PuntajeArbitro>();

            string query = @"     Select pa.IdArbitro, 
		                                ar.Nombre, 
		                                ar.Apellido, 
		                                (cast(datediff(dd,ar.FechaNacimiento,GETDATE()) / 365.25 as int)) as 'Edad', 
		                                niv.Id as 'IdNivel',
		                                niv.NombreNivel, 
		                                COUNT(IdArbitro) as 'CantidadPartidos', 
		                                ((AVG(cal.CondicionFisicaPuntaje) + AVG(cal.ReglasPuntaje) + AVG(cal.DisciplinaPuntaje) + AVG(cal.JugadasPuntaje) )/4)+ AVG(cal.DificultadPartidoPuntaje) as 'PuntajePromedio'
                                      from PartidoArbitro pa,
	                                       Arbitro ar,
	                                       Nivel niv,
	                                       Calificacion cal
                                      where pa.IdArbitro = ar.Id
                                      and   ar.IdNivel = niv.Id
                                      and   pa.IdCalificacion = cal.Id 
                                      and   pa.Procesado = 0
                                      group by IdArbitro, ar.Nombre, ar.Apellido, (cast(datediff(dd,ar.FechaNacimiento,GETDATE()) / 365.25 as int)), niv.Id, niv.NombreNivel ";

            var dt = _accesoBaseDeDatos.Seleccionar(query);
            
            foreach (DataRow row in dt.Rows)
            {
                var aPuntaje = new PuntajeArbitro()
                {
                    IdArbitro = Convert.ToInt32(row["IdArbitro"]),
                    Nombre = row["Nombre"].ToString().Trim(),
                    Apellido = row["Apellido"].ToString().Trim(),
                    Edad = Convert.ToInt32(row["Edad"]),
                    IdNivel = Convert.ToInt32(row["IdNivel"]),
                    CantidadPartidos = Convert.ToInt32(row["CantidadPartidos"]),
                    PuntajePromedio = Convert.ToDouble(row["PuntajePromedio"]),
                    NombreNivel = row["NombreNivel"].ToString().Trim(),
        
                };

                ls.Add(aPuntaje);
            }

            return ls;

        }

        public ResultadoBd ActualizarNuevoNivel(PuntajeArbitro pPuntaje)
        {
            var pars = new IDbDataParameter[2];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdArbitro", pPuntaje.IdArbitro);
            pars[1] = _accesoBaseDeDatos.CrearParametro("@IdNivel", pPuntaje.IdNivelNuevo);
    
            string query = @" Update PartidoArbitro
                              Set Procesado = 1
                              Where IdArbitro = @IdArbitro;

                              Update Arbitro
                              Set IdNivel = @IdNivel
                              Where Id = @IdArbitro ; ";

            ResultadoBd resultadoBd = _accesoBaseDeDatos.Ejecutar(query, pars);

            if (resultadoBd == ResultadoBd.OK)
            {
                return ResultadoBd.OK;
            }
            else
            {
                return ResultadoBd.ERROR;
            }

        }

        public ResultadoBd ActualizarBaja(PuntajeArbitro pPuntaje)
        {
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdArbitro", pPuntaje.IdArbitro);
    
            string query = @" Update PartidoArbitro
                              Set Procesado = 1
                              Where IdArbitro = @IdArbitro;

                              Update Arbitro
                              Set Estado = 0
                              Where Id = @IdArbitro ; ";

            ResultadoBd resultadoBd = _accesoBaseDeDatos.Ejecutar(query, pars);

            if (resultadoBd == ResultadoBd.OK)
            {
                return ResultadoBd.OK;
            }
            else
            {
                return ResultadoBd.ERROR;
            }

        }

        public ResultadoBd ActualizarProcesado(PuntajeArbitro pPuntaje)
        {
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdArbitro", pPuntaje.IdArbitro);
    
            string query = @" Update PartidoArbitro
                              Set Procesado = 1
                              Where IdArbitro = @IdArbitro;";

            ResultadoBd resultadoBd = _accesoBaseDeDatos.Ejecutar(query, pars);

            if (resultadoBd == ResultadoBd.OK)
            {
                return ResultadoBd.OK;
            }
            else
            {
                return ResultadoBd.ERROR;
            }

        }

        
    }
}
