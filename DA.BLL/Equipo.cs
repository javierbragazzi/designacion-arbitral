using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Equipo
    {
        /// <summary>
        /// Dal manager Equipo
        /// </summary>
        private readonly DAL.Equipo _dalManagerEquipo = new DAL.Equipo();

        /// <summary>
        /// Agrega un nuevo Equipo al sistema.
        /// </summary>
        /// <param name="pEquipo">Equipo a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Equipo pEquipo)
        {
            var resultado = _dalManagerEquipo.Insertar(pEquipo);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Equipo.");
        }

        /// <summary>
        /// Edita un Equipo.
        /// </summary>
        /// <param name="pEquipo">Equipo a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Equipo pEquipo)
        {
            ResultadoBd resultado = _dalManagerEquipo.Actualizar(pEquipo);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Equipo.");
        }

        /// <summary>
        /// Quita un Equipo.
        /// </summary>
        /// <param name="pEquipo">Equipo a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Equipo pEquipo)
        {
            ResultadoBd resultado = _dalManagerEquipo.Borrar(pEquipo);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Equipo.");

        }

        /// <summary>
        /// Obtiene todos los Equipos.
        /// </summary>
        /// <returns></returns>
        public List<BE.Equipo> ObtenerEquipos()
        {
            BLL.Categoria bllCategoria = new BLL.Categoria();
            List<BE.Equipo> lstEquipos = _dalManagerEquipo.Leer();

            foreach (BE.Equipo unEquipo in lstEquipos)
            {
                unEquipo.Categoria = bllCategoria.ObtnerCategoriaPorId(unEquipo.Categoria.Id);
            }

            return lstEquipos;
        }

        public List<BE.Equipo> ObtenerUltimosEquiposDirigidos(int idArbitro)
        {
            BLL.Categoria bllCategoria = new BLL.Categoria();
            List<BE.Equipo> lstEquipos = _dalManagerEquipo.ObtenerUltimosEquiposDirigidos(idArbitro);

            if (lstEquipos != null)
            {
                foreach (BE.Equipo unEquipo in lstEquipos)
                {
                    unEquipo.Categoria = bllCategoria.ObtnerCategoriaPorId(unEquipo.Categoria.Id);
                }
            }
            else 
                return new List<BE.Equipo>();

            return lstEquipos;
        }


        public BE.Equipo ObtnerEquipoPorId(int idEquipo)
        {
            BLL.Categoria bllCategoria = new BLL.Categoria();
            BE.Equipo beEquipo = _dalManagerEquipo.ObtenerEquipoPorId(idEquipo);

            beEquipo.Categoria = bllCategoria.ObtnerCategoriaPorId(beEquipo.Categoria.Id);

            return beEquipo;

        }

        public BE.Equipo ObtnerEquipoPorIdReducido(int idEquipo)
        {
            BLL.Categoria bllCategoria = new BLL.Categoria();
            BE.Equipo beEquipo = _dalManagerEquipo.ObtenerEquipoPorId(idEquipo);

            beEquipo.Categoria = bllCategoria.ObtnerCategoriaPorIdReducido(beEquipo.Categoria.Id);

            return beEquipo;

        }
    }
}
