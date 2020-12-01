using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Categoria
    {
        /// <summary>
        /// Dal manager Categoria
        /// </summary>
        private readonly DAL.Categoria _dalManagerCategoria = new DAL.Categoria();

        /// <summary>
        /// Agrega un nuevo Categoria al sistema.
        /// </summary>
        /// <param name="pCategoria">Categoria a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Categoria pCategoria)
        {
            var resultado = _dalManagerCategoria.Insertar(pCategoria);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Categoria.");
        }

        /// <summary>
        /// Edita un Categoria.
        /// </summary>
        /// <param name="pCategoria">Categoria a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Categoria pCategoria)
        {
            ResultadoBd resultado = _dalManagerCategoria.Actualizar(pCategoria);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Categoria.");
        }

        /// <summary>
        /// Quita un Categoria.
        /// </summary>
        /// <param name="pCategoria">Categoria a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Categoria pCategoria)
        {
            ResultadoBd resultado = _dalManagerCategoria.Borrar(pCategoria);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Categoria.");

        }

        /// <summary>
        /// Obtiene todos los Categorias.
        /// </summary>
        /// <returns></returns>
        public List<BE.Categoria> ObtenerCategorias()
        {
            BLL.Deporte bllDeporte = new BLL.Deporte();
            List<BE.Categoria> lstCategorias = _dalManagerCategoria.Leer();

            foreach (BE.Categoria unCategoria in lstCategorias)
            {
                unCategoria.Deporte = bllDeporte.ObtnerDeportePorId(unCategoria.Deporte.Id);
            }

            return lstCategorias;
        }

        public BE.Categoria ObtnerCategoriaPorId(int idCategoria)
        {
            BLL.Deporte bllDeporte = new BLL.Deporte();
            BE.Categoria beCategoria = _dalManagerCategoria.ObtenerCategoriaPorId(idCategoria);

            beCategoria.Deporte = bllDeporte.ObtnerDeportePorId(beCategoria.Deporte.Id);

            return beCategoria;

        }
        public BE.Categoria ObtnerCategoriaPorIdReducido(int idCategoria)
        {
            BLL.Deporte bllDeporte = new BLL.Deporte();
            BE.Categoria beCategoria = _dalManagerCategoria.ObtenerCategoriaPorId(idCategoria);

            //beCategoria.Deporte = bllDeporte.ObtnerDeportePorId(beCategoria.Deporte.Id);

            return beCategoria;

        }


        public List<BE.Categoria> ObtenerCategoriasPorIdDeporte(int deporteId)
        {
            BLL.Deporte bllDeporte = new BLL.Deporte();
            List<BE.Categoria> lstCategorias = _dalManagerCategoria.ObtenerCategoriaPorDeporteId(deporteId);

            foreach (BE.Categoria unCategoria in lstCategorias)
            {
                unCategoria.Deporte = bllDeporte.ObtnerDeportePorId(unCategoria.Deporte.Id);
            }

            return lstCategorias;

        }
    }
}
