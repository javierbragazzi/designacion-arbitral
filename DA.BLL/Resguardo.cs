using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.SS;

namespace DA.BLL
{
    public class Resguardo
    {
        /// <summary>
        /// Dal manager Resguardo
        /// </summary>
        private readonly DAL.Resguardo _dalManagerResguardo = new DAL.Resguardo();


        /// <summary>
        /// Agrega un nuevo Resguardo al sistema.
        /// </summary>
        /// <param name="pResguardo">Resguardo a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Resguardo pResguardo)
        {
            var resultado = _dalManagerResguardo.Insertar(pResguardo);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Resguardo.");
        }

        /// <summary>
        /// Edita un Resguardo.
        /// </summary>
        /// <param name="pResguardo">Resguardo a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Resguardo pResguardo)
        {
            ResultadoBd resultado = _dalManagerResguardo.Actualizar(pResguardo);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Resguardo.");
        }

        /// <summary>
        /// Quita un Resguardo.
        /// </summary>
        /// <param name="pResguardo">Resguardo a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Resguardo pResguardo)
        {
            ResultadoBd resultado = _dalManagerResguardo.Borrar(pResguardo);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Resguardo.");

        }

        /// <summary>
        /// Obtiene todos los Resguardos.
        /// </summary>
        /// <returns></returns>
        public List<BE.Resguardo> ObtenerResguardos()
        {
            List<BE.Resguardo> lstResguardos = _dalManagerResguardo.Leer();

    
            return lstResguardos;
        }

        public BE.Resguardo ObtenerResguardoPorId(int idResguardo)
        {
            return _dalManagerResguardo.ObtenerResguardoPorId(idResguardo);

        }



    }
}
