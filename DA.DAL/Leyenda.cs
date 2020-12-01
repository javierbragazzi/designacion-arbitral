using System;
using System.Collections.Generic;
using System.Data;
using DA.SS;

namespace DA.DAL
{
    public class Leyenda
    {
        /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Leyenda.
        /// </summary>
        /// <param name="pLeyenda">Leyenda.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Leyenda pLeyenda)
        {

            return _accesoBaseDeDatos.Insertar(pLeyenda);
        }


        /// <summary>
        /// Actualiza un Leyenda.
        /// </summary>
        /// <param name="pLeyenda">Leyenda.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Leyenda pLeyenda)
        {
            return _accesoBaseDeDatos.Actualizar(pLeyenda);
        }

        /// <summary>
        /// Borra un Leyenda.
        /// </summary>
        /// <param name="pLeyenda">Leyenda.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Leyenda pLeyenda)
        {
            return _accesoBaseDeDatos.Borrar(pLeyenda);
        }



        public List<BE.Leyenda> ObtenerLeyendasPorIdIdioma(int idIdioma)
        {
            List<BE.Leyenda> lstLeyendas = new List<BE.Leyenda>();

            var pars = new IDbDataParameter[1];
            pars[0] = _accesoBaseDeDatos.CrearParametro("@IdIdioma", idIdioma);

            string query = @"SELECT distinct(tra.Id) as IdTraduccion ,ley.Id, ley.Etiqueta, tra.TextoTraducido
                            FROM Idioma idi 
                            INNER JOIN Traduccion tra ON ( idi.Id = tra.IdIdioma )
                            INNER JOIN Leyenda ley ON ( ley.Id = tra.IdLeyenda  )
                            WHERE idi.Id = @IdIdioma";

            var dtLeyendas = _accesoBaseDeDatos.Seleccionar(query, pars);

            if (dtLeyendas.Rows.Count == 0)
                return null;

            foreach (DataRow row in dtLeyendas.Rows)
            {
                var aLeyenda = new BE.Leyenda()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Etiqueta = row["Etiqueta"].ToString().Trim(),
                    Traduccion = new BE.Traduccion() { Id = Convert.ToInt32(row["IdTraduccion"]), TextoTraducido = row["TextoTraducido"].ToString().Trim() },
                };

                lstLeyendas.Add(aLeyenda);
            }

            return lstLeyendas;
        }

        public List<BE.Leyenda> Leer()
        {
            var ls = new List<BE.Leyenda>();

            BE.Leyenda beLeyenda = new BE.Leyenda();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Leyenda(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aLeyenda = new BE.Leyenda
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Etiqueta = row["Etiqueta"].ToString().Trim(),
                };

                ls.Add(aLeyenda);
            }

            return ls;
        }
    }
}
