using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ReporterFormaGeometrica.Imprimir(new List<IFormaGeometrica>()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ReporterFormaGeometrica.Imprimir(new List<IFormaGeometrica>(), IdiomasEnum.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                ReporterFormaGeometrica.Imprimir(new List<IFormaGeometrica>(), IdiomasEnum.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> { new Cuadrado(5) };

            var resumen = ReporterFormaGeometrica.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Área 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = ReporterFormaGeometrica.Imprimir(cuadrados, IdiomasEnum.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = ReporterFormaGeometrica.Imprimir(formas, IdiomasEnum.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = ReporterFormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28 <br/>2 Círculos | Área 13,01 | Perímetro 18,06 <br/>3 Triángulos | Área 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 97,66 Área 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConRectangulo() 
        {
            var resumen = ReporterFormaGeometrica.Imprimir(new List<IFormaGeometrica> { new Rectangulo(2, 5) });
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Rectángulo | Área 10 | Perímetro 14 <br/>TOTAL:<br/>1 formas Perímetro 14 Área 10", resumen);
        }

        [TestCase]
        public void TestResumenListaConRectangulos()
        {
            var resumen = ReporterFormaGeometrica.Imprimir(new List<IFormaGeometrica> { new Rectangulo(2, 5), new Rectangulo(1, 3), new Rectangulo(5, 6) });
            Assert.AreEqual("<h1>Reporte de Formas</h1>3 Rectángulos | Área 43 | Perímetro 44 <br/>TOTAL:<br/>3 formas Perímetro 44 Área 43", resumen);
        }

        [TestCase]
        public void TestResumenListaConRectangulosEnIngles()
        {
            var resumen = ReporterFormaGeometrica.Imprimir(new List<IFormaGeometrica> { new Rectangulo(2, 5), new Rectangulo(1, 3), new Rectangulo(5, 6) }, IdiomasEnum.Ingles);
            Assert.AreEqual("<h1>Shapes report</h1>3 Rectangles | Area 43 | Perimeter 44 <br/>TOTAL:<br/>3 shapes Perimeter 44 Area 43", resumen);
        }

        [TestCase]
        public void TestResumenListaConRectangulosEnItaliano()
        {
            var resumen = ReporterFormaGeometrica.Imprimir(new List<IFormaGeometrica> { new Rectangulo(2, 5), new Rectangulo(1, 3), new Rectangulo(5, 6) }, IdiomasEnum.Italiano);
            Assert.AreEqual("<h1>Rapporto di forme</h1>3 Rettangoli | Area 43 | Perimetro 44 <br/>TOTAL:<br/>3 forme Perimetro 44 Area 43", resumen);
        }
    }
}
