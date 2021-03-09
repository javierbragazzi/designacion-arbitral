using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.SS;

namespace DA.BLL
{
    public class NivelRegla
    {
         /// <summary>
        /// Dal manager NivelRegla
        /// </summary>
        private readonly DAL.NivelRegla _dalManagerNivelRegla = new DAL.NivelRegla();
   
        

        /// <summary>
        /// Agrega un nuevo NivelRegla al sistema.
        /// </summary>
        /// <param name="pNivelRegla">NivelRegla a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.NivelRegla pNivelRegla)
        {
            var resultado = _dalManagerNivelRegla.Insertar(pNivelRegla);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el NivelRegla.");
        }

        /// <summary>
        /// Edita un NivelRegla.
        /// </summary>
        /// <param name="pNivelRegla">NivelRegla a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.NivelRegla pNivelRegla)
        {
            ResultadoBd resultado = _dalManagerNivelRegla.Actualizar(pNivelRegla);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el NivelRegla.");
        }

        /// <summary>
        /// Quita un NivelRegla.
        /// </summary>
        /// <param name="pNivelRegla">NivelRegla a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.NivelRegla pNivelRegla)
        {
            ResultadoBd resultado = _dalManagerNivelRegla.Borrar(pNivelRegla);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el NivelRegla.");

        }

        /// <summary>
        /// Obtiene todos los NivelReglas.
        /// </summary>
        /// <returns></returns>
        public List<BE.NivelRegla> ObtenerNivelReglas()
        {
            BLL.Categoria bllCategoria = new BLL.Categoria();
            BLL.TipoArbitro bllTipoArbitro = new BLL.TipoArbitro();
            List<BE.NivelRegla> lstNivelReglas = _dalManagerNivelRegla.Leer();

            foreach (BE.NivelRegla beNivelRegla in lstNivelReglas)
            {
                beNivelRegla.Categoria = bllCategoria.ObtnerCategoriaPorId(beNivelRegla.Categoria.Id);
                beNivelRegla.TipoArbitro = bllTipoArbitro.ObtnerTipoArbitroPorId(beNivelRegla.TipoArbitro.Id);
            }

            return lstNivelReglas;
        }

        public BE.NivelRegla ObtnerNivelReglaPorId(int idNivelRegla)
        {
            BLL.Categoria bllCategoria = new BLL.Categoria();
            BLL.TipoArbitro bllTipoArbitro = new BLL.TipoArbitro();
            BE.NivelRegla beNivelRegla = _dalManagerNivelRegla.ObtenerNivelReglaPorId(idNivelRegla);

            beNivelRegla.Categoria = bllCategoria.ObtnerCategoriaPorId(beNivelRegla.Categoria.Id);
            beNivelRegla.TipoArbitro = bllTipoArbitro.ObtnerTipoArbitroPorId(beNivelRegla.TipoArbitro.Id);

            return beNivelRegla;

        }

        public List<BE.NivelRegla> ObtenerReglasPorNivelId(int idNivel)
        {
            BLL.Categoria bllCategoria = new BLL.Categoria();
            BLL.TipoArbitro bllTipoArbitro = new BLL.TipoArbitro();
            List<BE.NivelRegla> lstNivelReglas = _dalManagerNivelRegla.ObtenerReglasPorNivelId(idNivel);

            foreach (BE.NivelRegla beNivelRegla in lstNivelReglas)
            {
                beNivelRegla.Categoria = bllCategoria.ObtnerCategoriaPorIdReducido(beNivelRegla.Categoria.Id);
                beNivelRegla.TipoArbitro = bllTipoArbitro.ObtnerTipoArbitroPorIdReducido(beNivelRegla.TipoArbitro.Id);
            }

            return lstNivelReglas;
        }
        
        public bool PuedeDirigirPartidoComoTipoArbitro(BE.Arbitro arbitro, PartidoHelperUI partido, BE.TipoArbitro tipoDeArbitroAAsignar)
        {
            foreach (BE.NivelRegla aLevelRule in arbitro.Nivel.ReglasDeNivel)
            {
                if (partido.Equipo1.Categoria.Equals(aLevelRule.Categoria))
                {
                    if (tipoDeArbitroAAsignar.Equals(aLevelRule.TipoArbitro))
                    {
                        return true;
                    }
                    else
                    {
                        Logger.Log.Info("Resultado: Fallido Razon: Arbitro " + arbitro.Apellido + " no puede ser "+ tipoDeArbitroAAsignar.Descripcion + " de este partido.");
                        Logger.Log.Info("Nivel del árbitro: " + arbitro.Nivel.NombreNivel + " - Categoría del partido: " + partido.Equipo1.Categoria.Descripcion);
                        Logger.Log.Info("---------------------------------------");
                    }
                }
            }
            return false;
        }

    }
}
