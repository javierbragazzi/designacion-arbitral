using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Genero
    {
         /// <summary>
        /// Dal manager Genero
        /// </summary>
        private readonly DAL.Genero _dalManagerGenero = new DAL.Genero();
        
        /// <summary>
        /// Agrega un nuevo Genero al sistema.
        /// </summary>
        /// <param name="pGenero">Genero a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Genero pGenero)
        {
            var resultado = _dalManagerGenero.Insertar(pGenero);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Genero.");
        }

        /// <summary>
        /// Edita un Genero.
        /// </summary>
        /// <param name="pGenero">Genero a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Genero pGenero)
        {
            ResultadoBd resultado = _dalManagerGenero.Actualizar(pGenero);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Genero.");
        }

        /// <summary>
        /// Quita un Genero.
        /// </summary>
        /// <param name="pGenero">Genero a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Genero pGenero)
        {
            ResultadoBd resultado = _dalManagerGenero.Borrar(pGenero);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Genero.");

        }

        /// <summary>
        /// Obtiene todos los Generos.
        /// </summary>
        /// <returns></returns>
        public List<BE.Genero> ObtenerGeneros()
        {
            List<BE.Genero> lstGeneros = _dalManagerGenero.Leer();

            return lstGeneros;
        }

        public BE.Genero ObtnerGeneroPorId(int idGenero)
        {
            BE.Genero beGenero = _dalManagerGenero.ObtenerGeneroPorId(idGenero);

            return beGenero;

        }      

        
    }
}
