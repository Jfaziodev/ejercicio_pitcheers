using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class ReporterFormaGeometrica
    {
        public ReporterFormaGeometrica() { }

        public static string Imprimir(IList<IFormaGeometrica> formas, IdiomasEnum idioma = IdiomasEnum.Castellano)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
                sb.Append(traducirLinea("<h1>Lista vacía de formas!</h1>", idioma));
            else
            {
                sb.Append(traducirLinea("<h1>Reporte de Formas</h1>", idioma));
                sb.Append(traducirLinea(ObtenerLinea(formas), idioma));

                //FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(traducirLinea($"{formas.Count} formas ", idioma));
                sb.Append(traducirLinea($"Perímetro {formas.Sum(f => f.CalcularPerimetro()):#.##} ", idioma));
                sb.Append(traducirLinea($"Área {formas.Sum(f => f.CalcularArea()):#.##}", idioma));
            }

            return sb.ToString();
        }
		
		public static string ObtenerLinea(IList<IFormaGeometrica> formas) 
		{
            var cuadrados = formas.Where(f => f is Cuadrado);
            var circulos = formas.Where(f => f is Circulo);
            var triangulos = formas.Where(f => f is TrianguloEquilatero);
            var rectangulos = formas.Where(f => f is Rectangulo);

            var linea = string.Empty;

            if (cuadrados.Any())
                linea += $"{cuadrados.Count()} {cuadrados.First().ObtenerForma(cuadrados.Count())} | Área {cuadrados.Sum(c => c.CalcularArea()):#.##} | Perímetro {cuadrados.Sum(c => c.CalcularPerimetro()):#.##} <br/>";

            if (circulos.Any())
                linea += $"{circulos.Count()} {circulos.First().ObtenerForma(circulos.Count())} | Área {circulos.Sum(c => c.CalcularArea()):#.##} | Perímetro {circulos.Sum(c => c.CalcularPerimetro()):#.##} <br/>";

            if (triangulos.Any())
                linea += $"{triangulos.Count()} {triangulos.First().ObtenerForma(triangulos.Count())} | Área {triangulos.Sum(c => c.CalcularArea()):#.##} | Perímetro {triangulos.Sum(c => c.CalcularPerimetro()):#.##} <br/>";

            if (rectangulos.Any())
                linea += $"{rectangulos.Count()} {rectangulos.First().ObtenerForma(rectangulos.Count())} | Área {rectangulos.Sum(c => c.CalcularArea()):#.##} | Perímetro {rectangulos.Sum(c => c.CalcularPerimetro()):#.##} <br/>";

            return linea;
		}

        static string traducirLinea(string linea, IdiomasEnum idioma =  IdiomasEnum.Castellano) 
        {
            if (idioma == IdiomasEnum.Ingles)
                return linea.Replace("Lista vacía de formas!", "Empty list of shapes!").Replace("Cuadrado", "Square")
                .Replace("Cuadrados", "Squares").Replace("Círculo", "Circle").Replace("Círculos", "Circles").Replace("Triángulo", "Triangle").Replace("Triángulos", "Triangles")
                .Replace("Rectángulos", "Rectangles").Replace("Rectángulo", "Rectangle")
                .Replace("Área", "Area").Replace("Perímetro", "Perimeter").Replace("formas", "shapes").Replace("Reporte de Formas", "Shapes report");
            if (idioma == IdiomasEnum.Italiano)
                return linea.Replace("Lista vacía de formas!", "Elenco vuoto di forme!").Replace("Cuadrado", "Quadrato")
                .Replace("Cuadrados", "Quadrati").Replace("Círculo", "Cerchio").Replace("Círculos", "Cerchi").Replace("Triángulo", "Triangolo").Replace("Triángulos", "Triangoli")
                .Replace("Rectángulos", "Rettangoli").Replace("Rectángulo", "Rettangolo")
                .Replace("Área", "Area").Replace("Perímetro", "Perimetro").Replace("formas", "forme").Replace("Reporte de Formas", "Rapporto di forme");
            else
                return linea;
        }
    }
}
