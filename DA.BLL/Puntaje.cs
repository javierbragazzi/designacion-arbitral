using System;
using System.Collections.Generic;
using System.Configuration;
using DA.SS;
using Situacion = DA.BE.Situacion;

namespace DA.BLL
{
    public class Puntaje
    {
     
        private readonly DAL.Puntaje _dalManagerPuntaje = new DAL.Puntaje();
                
        public List<BE.Puntaje> ObtenerPuntajeDeTemporada()
        {
            List<BE.Puntaje> lstPuntajes = _dalManagerPuntaje.ObtenerPuntajeDeTemporada();

            foreach (BE.Puntaje puntaje in lstPuntajes)
            {
                CalcularSituacion(puntaje);
            }

            return lstPuntajes;
        }

        public Resultado ActualizarNuevoNivel(BE.Puntaje pPuntaje)
        {
            ResultadoBd resultado = _dalManagerPuntaje.ActualizarNuevoNivel(pPuntaje);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(true, "No se pudo realizar la operación.");
        } 

        public Resultado ActualizarBaja(BE.Puntaje pPuntaje)
        {
            ResultadoBd resultado = _dalManagerPuntaje.ActualizarBaja(pPuntaje);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(true, "No se pudo realizar la operación.");
        } 

        public Resultado ActualizarProcesado(BE.Puntaje pPuntaje)
        {
            ResultadoBd resultado = _dalManagerPuntaje.ActualizarProcesado(pPuntaje);

            if (resultado == ResultadoBd.OK)
                return new Resultado(false, "Ok");


            return new Resultado(true, "No se pudo realizar la operación.");
        } 

        public void CalcularSituacion(BE.Puntaje puntaje)
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

        private static bool CalcularDescensoPorPuntaje(BE.Puntaje puntaje)
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

        private static bool CalcularAscesnsoPorPuntaje(BE.Puntaje puntaje)
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

        private static void DescenderNivel(BE.Puntaje puntaje, string motivo)
        {
            puntaje.Situacion = Situacion.Desciende;
            puntaje.NombreNivelNuevo = "Nivel " + (puntaje.IdNivel + 1);
            puntaje.IdNivelNuevo = puntaje.IdNivel + 1;
            puntaje.Motivo = motivo;
        }

        private static void AscenderNivel(BE.Puntaje puntaje, string motivo)
        {
            puntaje.Situacion = Situacion.Asciende;
            puntaje.NombreNivelNuevo = "Nivel " + (puntaje.IdNivel - 1);
            puntaje.IdNivelNuevo = puntaje.IdNivel - 1;
            puntaje.Motivo = motivo;
        }
    }
}
