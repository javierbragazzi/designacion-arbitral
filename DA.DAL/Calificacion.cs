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

 
        
    }
}
