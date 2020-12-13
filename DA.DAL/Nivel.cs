using System;
using System.Collections.Generic;
using System.Data;
using DA.BE;
using DA.SS;

namespace DA.DAL
{
    public class Nivel
    {
                 /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Nivel.
        /// </summary>
        /// <param name="pNivel">Nivel.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Nivel pNivel)
        {

            return _accesoBaseDeDatos.Insertar(pNivel);
        }

 
        /// <summary>
        /// Actualiza un Nivel.
        /// </summary>
        /// <param name="pNivel">Nivel.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Nivel pNivel)
        {
            return _accesoBaseDeDatos.Actualizar(pNivel); 
        }

        /// <summary>
        /// Borra un Nivel.
        /// </summary>
        /// <param name="pNivel">Nivel.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Nivel pNivel)
        {
            return _accesoBaseDeDatos.Borrar(pNivel);
        }

       
        public BE.Nivel ObtenerNivelPorId(int idNivel)
        {
            var dtNivel = _accesoBaseDeDatos.Seleccionar(new BE.Nivel(){Id = idNivel}, true, true);
     
            if (dtNivel.Rows.Count == 0)
                return null;

            var row = dtNivel.Rows[0];
            var aNivel = new BE.Nivel
            {
                Id = Convert.ToInt32(row["Id"]),
                NombreNivel  = row["NombreNivel"].ToString().Trim(),
                Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
                ReglasDeNivel = new List<BE.NivelRegla>()
     
            };

            return aNivel;

        }

        public List<BE.Nivel> Leer()
        {
            var ls = new List<BE.Nivel>();

            BE.Nivel beNivel = new BE.Nivel();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Nivel(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aNivel = new BE.Nivel
                {
                    Id = Convert.ToInt32(row["Id"]),
                    NombreNivel = row["NombreNivel"].ToString().Trim(),
                    Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
                    ReglasDeNivel = new List<BE.NivelRegla>()
                };

                ls.Add(aNivel);
            }

            return ls;
        }

        public List<BE.Nivel> Leer(int idDeporte)
        {
            var ls = new List<BE.Nivel>();

            BE.Nivel beNivel = new BE.Nivel();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Nivel(), false);

            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["IdDeporte"]) == idDeporte)
                {
                    var aNivel = new BE.Nivel
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        NombreNivel = row["NombreNivel"].ToString().Trim(),
                        Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
                        ReglasDeNivel = new List<BE.NivelRegla>()
                    };
                    ls.Add(aNivel);
                }
            }

            return ls;
        }

        public bool AsignarNiveles(List<BE.Arbitro> arbitrosSinNivel)
        {
            ResultadoBd rdb = ResultadoBd.ERROR;
            Arbitro arbitroDal = new Arbitro();
            BE.Arbitro arbitroAnt;
            DAL.Bitacora bitacora = new Bitacora();
            foreach (BE.Arbitro arbitro in arbitrosSinNivel)
            {
                arbitroAnt = new BE.Arbitro() { 
                    AniosExperiencia = arbitro.AniosExperiencia,
                    Apellido = arbitro.Apellido,
                    Deporte = arbitro.Deporte,
                    DNI=arbitro.DNI,
                    Habilitado = arbitro.Habilitado,
                    ExamenFisicoAprobado = arbitro.ExamenFisicoAprobado,
                    ExamenTeoricoAprobado = arbitro.ExamenTeoricoAprobado,
                    FechaNacimiento= arbitro.FechaNacimiento,
                    Genero=arbitro.Genero,
                    Id=arbitro.Id,
                    PoseeLicenciaInternacional=arbitro.PoseeLicenciaInternacional,
                    Nivel = arbitro.Nivel,
                    Nombre = arbitro.Nombre,
                    NotaAFA = arbitro.NotaAFA,
                    Ranking = arbitro.Ranking,
                    PoseeTituloValidoArgentina = arbitro.PoseeTituloValidoArgentina,
                    UltimosEquiposDirigidos = arbitro.UltimosEquiposDirigidos,
                    UltimosPartidosDirigidos = arbitro.UltimosPartidosDirigidos
                };
                arbitro.Nivel = ObtenerNivel(arbitro);
                rdb = arbitroDal.Actualizar(arbitro, arbitroAnt, bitacora.obtenerMaxId());
            }
            return rdb == ResultadoBd.OK;
        }

        public BE.Nivel ObtenerNivel(BE.Arbitro arbitro)
        {
            if (arbitro.AniosExperiencia >= 6 &&
                arbitro.NotaAFA > 9 &&
                arbitro.PoseeLicenciaInternacional == true)
            {
                return new BE.Nivel() { Id = 1, NombreNivel = "Nivel 1", Deporte= new BE.Deporte() { Id = 1}  };
            }

            if (arbitro.AniosExperiencia >= 4 &&
                arbitro.NotaAFA >= 8 &&
                arbitro.PoseeLicenciaInternacional == true)
            {
                return new BE.Nivel() { Id = 2, NombreNivel = "Nivel 2", Deporte = new BE.Deporte() { Id = 1 } };
            }

            if (arbitro.AniosExperiencia >= 2 &&
                arbitro.NotaAFA >= 6)
            {
                return new BE.Nivel() { Id = 3, NombreNivel = "Nivel 3", Deporte = new BE.Deporte() { Id = 1 } };
            }

            if (arbitro.AniosExperiencia >= 1 &&
                arbitro.NotaAFA >= 5)
            {
                return new BE.Nivel() { Id = 4, NombreNivel = "Nivel 4", Deporte = new BE.Deporte() { Id = 1 } };
            }

            return new BE.Nivel() { Id = 5, NombreNivel = "Nivel 5", Deporte = new BE.Deporte() { Id = 1 } };
        }
    }
}
