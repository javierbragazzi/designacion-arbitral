using System;
using DA.BE;
using DA.BLL;
using DA.SS;
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
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            PuntajeArbitro puntaje = new PuntajeArbitro();

            puntaje.Edad = 52;

            bllCalificacion.CalcularSituacion(puntaje);

            Assert.AreEqual(Situacion.Baja, puntaje.Situacion);

        }

        [TestMethod]
        public void BajaPorMinimoPartidosTest()
        {
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            PuntajeArbitro puntaje = new PuntajeArbitro();

            puntaje.CantidadPartidos = 2;

            bllCalificacion.CalcularSituacion(puntaje);

            Assert.AreEqual(Situacion.Desciende, puntaje.Situacion);

        }

        [TestMethod]
        public void DescensoPorPuntajeNivel1Test()
        {
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            PuntajeArbitro puntaje = new PuntajeArbitro();

            puntaje.IdNivel = 1;
            puntaje.PuntajePromedio = 7.25D;
            puntaje.CantidadPartidos = 10;

            bllCalificacion.CalcularSituacion(puntaje);

            Assert.AreEqual(Situacion.Desciende, puntaje.Situacion);
            Assert.AreEqual(2,puntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void DescensoPorPuntajeNivel2Test()
        {
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            PuntajeArbitro puntaje = new PuntajeArbitro();

            puntaje.IdNivel = 2;
            puntaje.PuntajePromedio = 6.25;
            puntaje.CantidadPartidos = 10;

            bllCalificacion.CalcularSituacion(puntaje);

            Assert.AreEqual(Situacion.Desciende, puntaje.Situacion);
            Assert.AreEqual(3,puntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void DescensoPorPuntajeNivel3Test()
        {
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            PuntajeArbitro puntaje = new PuntajeArbitro();

            puntaje.IdNivel = 3;
            puntaje.PuntajePromedio = 5.25D;
            puntaje.CantidadPartidos = 10;

            bllCalificacion.CalcularSituacion(puntaje);

            Assert.AreEqual(Situacion.Desciende, puntaje.Situacion);
            Assert.AreEqual(4,puntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void DescensoPorPuntajeNivel4Test()
        {
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            PuntajeArbitro puntaje = new PuntajeArbitro();

            puntaje.IdNivel = 4;
            puntaje.PuntajePromedio = 4.25D;
            puntaje.CantidadPartidos = 10;

            bllCalificacion.CalcularSituacion(puntaje);

            Assert.AreEqual(Situacion.Desciende, puntaje.Situacion);
            Assert.AreEqual(5,puntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void AscensoPorPuntajeNivel2Test()
        {
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            PuntajeArbitro puntaje = new PuntajeArbitro();

            puntaje.IdNivel = 2;
            puntaje.PuntajePromedio = 9.25D;
            puntaje.CantidadPartidos = 10;

            bllCalificacion.CalcularSituacion(puntaje);

            Assert.AreEqual(Situacion.Asciende, puntaje.Situacion);
            Assert.AreEqual(1,puntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void AscensoPorPuntajeNivel3Test()
        {
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            PuntajeArbitro puntaje = new PuntajeArbitro();

            puntaje.IdNivel = 3;
            puntaje.PuntajePromedio = 8.25D;
            puntaje.CantidadPartidos = 10;

            bllCalificacion.CalcularSituacion(puntaje);

            Assert.AreEqual(Situacion.Asciende, puntaje.Situacion);
            Assert.AreEqual(2,puntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void AscensoPorPuntajeNivel4Test()
        {
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            PuntajeArbitro puntaje = new PuntajeArbitro();

            puntaje.IdNivel = 4;
            puntaje.PuntajePromedio = 7.25D;
            puntaje.CantidadPartidos = 10;

            bllCalificacion.CalcularSituacion(puntaje);

            Assert.AreEqual(Situacion.Asciende, puntaje.Situacion);
            Assert.AreEqual(3,puntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void AscensoPorPuntajeNivel5Test()
        {
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            PuntajeArbitro puntaje = new PuntajeArbitro();

            puntaje.IdNivel = 5;
            puntaje.PuntajePromedio = 9.25D;
            puntaje.CantidadPartidos = 10;

            bllCalificacion.CalcularSituacion(puntaje);

            Assert.AreEqual(Situacion.Asciende, puntaje.Situacion);
            Assert.AreEqual(4,puntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void MantieneNivel1Test()
        {
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            PuntajeArbitro puntaje = new PuntajeArbitro();

            puntaje.IdNivel = 1;
            puntaje.PuntajePromedio = 10D;
            puntaje.CantidadPartidos = 10;

            bllCalificacion.CalcularSituacion(puntaje);

            Assert.AreEqual(Situacion.Mantiene, puntaje.Situacion);
            Assert.AreEqual(-1,puntaje.IdNivelNuevo);

        }

        [TestMethod]
        public void MantieneNivel2Test()
        {
            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
            PuntajeArbitro puntaje = new PuntajeArbitro();

            puntaje.IdNivel = 2;
            //puntaje.PuntajePromedio = 1D;
            puntaje.PuntajePromedio = 8.25D;
            puntaje.CantidadPartidos = 10;

            bllCalificacion.CalcularSituacion(puntaje);

            Assert.AreEqual(Situacion.Mantiene, puntaje.Situacion);

        }
    }
}
