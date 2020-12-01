using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.BE;
using DA.SS;

namespace DA.BLL
{
    public class Idioma
    {
        /// <summary>
        /// Dal manager Idioma
        /// </summary>
        private readonly DAL.Idioma _dalManagerIdioma = new DAL.Idioma();

   
  /// <summary>
        /// Agrega un nuevo Idioma al sistema.
        /// </summary>
        /// <param name="pIdioma">Idioma a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Idioma pIdioma)
        {
            var resultado = _dalManagerIdioma.Insertar(pIdioma);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Idioma.");
        }

        /// <summary>
        /// Edita un Idioma.
        /// </summary>
        /// <param name="pIdioma">Idioma a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Idioma pIdioma)
        {
            //ResultadoBd resultado = _dalManagerIdioma.Actualizar(pIdioma);
            try
            {
                BLL.Leyenda bllLeyenda = new BLL.Leyenda();
                BLL.Traduccion bllTraduccion = new BLL.Traduccion();

                foreach (BE.Leyenda leyenda in pIdioma.Leyendas)
                {
                    bllTraduccion.Editar(leyenda.Traduccion);
                   // bllLeyenda.Editar(leyenda);
                }

                return new Resultado(false, "Ok");
            }
            catch (Exception e)
            {
                Logger.Log.Error("No se pudo editar el Idioma.", e);
                return new Resultado(false, "No se pudo editar el Idioma.");
            }
 
        }

        /// <summary>
        /// Quita un Idioma.
        /// </summary>
        /// <param name="pIdioma">Idioma a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Idioma pIdioma)
        {
            ResultadoBd resultado = _dalManagerIdioma.Borrar(pIdioma);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Idioma.");

        }

        /// <summary>
        /// Obtiene todos los Idiomas.
        /// </summary>
        /// <returns></returns>
        public List<BE.Idioma> ObtenerIdiomas()
        {
            BLL.Leyenda bllLeyenda = new BLL.Leyenda();
            List<BE.Idioma> lstIdiomas = _dalManagerIdioma.Leer();

            foreach (BE.Idioma idioma in lstIdiomas)
            {
                idioma.Leyendas = bllLeyenda.ObtenerLeyendasPorIdIdioma(idioma.Id) ?? bllLeyenda.ObtenerLeyendas();
            }

            return lstIdiomas;
        }


        public BE.Idioma ObtenerIdiomaDeUsuario(int idUsuario)
        {
            BLL.Leyenda bllLeyenda = new BLL.Leyenda();
            BE.Idioma beIdioma = _dalManagerIdioma.ObtenerIdiomaDeUsuario(idUsuario);

           // beIdioma.Idioma.Descripcion = (IdiomaEnum) beIdioma.Id;

            beIdioma.Leyendas = bllLeyenda.ObtenerLeyendasPorIdIdioma(beIdioma.Id);

            return beIdioma;

        }

        public BE.Idioma ObtnerIdiomaPorId(int idIdioma)
        {
            BLL.Leyenda bllLeyenda = new BLL.Leyenda();
            BE.Idioma beIdioma = _dalManagerIdioma.ObtenerIdiomaPorId(idIdioma);

            beIdioma.Leyendas = bllLeyenda.ObtenerLeyendasPorIdIdioma(beIdioma.Id);

            return beIdioma;

        }
    }
}
