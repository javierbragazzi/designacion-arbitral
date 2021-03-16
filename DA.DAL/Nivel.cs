namespace DA.DAL
{
    using DA.SS;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="Nivel" />.
    /// </summary>
    public class Nivel
    {
        #region Fields

        /// <summary>
        /// Acceso a la base de datos.
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        #endregion

        #region Methods

        /// <summary>
        /// Actualiza un Nivel.
        /// </summary>
        /// <param name="pNivel">Nivel.</param>
        /// <returns>.</returns>
        public ResultadoBd Actualizar(BE.Nivel pNivel)
        {
            return _accesoBaseDeDatos.Actualizar(pNivel);
        }

        /// <summary>
        /// Borra un Nivel.
        /// </summary>
        /// <param name="pNivel">Nivel.</param>
        /// <returns>.</returns>
        public ResultadoBd Borrar(BE.Nivel pNivel)
        {
            return _accesoBaseDeDatos.Borrar(pNivel);
        }

        /// <summary>
        /// Inserta un Nivel.
        /// </summary>
        /// <param name="pNivel">Nivel.</param>
        /// <returns>.</returns>
        public ResultadoBd Insertar(BE.Nivel pNivel)
        {

            return _accesoBaseDeDatos.Insertar(pNivel);
        }

        /// <summary>
        /// The Leer.
        /// </summary>
        /// <returns>The <see cref="List{BE.Nivel}"/>.</returns>
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

        /// <summary>
        /// The Leer.
        /// </summary>
        /// <param name="idDeporte">The idDeporte<see cref="int"/>.</param>
        /// <returns>The <see cref="List{BE.Nivel}"/>.</returns>
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

        /// <summary>
        /// The ObtenerNivelPorId.
        /// </summary>
        /// <param name="idNivel">The idNivel<see cref="int"/>.</param>
        /// <returns>The <see cref="BE.Nivel"/>.</returns>
        public BE.Nivel ObtenerNivelPorId(int idNivel)
        {
            var dtNivel = _accesoBaseDeDatos.Seleccionar(new BE.Nivel() { Id = idNivel }, true, true);

            if (dtNivel.Rows.Count == 0)
                return null;

            var row = dtNivel.Rows[0];
            var aNivel = new BE.Nivel
            {
                Id = Convert.ToInt32(row["Id"]),
                NombreNivel = row["NombreNivel"].ToString().Trim(),
                Deporte = new BE.Deporte() { Id = Convert.ToInt32(row["IdDeporte"]) },
                ReglasDeNivel = new List<BE.NivelRegla>()

            };

            return aNivel;
        }

        #endregion
    }
}
