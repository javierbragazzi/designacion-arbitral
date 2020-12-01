using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.BE;
using DA.SS;

namespace DA.DAL
{
    public class Fixture
    {
                 /// <summary>
        /// Acceso a la base de datos
        /// </summary>
        private readonly AccesoBaseDeDatos _accesoBaseDeDatos = new AccesoBaseDeDatos();

        /// <summary>
        /// Inserta un Fixture.
        /// </summary>
        /// <param name="pFixture">Fixture.</param>
        /// <returns></returns>
        public ResultadoBd Insertar(BE.Fixture pFixture)
        {

            return _accesoBaseDeDatos.Insertar(pFixture);
        }

 
        /// <summary>
        /// Actualiza un Fixture.
        /// </summary>
        /// <param name="pFixture">Fixture.</param>
        /// <returns></returns>
        public ResultadoBd Actualizar(BE.Fixture pFixture)
        {
            return _accesoBaseDeDatos.Actualizar(pFixture); 
        }

        /// <summary>
        /// Borra un Fixture.
        /// </summary>
        /// <param name="pFixture">Fixture.</param>
        /// <returns></returns>
        public ResultadoBd Borrar(BE.Fixture pFixture)
        {
            return _accesoBaseDeDatos.Borrar(pFixture);
        }

       
        public BE.Fixture ObtenerFixturePorId(int idFixture)
        {
            var dtFixture = _accesoBaseDeDatos.Seleccionar(new BE.Fixture(){Id = idFixture}, true);
     
            if (dtFixture.Rows.Count == 0)
                return null;

            var row = dtFixture.Rows[0];
            var aFixture = new BE.Fixture
            {
                Id = Convert.ToInt32(row["Id"]),
                Descripcion  = row["Descripcion"].ToString().Trim(),
                Fechas = new List<BE.Fecha>()
     
            };

            return aFixture;

        }

        public List<BE.Fixture> Leer()
        {
            var ls = new List<BE.Fixture>();

            BE.Fixture beFixture = new BE.Fixture();

            var dt = _accesoBaseDeDatos.Seleccionar(new BE.Fixture(), false);

            foreach (DataRow row in dt.Rows)
            {
                var aFixture = new BE.Fixture
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion  = row["Descripcion"].ToString().Trim(),
                    Fechas = new List<BE.Fecha>()
                };

                ls.Add(aFixture);
            }

            return ls;
        }


    }
}
