using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Fixture
    {
        /// <summary>
        /// Dal manager Fixture
        /// </summary>
        private readonly DAL.Fixture _dalManagerFixture = new DAL.Fixture();
   
        /// <summary>
        /// Agrega un nuevo Fixture al sistema.
        /// </summary>
        /// <param name="pFixture">Fixture a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Fixture pFixture)
        {
            var resultado = _dalManagerFixture.Insertar(pFixture);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Fixture.");
        }

        /// <summary>
        /// Edita un Fixture.
        /// </summary>
        /// <param name="pFixture">Fixture a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Fixture pFixture)
        {
            ResultadoBd resultado = _dalManagerFixture.Actualizar(pFixture);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(true, "No se pudo editar el Fixture.");
        }

        /// <summary>
        /// Quita un Fixture.
        /// </summary>
        /// <param name="pFixture">Fixture a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Fixture pFixture)
        {
            ResultadoBd resultado = _dalManagerFixture.Borrar(pFixture);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Fixture.");

        }

        /// <summary>
        /// Obtiene todos los Fixtures.
        /// </summary>
        /// <returns></returns>
        public List<BE.Fixture> ObtenerFixtures()
        {
            BLL.Fecha bllFecha = new BLL.Fecha();
            List<BE.Fixture> lstFixtures = _dalManagerFixture.Leer();

            foreach (BE.Fixture beFixture in lstFixtures)
            {
                beFixture.Fechas = bllFecha.ObtenerFechasPorIdFixture(beFixture.Id);
            }

            return lstFixtures;
        }

        public BE.Fixture ObtnerFixturePorId(int idFixture)
        {
            BLL.Fecha bllFecha = new BLL.Fecha();
            BE.Fixture beFixture = _dalManagerFixture.ObtenerFixturePorId(idFixture);

            beFixture.Fechas = bllFecha.ObtenerFechasPorIdFixture(beFixture.Id);

            return beFixture;

        }
    }
}
