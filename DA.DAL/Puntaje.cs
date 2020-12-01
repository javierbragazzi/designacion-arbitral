using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.SS;

namespace DA.DAL
{
    public class Puntaje
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        public List<BE.Puntaje> ObtenerPuntajeDeTemporada()
        {   
            List<BE.Puntaje> ls = new List<BE.Puntaje>();

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
                var aPuntaje = new BE.Puntaje()
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

        public ResultadoBd ActualizarNuevoNivel(BE.Puntaje pPuntaje)
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

        public ResultadoBd ActualizarBaja(BE.Puntaje pPuntaje)
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

        public ResultadoBd ActualizarProcesado(BE.Puntaje pPuntaje)
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
