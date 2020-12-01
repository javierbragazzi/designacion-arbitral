using System;
using DA.BE;
using DA.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DA.UnitTest
{
    [TestClass]
    public class PromocionDescensoTests
    {
        //Asciende,
        //Desciende,
        //Mantiene,
        //Baja
        [TestMethod]
        public void BajaPorEdadTest()
        {
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            BE.Puntaje bePuntaje = new BE.Puntaje();

            bePuntaje.Edad = 52;

            bllPuntaje.CalcularSituacion(bePuntaje);

            Assert.AreEqual(Situacion.Baja, bePuntaje.Situacion);

        }

        [TestMethod]
        public void BajaPorMinimoPartidosTest()
        {
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            BE.Puntaje bePuntaje = new BE.Puntaje();

            bePuntaje.CantidadPartidos = 2;

            bllPuntaje.CalcularSituacion(bePuntaje);

            Assert.AreEqual(Situacion.Desciende, bePuntaje.Situacion);

        }

        [TestMethod]
        public void DescensoPorPuntajeNivel1Test()
        {
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            BE.Puntaje bePuntaje = new BE.Puntaje();

            bePuntaje.IdNivel = 1;
            bePuntaje.PuntajePromedio = 7.25D;
            bePuntaje.CantidadPartidos = 10;

            bllPuntaje.CalcularSituacion(bePuntaje);

            Assert.AreEqual(Situacion.Desciende, bePuntaje.Situacion);
            Assert.AreEqual(2,bePuntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void DescensoPorPuntajeNivel2Test()
        {
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            BE.Puntaje bePuntaje = new BE.Puntaje();

            bePuntaje.IdNivel = 2;
            bePuntaje.PuntajePromedio = 6.25;
            bePuntaje.CantidadPartidos = 10;

            bllPuntaje.CalcularSituacion(bePuntaje);

            Assert.AreEqual(Situacion.Desciende, bePuntaje.Situacion);
            Assert.AreEqual(3,bePuntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void DescensoPorPuntajeNivel3Test()
        {
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            BE.Puntaje bePuntaje = new BE.Puntaje();

            bePuntaje.IdNivel = 3;
            bePuntaje.PuntajePromedio = 5.25D;
            bePuntaje.CantidadPartidos = 10;

            bllPuntaje.CalcularSituacion(bePuntaje);

            Assert.AreEqual(Situacion.Desciende, bePuntaje.Situacion);
            Assert.AreEqual(4,bePuntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void DescensoPorPuntajeNivel4Test()
        {
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            BE.Puntaje bePuntaje = new BE.Puntaje();

            bePuntaje.IdNivel = 4;
            bePuntaje.PuntajePromedio = 4.25D;
            bePuntaje.CantidadPartidos = 10;

            bllPuntaje.CalcularSituacion(bePuntaje);

            Assert.AreEqual(Situacion.Desciende, bePuntaje.Situacion);
            Assert.AreEqual(5,bePuntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void AscensoPorPuntajeNivel2Test()
        {
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            BE.Puntaje bePuntaje = new BE.Puntaje();

            bePuntaje.IdNivel = 2;
            bePuntaje.PuntajePromedio = 9.25D;
            bePuntaje.CantidadPartidos = 10;

            bllPuntaje.CalcularSituacion(bePuntaje);

            Assert.AreEqual(Situacion.Asciende, bePuntaje.Situacion);
            Assert.AreEqual(1,bePuntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void AscensoPorPuntajeNivel3Test()
        {
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            BE.Puntaje bePuntaje = new BE.Puntaje();

            bePuntaje.IdNivel = 3;
            bePuntaje.PuntajePromedio = 8.25D;
            bePuntaje.CantidadPartidos = 10;

            bllPuntaje.CalcularSituacion(bePuntaje);

            Assert.AreEqual(Situacion.Asciende, bePuntaje.Situacion);
            Assert.AreEqual(2,bePuntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void AscensoPorPuntajeNivel4Test()
        {
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            BE.Puntaje bePuntaje = new BE.Puntaje();

            bePuntaje.IdNivel = 4;
            bePuntaje.PuntajePromedio = 7.25D;
            bePuntaje.CantidadPartidos = 10;

            bllPuntaje.CalcularSituacion(bePuntaje);

            Assert.AreEqual(Situacion.Asciende, bePuntaje.Situacion);
            Assert.AreEqual(3,bePuntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void AscensoPorPuntajeNivel5Test()
        {
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            BE.Puntaje bePuntaje = new BE.Puntaje();

            bePuntaje.IdNivel = 5;
            bePuntaje.PuntajePromedio = 9.25D;
            bePuntaje.CantidadPartidos = 10;

            bllPuntaje.CalcularSituacion(bePuntaje);

            Assert.AreEqual(Situacion.Asciende, bePuntaje.Situacion);
            Assert.AreEqual(4,bePuntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void MantieneNivel1Test()
        {
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            BE.Puntaje bePuntaje = new BE.Puntaje();

            bePuntaje.IdNivel = 1;
            bePuntaje.PuntajePromedio = 10D;
            bePuntaje.CantidadPartidos = 10;

            bllPuntaje.CalcularSituacion(bePuntaje);

            Assert.AreEqual(Situacion.Mantiene, bePuntaje.Situacion);
            Assert.AreEqual(-1,bePuntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void MantieneNivel2Test()
        {
            BLL.Puntaje bllPuntaje = new BLL.Puntaje();
            BE.Puntaje bePuntaje = new BE.Puntaje();

            bePuntaje.IdNivel = 2;
            //bePuntaje.PuntajePromedio = 1D;
            bePuntaje.PuntajePromedio = 8.25D;
            bePuntaje.CantidadPartidos = 10;

            bllPuntaje.CalcularSituacion(bePuntaje);

            Assert.AreEqual(Situacion.Mantiene, bePuntaje.Situacion);

        }
    }
}
