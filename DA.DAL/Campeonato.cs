using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class Campeonato
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Campeonato.
        /// </summary>
        /// <param name="pCampeonato">Campeonato.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Campeonato pCampeonato)
        {

            return _accesoBaseDeDatos.Insertar(pCampeonato);
        }

 
        /// <summary>
        /// Actualiza un Campeonato.
        /// </summary>
        /// <param name="pCampeonato">Campeonato.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Campeonato pCampeonato)
        {
            return _accesoBaseDeDatos.Actualizar(pCampeonato); 
        }

        /// <summary>
        /// Borra un Campeonato.
        /// </summary>
        /// <param name="pCampeonato">Campeonato.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Campeonato pCampeonato)
        {
            return _accesoBaseDeDatos.Borrar(pCampeonato);
        }

       
        public BE.Campeonato ObtenerCampeonatoPorId(int idCampeonato)
        {
            var dtCampeonato = _accesoBaseDeDatos.Seleccionar(new BE.Campeonato(){Id = idCampeonato}, true);
     
            if (dtCampeonato.Rows.Count == 0)
                return null;

            var row = dtCampeonato.Rows[0];
            var aCampeonato = new BE.Campeonato
            {
                Id = Convert.ToInt32(row["Id"]),
                Descripcion  = row["Descripcion"].ToString().Trim(),
                Categoria = new BE.Categoria() { Id = Convert.ToInt32(row["IdCategoria"]) },
                Fixture = new BE.Fixture() { Id = Convert.ToInt32(row["IdFixture"]) },
     
            };

            return aCampeonato;

        }

        public List<BE.Campeonato> Leer()
        {
            var ls = new List<BE.Campeonato>();

            BE.Campeonato beCampeonato = new BE.Campeonato();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Campeonato(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aCampeonato = new BE.Campeonato
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion  = row["Descripcion"].ToString().Trim(),
                    Categoria = new BE.Categoria() { Id = Convert.ToInt32(row["IdCategoria"]) },
                    Fixture = new BE.Fixture() { Id = Convert.ToInt32(row["IdFixture"]) },
                };

                ls.Add(aCampeonato);
            }

            return ls;
        }

        public List<BE.Campeonato> ObtenerCampeonatosPorDeporteId(int idDeporte)
        {
            var ls = new List<BE.Campeonato>();
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdDeporte", idDeporte);

            string query = @" select cam.*
                                from Campeonato cam
                                inner join Categoria cat on ( cam.IdCategoria = cat.Id )
                                where cat.IdDeporte =  @IdDeporte";

            var dt = _accesoBaseDeDatos.Seleccionar(query, pars);
     
            foreach (DataRow row in dt.Rows)
            {
                var aCampeonato = new BE.Campeonato
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion  = row["Descripcion"].ToString().Trim(),
                    Categoria = new BE.Categoria() { Id = Convert.ToInt32(row["IdCategoria"]) },
                    Fixture = new BE.Fixture() { Id = Convert.ToInt32(row["IdFixture"]) },
                };

                ls.Add(aCampeonato);
            }

            return ls;
        }

        public string ObtenerNombreCampeonatoPorFixture(int idFixture)
        {
            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdFixture", idFixture);

            string query = @" select cam.Descripcion
                            from Campeonato cam
                            where cam.IdFixture =  @IdFixture";

            var dtCampeonato = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dtCampeonato.Rows.Count == 0)
                return null;

            var row = dtCampeonato.Rows[0];

            return row["Descripcion"].ToString().Trim();
 
        }
    }
}
