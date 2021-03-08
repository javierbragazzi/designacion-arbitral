using System;
using System.Collections.Generic;
using System.Configuration;
using DA.BE;
using DA.SS;

namespace DA.BLL
{
    public class Calificacion
    {
        /// <summary>
        /// Dal manager Calificacion
        /// </summary>
        private readonly DAL.Calificacion _dalManagerCalificacion = new DAL.Calificacion();

        /// <summary>
        /// Agrega un nuevo Calificacion al sistema.
        /// </summary>
        /// <param name="pCalificacion">Calificacion a agregar.</param>
        /// <param name="pPartido"></param>
        /// <param name="idArbitro"></param>
        /// <param name="idTipoArbitro"></param>
        /// <returns></returns>
        public Resultado Agregar(BE.Calificacion pCalificacion, BE.Partido pPartido, int idArbitro, int idTipoArbitro)
        {
            var resultado = _dalManagerCalificacion.Insertar(pCalificacion, pPartido, idArbitro, idTipoArbitro);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");

            return new Resultado(false, "No se dio de alta la calificación.");
        }

        /// <summary>
        /// Edita un Calificacion.
        /// </summary>
        /// <param name="pCalificacion">Calificacion a editar.</param>
        /// <returns></returns>
        public Resultado Editar(BE.Calificacion pCalificacion)
        {
            ResultadoBd resultado = _dalManagerCalificacion.Actualizar(pCalificacion);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo editar la calificación.");
        }

        /// <summary>
        /// Quita un Calificacion.
        /// </summary>
        /// <param name="pCalificacion">Calificacion a quitar.</param>
        /// <returns></returns>
        public Resultado Quitar(BE.Calificacion pCalificacion)
        {
            ResultadoBd resultado = _dalManagerCalificacion.Borrar(pCalificacion);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(false, "No se pudo borrar la calificación.");

        }

        public BE.Calificacion ObtenerCalificacionPorId(int idCalificacion)
        {
            BE.Calificacion beCalificacion = _dalManagerCalificacion.ObtenerCalificacionPorId(idCalificacion);

            return beCalificacion;
        }

                public List<PuntajeArbitro> ObtenerPuntajeDeTemporada()
        {
            List<PuntajeArbitro> lstPuntajes = _dalManagerCalificacion.ObtenerPuntajeDeTemporada();

            foreach (PuntajeArbitro puntaje in lstPuntajes)
            {
                CalcularSituacion(puntaje);
            }

            return lstPuntajes;
        }

        public Resultado ActualizarNuevoNivel(PuntajeArbitro pPuntaje)
        {
            ResultadoBd resultado = _dalManagerCalificacion.ActualizarNuevoNivel(pPuntaje);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(true, "No se pudo realizar la operación.");
        } 

        public Resultado ActualizarBaja(PuntajeArbitro pPuntaje)
        {
            ResultadoBd resultado = _dalManagerCalificacion.ActualizarBaja(pPuntaje);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(true, "No se pudo realizar la operación.");
        } 

        public Resultado ActualizarProcesado(PuntajeArbitro pPuntaje)
        {
            ResultadoBd resultado = _dalManagerCalificacion.ActualizarProcesado(pPuntaje);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(true, "No se pudo realizar la operación.");
        } 

        public void CalcularSituacion(PuntajeArbitro puntaje)
        {
            //Baja por edad
            if (puntaje.Edad >= 50)
            {
                puntaje.Situacion = Situacion.Baja;
                puntaje.NombreNivelNuevo = "-";
                puntaje.IdNivelNuevo = -1;
                puntaje.Motivo = "Baja por edad";

                return;
            }

            //Descenso por no cumplir cantidad de partidos minimo
            int minimoPartidos = Convert.ToInt32(ConfigurationManager.AppSettings["MinimoPartidos"]);

            if (puntaje.CantidadPartidos < minimoPartidos)
            {
                DescenderNivel(puntaje, "No cumple cant. min. partidos");

                return;
            }

            //Descenso por puntaje
            if (CalcularDescensoPorPuntaje(puntaje)) 
                return;

            //Ascenso por puntaje
            if (CalcularAscesnsoPorPuntaje(puntaje)) 
                return;

            puntaje.Situacion = Situacion.Mantiene;
            puntaje.NombreNivelNuevo = "-";
            puntaje.IdNivelNuevo = -1;
            puntaje.Motivo = "Se mantiene el nivel";

        }

        private static bool CalcularDescensoPorPuntaje(PuntajeArbitro puntaje)
        {
            switch (puntaje.IdNivel)
            {
                case 1:
                    if (puntaje.PuntajePromedio > 0 && puntaje.PuntajePromedio <= 7.99D)
                    {
                        DescenderNivel(puntaje, "Bajo puntaje promedio para el nivel");

                        return true;
                    }

                    break;

                case 2:
                    if (puntaje.PuntajePromedio > 0 && puntaje.PuntajePromedio <= 6.99D)
                    {
                        DescenderNivel(puntaje, "Bajo puntaje promedio para el nivel");

                        return true;
                    }

                    break;


                case 3:
                    if (puntaje.PuntajePromedio > 0 && puntaje.PuntajePromedio <= 5.99D)
                    {
                        DescenderNivel(puntaje, "Bajo puntaje promedio para el nivel");

                        return true;
                    }

                    break;

                case 4:
                    if (puntaje.PuntajePromedio > 0 && puntaje.PuntajePromedio <= 4.99D)
                    {
                        DescenderNivel(puntaje, "Bajo puntaje promedio para el nivel");

                        return true;
                    }

                    break;
            }

            return false;
        }

        private static bool CalcularAscesnsoPorPuntaje(PuntajeArbitro puntaje)
        {
            switch (puntaje.IdNivel)
            {
                case 2:
                    if (puntaje.PuntajePromedio >= 9 && puntaje.PuntajePromedio <= 10)
                    {
                        AscenderNivel(puntaje, "Supera el puntaje promedio para el nivel");

                        return true;
                    }

                    break;

                case 3:
                    if (puntaje.PuntajePromedio > 8 && puntaje.PuntajePromedio <= 10)
                    {
                        AscenderNivel(puntaje, "Supera el puntaje promedio para el nivel");

                        return true;
                    }

                    break;


                case 4:
                    if (puntaje.PuntajePromedio > 7 && puntaje.PuntajePromedio <= 10)
                    {
                        AscenderNivel(puntaje, "Supera el puntaje promedio para el nivel");

                        return true;
                    }

                    break;

                case 5:
                    if (puntaje.PuntajePromedio > 6 && puntaje.PuntajePromedio <= 10)
                    {
                        AscenderNivel(puntaje, "Supera el puntaje promedio para el nivel");

                        return true;
                    }

                    break;
            }

            return false;
        }

        private static void DescenderNivel(PuntajeArbitro puntaje, string motivo)
        {
            puntaje.Situacion = Situacion.Desciende;
            puntaje.NombreNivelNuevo = "Nivel " + (puntaje.IdNivel + 1);
            puntaje.IdNivelNuevo = puntaje.IdNivel + 1;
            puntaje.Motivo = motivo;
        }

        private static void AscenderNivel(PuntajeArbitro puntaje, string motivo)
        {
            puntaje.Situacion = Situacion.Asciende;
            puntaje.NombreNivelNuevo = "Nivel " + (puntaje.IdNivel - 1);
            puntaje.IdNivelNuevo = puntaje.IdNivel - 1;
            puntaje.Motivo = motivo;
        }


    }
}
