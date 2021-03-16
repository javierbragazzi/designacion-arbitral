using System;
using System.Collections.Generic;
using System.Data;
using DA.BE;
using DA.SS;

namespace DA.DAL
{
    public class Arbitro
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();



        private ResultadoBd InsertarAuditoria(BE.Arbitro pArbitro, int idBitacora)
        {
            ArbitroAud arbitroAud = new ArbitroAud()
            {
                //IdArbitro = pArbitro.Id,
                Nombre = pArbitro.Nombre,
                Apellido = pArbitro.Apellido,
                Habilitado = pArbitro.Habilitado,
                FechaNacimiento = pArbitro.FechaNacimiento,
                Genero = pArbitro.Genero,
                DNI = pArbitro.DNI,
                Deporte = pArbitro.Deporte,
                Nivel = pArbitro.Nivel,
                Ranking = pArbitro.Ranking,
                AniosExperiencia = pArbitro.AniosExperiencia,
                NotaAFA = pArbitro.NotaAFA,
                //IdBitacora = idBitacora,
                Bitacora = new BE.Bitacora(){Id = idBitacora},
                PoseeTituloValidoArgentina = pArbitro.PoseeTituloValidoArgentina,
                PoseeLicenciaInternacional = pArbitro.PoseeLicenciaInternacional,
                ExamenFisicoAprobado = pArbitro.ExamenFisicoAprobado,
                ExamenTeoricoAprobado = pArbitro.ExamenTeoricoAprobado
            };
            string query = string.Empty;

            if (arbitroAud.Nivel != null)
            {
                query = string.Format(@"INSERT INTO ARBITROAUD([Nombre],[Apellido],[FechaNacimiento],[IdGenero],[Dni],[Ranking],[AniosExperiencia],[NotaAFA],[IdNivel],[IdDeporte],[Habilitado],[IdArbitro],[IdBitacora],
                            [PoseeTituloValidoArgentina],[PoseeLicenciaInternacional],[ExamenFisicoAprobado],[ExamenTeoricoAprobado]) 
                            VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}', '{16}')",
                            arbitroAud.Nombre,
                            arbitroAud.Apellido,
                            arbitroAud.FechaNacimiento.ToString("yyyy-MM-dd"),
                            arbitroAud.Genero.Id,
                            arbitroAud.DNI,
                            arbitroAud.Ranking,
                            arbitroAud.AniosExperiencia,
                            arbitroAud.NotaAFA,
                            arbitroAud.Nivel.Id,
                            arbitroAud.Deporte.Id,
                            arbitroAud.Habilitado == true ? 1 : 0,
                            arbitroAud.Id,
                            //arbitroAud.IdBitacora,
                            arbitroAud.Bitacora.Id,
                            arbitroAud.PoseeTituloValidoArgentina == true ? 1 : 0,
                            arbitroAud.PoseeLicenciaInternacional == true ? 1 : 0,
                            arbitroAud.ExamenFisicoAprobado == true ? 1 : 0,
                            arbitroAud.ExamenTeoricoAprobado == true ? 1 : 0
                            );
            }
            else
            {
                query = string.Format(@"INSERT INTO ARBITROAUD([Nombre],[Apellido],[FechaNacimiento],[IdGenero],[Dni],[Ranking],[AniosExperiencia],[NotaAFA],[IdDeporte],[Habilitado],[IdArbitro],[IdBitacora],
                           [PoseeTituloValidoArgentina],[PoseeLicenciaInternacional],[ExamenFisicoAprobado],[ExamenTeoricoAprobado]) 
                            VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')",
                            arbitroAud.Nombre,
                            arbitroAud.Apellido,
                            arbitroAud.FechaNacimiento.ToString("yyyy-MM-dd"),
                            arbitroAud.Genero.Id,
                            arbitroAud.DNI,
                            arbitroAud.Ranking,
                            arbitroAud.AniosExperiencia,
                            arbitroAud.NotaAFA,
                            arbitroAud.Deporte.Id,
                            arbitroAud.Habilitado == true ? 1 : 0,
                            arbitroAud.Id,
                            //arbitroAud.IdBitacora,
                            arbitroAud.Bitacora.Id,
                            arbitroAud.PoseeTituloValidoArgentina == true ? 1 : 0,
                            arbitroAud.PoseeLicenciaInternacional == true ? 1 : 0,
                            arbitroAud.ExamenFisicoAprobado == true ? 1 : 0,
                            arbitroAud.ExamenTeoricoAprobado == true ? 1 : 0
                            );
            }
            

            return _accesoBaseDeDatos.Ejecutar(query.Trim(), null);
        }

        /// <summary>
        /// Inserta un Arbitro.
        /// </summary>
        /// <param name="pArbitro">Arbitro.</param>
        /// <param name="pArbitroAnt"></param>
        /// <param name="idBitacora"></param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Arbitro pArbitro, BE.Arbitro pArbitroAnt, int idBitacora)
        {
            ResultadoBd resultado = _accesoBaseDeDatos.Insertar(pArbitro);

            if (pArbitroAnt != null)
            {
                if (resultado == ResultadoBd.OK)
                {
                    resultado = InsertarAuditoria(pArbitroAnt, idBitacora);
                }
            }

            return resultado;
        }


        public ResultadoBd Actualizar(BE.Arbitro pArbitro, BE.Arbitro pArbitroAnt, int idBitacora)
        {
            ResultadoBd resultado = _accesoBaseDeDatos.Actualizar(pArbitro);

            if (resultado == ResultadoBd.OK)
            {
                resultado = InsertarAuditoria(pArbitroAnt, idBitacora);
            }
            return resultado;
        }

        public ResultadoBd Borrar(BE.Arbitro pArbitro, BE.Arbitro pArbitroAnt, int idBitacora)
        {
            ResultadoBd resultado = _accesoBaseDeDatos.Borrar(pArbitro);

            if (resultado == ResultadoBd.OK)
            {
                resultado = InsertarAuditoria(pArbitroAnt, idBitacora);
            }
            return resultado;
        }

       
        public BE.Arbitro ObtenerArbitroPorId(int idArbitro)
        {
            var dtArbitro = _accesoBaseDeDatos.Seleccionar(string.Format("SELECT * FROM ARBITRO WHERE ID = {0}",idArbitro), null);
     
            if (dtArbitro.Rows.Count == 0)
                return null;

            var row = dtArbitro.Rows[0];
            var aArbitro = new BE.Arbitro
            {
                Id = Convert.ToInt32(row["Id"]),
                Nombre  = row["Nombre"].ToString().Trim(),
                Apellido = row["Apellido"].ToString().Trim(),
                Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
                Habilitado = Convert.ToBoolean(row["Habilitado"].ToString().Trim()),
                FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"].ToString().Trim()),
                Genero = new BE.Genero() { Id = Convert.ToInt32(row["IdGenero"]) },
                DNI = row["Dni"].ToString().Trim(),
                Ranking = int.Parse(row["Ranking"].ToString()),
                AniosExperiencia = int.Parse(row["AniosExperiencia"].ToString()),
                NotaAFA = float.Parse(row["NotaAFA"].ToString()),
                PoseeTituloValidoArgentina = row["PoseeTituloValidoArgentina"].ToString() == "1" ? true : false,
                PoseeLicenciaInternacional = row["PoseeLicenciaInternacional"].ToString() == "1" ? true : false,
                ExamenFisicoAprobado = row["ExamenFisicoAprobado"].ToString() == "1" ? true : false,
                ExamenTeoricoAprobado = row["ExamenTeoricoAprobado"].ToString() == "1" ? true : false,
                //UltimosEquiposDirigidos = new Queue<BE.Equipo>(),
                //UltimosPartidosDirigidos = new Queue<BE.Partido>()
     
            };
            if (string.IsNullOrEmpty(row["IdNivel"].ToString()))
            {
                aArbitro.Nivel = null;
            }
            else
            {
                aArbitro.Nivel = new BE.Nivel() { Id = Convert.ToInt32(row["IdNivel"]) };
            }

            return aArbitro;

        }

        public List<BE.Arbitro> Leer()
        {
            var ls = new List<BE.Arbitro>();

            BE.Arbitro beArbitro = new BE.Arbitro();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Arbitro(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aArbitro = new BE.Arbitro
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre  = row["Nombre"].ToString().Trim(),
                    Apellido = row["Apellido"].ToString().Trim(),
                    Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
                    Habilitado = row["Habilitado"].ToString() == "True" ? true : false,
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"].ToString().Trim()),
                    Genero = new BE.Genero() { Id = Convert.ToInt32(row["IdGenero"]) },
                    DNI = row["Dni"].ToString().Trim(),
                    Ranking = int.Parse(row["Ranking"].ToString()),
                    AniosExperiencia = int.Parse(row["AniosExperiencia"].ToString()),
                    NotaAFA = float.Parse(row["NotaAFA"].ToString()),
                    PoseeTituloValidoArgentina = row["PoseeTituloValidoArgentina"].ToString() == "True" ? true : false,
                    PoseeLicenciaInternacional = row["PoseeLicenciaInternacional"].ToString() == "True" ? true : false,
                    ExamenFisicoAprobado = row["ExamenFisicoAprobado"].ToString() == "True" ? true : false,
                    ExamenTeoricoAprobado = row["ExamenTeoricoAprobado"].ToString() == "True" ? true : false,
                    //UltimosEquiposDirigidos = new Queue<BE.Equipo>(),
                    //UltimosPartidosDirigidos = new Queue<BE.Partido>()
                };

                if (string.IsNullOrEmpty(row["IdNivel"].ToString()))
                {
                    aArbitro.Nivel = null;
                }
                else
                {
                    aArbitro.Nivel = new BE.Nivel() { Id = Convert.ToInt32(row["IdNivel"]) };
                }

                ls.Add(aArbitro);
            }

            return ls;
        }

        public List<BE.Arbitro> ObtenerArbitrosPorPartidoId(int idPartido)
        {
            var ls = new List<BE.Arbitro>();
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPartido", idPartido);

            string query = @"  SELECT a.*
                                FROM PartidoArbitro pa
                                INNER JOIN Arbitro a ON  ( pa.IdArbitro = a.Id ) 
                                where pa.IdPartido =  @IdPartido";

            var dt = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dt.Rows.Count == 0)
                return null;

            foreach (DataRow row in dt.Rows)
            {
                var aArbitro = new BE.Arbitro
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre  = row["Nombre"].ToString().Trim(),
                    Apellido = row["Apellido"].ToString().Trim(),
                    Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
                    Habilitado = Convert.ToBoolean(row["Habilitado"].ToString().Trim()),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"].ToString().Trim()),
                    Genero = new BE.Genero() { Id = Convert.ToInt32(row["IdGenero"]) },
                    DNI = row["Dni"].ToString().Trim(),
                    Ranking = int.Parse(row["Ranking"].ToString()),
                    AniosExperiencia = int.Parse(row["AniosExperiencia"].ToString()),
                    NotaAFA = int.Parse(row["NotaAFA"].ToString()),
                    PoseeTituloValidoArgentina = row["PoseeTituloValidoArgentina"].ToString() == "1" ? true : false,
                    PoseeLicenciaInternacional = row["PoseeLicenciaInternacional"].ToString() == "1" ? true : false,
                    ExamenFisicoAprobado = row["ExamenFisicoAprobado"].ToString() == "1" ? true : false,
                    ExamenTeoricoAprobado = row["ExamenTeoricoAprobado"].ToString() == "1" ? true : false,
                    //UltimosEquiposDirigidos = new Queue<BE.Equipo>(),
                    //UltimosPartidosDirigidos = new Queue<BE.Partido>()
                };
                if (string.IsNullOrEmpty(row["IdNivel"].ToString()))
                {
                    aArbitro.Nivel = null;
                }
                else
                {
                    aArbitro.Nivel = new BE.Nivel() { Id = Convert.ToInt32(row["IdNivel"]) };
                }

                ls.Add(aArbitro);
            }

            return ls;
          
        }

         public List<BE.Arbitro> ObtenerArbitrosConNivel()
        {
            var ls = new List<BE.Arbitro>();
            //var pars = new IDbDataParameter[1];
            //pars[0] = _accesoBaseDeDatos.CrearParametro("@IdPartido", idPartido);

            string query = @"  SELECT a.*
                                FROM Arbitro a 
                                where a.IdNivel != 0";

            var dt = _accesoBaseDeDatos.Seleccionar(query, null);

            if (dt.Rows.Count == 0)
                return null;

            foreach (DataRow row in dt.Rows)
            {
                var aArbitro = new BE.Arbitro
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre  = row["Nombre"].ToString().Trim(),
                    Apellido = row["Apellido"].ToString().Trim(),
                    Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
                    Habilitado = Convert.ToBoolean(row["Habilitado"].ToString().Trim()),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"].ToString().Trim()),
                    Genero = new BE.Genero() { Id = Convert.ToInt32(row["IdGenero"]) },
                    DNI = row["Dni"].ToString().Trim(),
                    Ranking = Convert.ToInt32(row["Id"]),
                    NotaAFA = float.Parse(row["NotaAFA"].ToString()),
                    PoseeTituloValidoArgentina = row["PoseeTituloValidoArgentina"].ToString() == "1" ? true : false,
                    PoseeLicenciaInternacional = row["PoseeLicenciaInternacional"].ToString() == "1" ? true : false,
                    ExamenFisicoAprobado = row["ExamenFisicoAprobado"].ToString() == "1" ? true : false,
                    ExamenTeoricoAprobado = row["ExamenTeoricoAprobado"].ToString() == "1" ? true : false,
                    Nivel = new BE.Nivel() { Id = Convert.ToInt32(row["IdNivel"]) },
                    //UltimosEquiposDirigidos = new Queue<BE.Equipo>(),
                    //UltimosPartidosDirigidos = new Queue<BE.Partido>()
                };

                ls.Add(aArbitro);
            }

            return ls;
          
        }

    }
}
