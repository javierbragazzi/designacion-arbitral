using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.SS;

namespace DA.BLL
{
    public class Campeonato
    {
        /// <summary>
        /// Dal manager Campeonato
        /// </summary>
        private readonly DAL.Campeonato _dalManagerCampeonato = new DAL.Campeonato();
        
        /// <summary>
        /// Agrega un nuevo Campeonato al sistema.
        /// </summary>
        /// <param name="pCampeonato">Campeonato a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Campeonato pCampeonato)
        {
            var resultado = _dalManagerCampeonato.Insertar(pCampeonato);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Campeonato.");
        }

        /// <summary>
        /// Edita un Campeonato.
        /// </summary>
        /// <param name="pCampeonato">Campeonato a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Campeonato pCampeonato)
        {
            ResultadoBd resultado = _dalManagerCampeonato.Actualizar(pCampeonato);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Campeonato.");
        }

        /// <summary>
        /// Quita un Campeonato.
        /// </summary>
        /// <param name="pCampeonato">Campeonato a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Campeonato pCampeonato)
        {
            ResultadoBd resultado = _dalManagerCampeonato.Borrar(pCampeonato);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Campeonato.");

        }

        /// <summary>
        /// Obtiene todos los Campeonatos.
        /// </summary>
        /// <returns></returns>
        public List<BE.Campeonato> ObtenerCampeonatos()
        {
            BLL.Categoria bllCategoria = new BLL.Categoria();
            BLL.Fixture bllFixture = new BLL.Fixture();
            List<BE.Campeonato> lstCampeonatos = _dalManagerCampeonato.Leer();

            foreach (BE.Campeonato unCampeonato in lstCampeonatos)
            {
                unCampeonato.Categoria = bllCategoria.ObtnerCategoriaPorId(unCampeonato.Categoria.Id);
                unCampeonato.Fixture = bllFixture.ObtnerFixturePorId(unCampeonato.Fixture.Id);
            }

            return lstCampeonatos;
        }

        public List<BE.Campeonato> ObtenerCampeonatosReducido()
        {
            BLL.Categoria bllCategoria = new BLL.Categoria();
            BLL.Fixture bllFixture = new BLL.Fixture();
            List<BE.Campeonato> lstCampeonatos = _dalManagerCampeonato.Leer();

            foreach (BE.Campeonato unCampeonato in lstCampeonatos)
            {
                unCampeonato.Categoria.Id = unCampeonato.Categoria.Id;
                unCampeonato.Fixture.Id = unCampeonato.Fixture.Id;
            }

            return lstCampeonatos;
        }

        public BE.Campeonato ObtnerCampeonatoPorId(int idCampeonato)
        {
            BLL.Categoria bllCategoria = new BLL.Categoria();
            BLL.Fixture bllFixture = new BLL.Fixture();
            BE.Campeonato beCampeonato = _dalManagerCampeonato.ObtenerCampeonatoPorId(idCampeonato);

            beCampeonato.Categoria = bllCategoria.ObtnerCategoriaPorId(beCampeonato.Categoria.Id);
            beCampeonato.Fixture = bllFixture.ObtnerFixturePorId(beCampeonato.Fixture.Id);

            return beCampeonato;

        }

        public List<BE.Campeonato> ObtenerCampeonatosReducidoPorIdDeporte(int idDeporte)
        {
            List<BE.Campeonato> lstCampeonatos = _dalManagerCampeonato.ObtenerCampeonatosPorDeporteId(idDeporte);

            foreach (BE.Campeonato unCampeonato in lstCampeonatos)
            {
                unCampeonato.Categoria.Id = unCampeonato.Categoria.Id;
                unCampeonato.Fixture.Id = unCampeonato.Fixture.Id;
            }

            return lstCampeonatos;
        }

        public string ObtenerNombreCampeonatoPorFixture(int idFixture)
        {
            return _dalManagerCampeonato.ObtenerNombreCampeonatoPorFixture(idFixture);
        }
    }
}
