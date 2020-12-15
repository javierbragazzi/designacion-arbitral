using System.Collections.Generic;
using DA.SS;

namespace DA.BLL
{
    public class Nivel
    {
         /// <summary>
        /// Dal manager Nivel
        /// </summary>
        private readonly DAL.Nivel _dalManagerNivel = new DAL.Nivel();
         
        /// <summary>
        /// Agrega un nuevo Nivel al sistema.
        /// </summary>
        /// <param name="pNivel">Nivel a agregar.</param>
        /// <returns></returns>
        public Resultado Agregar(BE.Nivel pNivel)
        {
            var resultado = _dalManagerNivel.Insertar(pNivel);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta el Nivel.");
        }

        /// <summary>
        /// Edita un Nivel.
        /// </summary>
        /// <param name="pNivel">Nivel a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Nivel pNivel)
        {
            ResultadoBd resultado = _dalManagerNivel.Actualizar(pNivel);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar el Nivel.");
        }

        /// <summary>
        /// Quita un Nivel.
        /// </summary>
        /// <param name="pNivel">Nivel a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Nivel pNivel)
        {
            ResultadoBd resultado = _dalManagerNivel.Borrar(pNivel);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar el Nivel.");

        }

        /// <summary>
        /// Obtiene todos los Nivels.
        /// </summary>
        /// <returns></returns>
        public List<BE.Nivel> ObtenerNiveles()
        {
            BLL.NivelRegla bllNivelRegla = new BLL.NivelRegla();
            BLL.Deporte bllDeporte = new BLL.Deporte();
            List<BE.Nivel> lstNivels = _dalManagerNivel.Leer();

            //foreach (BE.Nivel beNivel in lstNivels)
            //{
            //    beNivel.Deporte = _bllDeporte.ObtnerDeportePorId(beNivel.Deporte.Id);
            //    beNivel.ReglasDeNivel = _bllNivelRegla.ObtenerReglasPorNivelId(beNivel.Id);
            //}

            return lstNivels;
        }

        /// <summary>
        /// Obtiene todos los Nivels.
        /// </summary>
        /// <returns></returns>
        public List<BE.Nivel> ObtenerNivelesPorDeporte(int idDeporte)
        {
            List<BE.Nivel> lstNivels = _dalManagerNivel.Leer(idDeporte);
            return lstNivels;
        }

        public BE.Nivel ObtnerNivelPorId(int idNivel)
        {
            if (idNivel != 0)
            {
                BLL.NivelRegla bllNivelRegla = new BLL.NivelRegla();
                BLL.Deporte bllDeporte = new BLL.Deporte();

                BE.Nivel beNivel = _dalManagerNivel.ObtenerNivelPorId(idNivel);

                beNivel.Deporte = bllDeporte.ObtnerDeportePorId(beNivel.Deporte.Id);
                beNivel.ReglasDeNivel = bllNivelRegla.ObtenerReglasPorNivelId(beNivel.Id);

                return beNivel;
            }
            else
            {
                return null;
            }
        

           

        }

        public BE.Nivel ObtnerNivelReducidoPorId(int idNivel)
        {
            BE.Nivel beNivel = _dalManagerNivel.ObtenerNivelPorId(idNivel);
            return beNivel;

        }

        public List<BE.Arbitro> AsignarNiveles(List<BE.Arbitro> arbitrosSinNivel)
        {
            return _dalManagerNivel.AsignarNiveles(arbitrosSinNivel);
        }
    }
}
