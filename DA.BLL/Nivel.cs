namespace DA.BLL
{
    using DA.SS;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Nivel" />.
    /// </summary>
    public class Nivel
    {
        #region Fields

        /// <summary>
        /// Dal manager Nivel.
        /// </summary>
        private readonly DAL.Nivel _dalManagerNivel = new DAL.Nivel();

        #endregion

        #region Methods

        /// <summary>
        /// Agrega un nuevo Nivel al sistema.
        /// </summary>
        /// <param name="pNivel">Nivel a agregar.</param>
        /// <returns>.</returns>
        public Resultado Agregar(BE.Nivel pNivel)
        {
            var resultado = _dalManagerNivel.Insertar(pNivel);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Nivel.");
        }

        /// <summary>
        /// The AsignarNiveles.
        /// </summary>
        /// <param name="arbitrosSinNivel">The arbitrosSinNivel<see cref="List{BE.Arbitro}"/>.</param>
        /// <returns>The <see cref="List{BE.Arbitro}"/>.</returns>
        public List<BE.Arbitro> AsignarNiveles(List<BE.Arbitro> arbitrosSinNivel)
        {
            try
            {
                BLL.Arbitro bllArbitro = new BLL.Arbitro();
                List<BE.Arbitro> lstActualizada = new List<BE.Arbitro>();

                foreach (BE.Arbitro arbitro in arbitrosSinNivel)
                {
                    arbitro.Nivel = ObtenerNivel(arbitro);
                    lstActualizada.Add(arbitro);
                    var resultado = bllArbitro.Editar(arbitro);

                    if (resultado.HayError)
                    {
                        return null;
                    }
                }

                return lstActualizada;
            }
            catch (Exception e)
            {
                Logger.Log.Error("Error en AsignarNiveles. Error: " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Edita un Nivel.
        /// </summary>
        /// <param name="pNivel">Nivel a editar.</param>
        /// <returns>.</returns>
        public Resultado Editar(BE.Nivel pNivel)
        {
            ResultadoBd resultado = _dalManagerNivel.Actualizar(pNivel);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Nivel.");
        }

        /// <summary>
        /// Obtiene todos los Nivels.
        /// </summary>
        /// <returns>.</returns>
        public List<BE.Nivel> ObtenerNiveles()
        {
            BLL.NivelRegla bllNivelRegla = new BLL.NivelRegla();
            BLL.Deporte bllDeporte = new BLL.Deporte();
            List<BE.Nivel> lstNivels = _dalManagerNivel.Leer();

            //foreach (BE.Nivel beNivel in lstNivels)
            //{
            //    beNivel.Deporte = _bllDeporte.ObtnerDeportePorId(beNivel.Deporte.Id);
            //    beNivel.ReglasDeNivel = _bllNivelRegla.ObtenerReglasPorNivelId(beNivel.Id);
            //}

            return lstNivels;
        }

        /// <summary>
        /// Obtiene todos los Nivels.
        /// </summary>
        /// <param name="idDeporte">The idDeporte<see cref="int"/>.</param>
        /// <returns>.</returns>
        public List<BE.Nivel> ObtenerNivelesPorDeporte(int idDeporte)
        {
            List<BE.Nivel> lstNivels = _dalManagerNivel.Leer(idDeporte);
            return lstNivels;
        }

        /// <summary>
        /// The ObtnerNivelPorId.
        /// </summary>
        /// <param name="idNivel">The idNivel<see cref="int"/>.</param>
        /// <returns>The <see cref="BE.Nivel"/>.</returns>
        public BE.Nivel ObtnerNivelPorId(int idNivel)
        {
            if (idNivel != 0)
            {
                BLL.NivelRegla bllNivelRegla = new BLL.NivelRegla();
                BLL.Deporte bllDeporte = new BLL.Deporte();

                BE.Nivel beNivel = _dalManagerNivel.ObtenerNivelPorId(idNivel);

                beNivel.Deporte = bllDeporte.ObtnerDeportePorId(beNivel.Deporte.Id);
                beNivel.ReglasDeNivel = bllNivelRegla.ObtenerReglasPorNivelId(beNivel.Id);

                return beNivel;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// The ObtnerNivelReducidoPorId.
        /// </summary>
        /// <param name="idNivel">The idNivel<see cref="int"/>.</param>
        /// <returns>The <see cref="BE.Nivel"/>.</returns>
        public BE.Nivel ObtnerNivelReducidoPorId(int idNivel)
        {
            BE.Nivel beNivel = _dalManagerNivel.ObtenerNivelPorId(idNivel);
            return beNivel;
        }

        /// <summary>
        /// Quita un Nivel.
        /// </summary>
        /// <param name="pNivel">Nivel a quitar.</param>
        /// <returns>.</returns>
        public Resultado Quitar(BE.Nivel pNivel)
        {
            ResultadoBd resultado = _dalManagerNivel.Borrar(pNivel);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Nivel.");
        }

        /// <summary>
        /// The ObtenerNivel.
        /// </summary>
        /// <param name="arbitro">The arbitro<see cref="BE.Arbitro"/>.</param>
        /// <returns>The <see cref="BE.Nivel"/>.</returns>
        private BE.Nivel ObtenerNivel(BE.Arbitro arbitro)
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

                return new BE.Nivel() { Id = 1, NombreNivel = "Nivel 1", Deporte = new BE.Deporte() { Id = 1 } };
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

        #endregion
    }
}
