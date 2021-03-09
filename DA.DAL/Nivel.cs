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

        public List<BE.Arbitro> AsignarNiveles(List<BE.Arbitro> arbitrosSinNivel)
        {
            try
            {
                ResultadoBd rdb = ResultadoBd.ERROR;
                Arbitro arbitroDal = new Arbitro();
                BE.Arbitro arbitroAnt;
                DAL.Bitacora bitacora = new Bitacora();
                List<BE.Arbitro> lstActualizada = new List<BE.Arbitro>();

                foreach (BE.Arbitro arbitro in arbitrosSinNivel)
                {
                    arbitroAnt = new BE.Arbitro()
                    {
                        AniosExperiencia = arbitro.AniosExperiencia,
                        Apellido = arbitro.Apellido,
                        Deporte = arbitro.Deporte,
                        DNI = arbitro.DNI,
                        Habilitado = arbitro.Habilitado,
                        ExamenFisicoAprobado = arbitro.ExamenFisicoAprobado,
                        ExamenTeoricoAprobado = arbitro.ExamenTeoricoAprobado,
                        FechaNacimiento = arbitro.FechaNacimiento,
                        Genero = arbitro.Genero,
                        Id = arbitro.Id,
                        PoseeLicenciaInternacional = arbitro.PoseeLicenciaInternacional,
                        Nivel = arbitro.Nivel ?? new BE.Nivel() { Id = 0 },
                        Nombre = arbitro.Nombre,
                        NotaAFA = arbitro.NotaAFA,
                        Ranking = arbitro.Ranking,
                        PoseeTituloValidoArgentina = arbitro.PoseeTituloValidoArgentina,
                        //UltimosEquiposDirigidos = arbitro.UltimosEquiposDirigidos,
                        //UltimosPartidosDirigidos = arbitro.UltimosPartidosDirigidos
                    };
                    arbitro.Nivel = ObtenerNivel(arbitro);
                    lstActualizada.Add(arbitro);
                    rdb = arbitroDal.Actualizar(arbitro, arbitroAnt, bitacora.ObtenerMaxId());
                }

                return lstActualizada;
            }
            catch (Exception e)
            {
                Logger.Log.Error("Error en AsignarNiveles. Error: " + e.Message);
                return null;
            }
  
        }

        public BE.Nivel ObtenerNivel(BE.Arbitro arbitro)
        {
            Logger.Log.Info("*********** Definición de nivel de árbitro: " + arbitro.NombreCompleto + " ***********");

            if (arbitro.AniosExperiencia >= 6 &&
                arbitro.NotaAFA >= 9 &&
                arbitro.PoseeLicenciaInternacional == true)
            {
                Logger.Log.Info("Nivel 1. Condiciones: 6 años o más de experiencia, 9 o más en la nota del examen de AFA y posee licencia internacional FIFA");
                Logger.Log.Info("Caracteristicas del árbitro:");
                Logger.Log.Info("Años de experiencia: " + arbitro.AniosExperiencia);
                Logger.Log.Info("Nota del examen de AFA: " + arbitro.NotaAFA);
                Logger.Log.Info("¿Posee licencia internacional FIFA?: " + "Si");
                Logger.Log.Info("********************************************************");

                return new BE.Nivel() { Id = 1, NombreNivel = "Nivel 1", Deporte= new BE.Deporte() { Id = 1}  };
            }

            if (arbitro.AniosExperiencia >= 4 &&
                arbitro.NotaAFA >= 8 &&
                arbitro.PoseeLicenciaInternacional == true)
            {
                Logger.Log.Info("Nivel 2. Condiciones: 4 años o más de experiencia, 8 o más en la nota del examen de AFA y posee licencia internacional FIFA");
                Logger.Log.Info("Caracteristicas del árbitro:");
                Logger.Log.Info("Años de experiencia: " + arbitro.AniosExperiencia);
                Logger.Log.Info("Nota del examen de AFA: " + arbitro.NotaAFA);
                Logger.Log.Info("¿Posee licencia internacional FIFA?: " + "Si");
                Logger.Log.Info("********************************************************");

                return new BE.Nivel() { Id = 2, NombreNivel = "Nivel 2", Deporte = new BE.Deporte() { Id = 1 } };
            }

            if (arbitro.AniosExperiencia >= 2 &&
                arbitro.NotaAFA >= 6)
            {
                Logger.Log.Info("Nivel 3. Condiciones: 2 años o más de experiencia y 6 o más en la nota del examen de AFA.");
                Logger.Log.Info("Caracteristicas del árbitro:");
                Logger.Log.Info("Años de experiencia: " + arbitro.AniosExperiencia);
                Logger.Log.Info("Nota del examen de AFA: " + arbitro.NotaAFA);
                Logger.Log.Info("********************************************************");

                return new BE.Nivel() { Id = 3, NombreNivel = "Nivel 3", Deporte = new BE.Deporte() { Id = 1 } };
            }

            if (arbitro.AniosExperiencia >= 1 &&
                arbitro.NotaAFA >= 5)
            {
                Logger.Log.Info("Nivel 4. Condiciones: 1 año o más de experiencia y 5 o más en la nota del examen de AFA.");
                Logger.Log.Info("Caracteristicas del árbitro:");
                Logger.Log.Info("Años de experiencia: " + arbitro.AniosExperiencia);
                Logger.Log.Info("Nota del examen de AFA: " + arbitro.NotaAFA);
                Logger.Log.Info("********************************************************");

                return new BE.Nivel() { Id = 4, NombreNivel = "Nivel 4", Deporte = new BE.Deporte() { Id = 1 } };
            }

            Logger.Log.Info("Nivel 5. No cumple las condiciones para mayor nivel.");
            Logger.Log.Info("Caracteristicas del árbitro:");
            Logger.Log.Info("Años de experiencia: " + arbitro.AniosExperiencia);
            Logger.Log.Info("Nota del examen de AFA: " + arbitro.NotaAFA);

            Logger.Log.Info("********************************************************");

            return new BE.Nivel() { Id = 5, NombreNivel = "Nivel 5", Deporte = new BE.Deporte() { Id = 1 } };
        }
    }
}
