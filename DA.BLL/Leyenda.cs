using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Leyenda
    {
        /// <summary>
        /// Dal manager Leyenda
        /// </summary>
        private readonly DAL.Leyenda _dalManagerLeyenda = new DAL.Leyenda();

        /// <summary>
        /// Agrega un nuevo Leyenda al sistema.
        /// </summary>
        /// <param name="pLeyenda">Leyenda a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Leyenda pLeyenda)
        {
            var resultado = _dalManagerLeyenda.Insertar(pLeyenda);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Leyenda.");
        }

        /// <summary>
        /// Edita un Leyenda.
        /// </summary>
        /// <param name="pLeyenda">Leyenda a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Leyenda pLeyenda)
        {
            ResultadoBd resultado = _dalManagerLeyenda.Actualizar(pLeyenda);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Leyenda.");
        }

        /// <summary>
        /// Quita un Leyenda.
        /// </summary>
        /// <param name="pLeyenda">Leyenda a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Leyenda pLeyenda)
        {
            ResultadoBd resultado = _dalManagerLeyenda.Borrar(pLeyenda);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Leyenda.");

        }

        public List<BE.Leyenda> ObtenerLeyendas()
        {
            List<BE.Leyenda> lstLeyendas = _dalManagerLeyenda.Leer();

       
            return lstLeyendas;
        }

        public List<BE.Leyenda> ObtenerLeyendasPorIdIdioma(int idIdioma)
        {
            return _dalManagerLeyenda.ObtenerLeyendasPorIdIdioma(idIdioma);
        }

    }
}
