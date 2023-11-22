using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : IFormaGeometrica
    {
        private readonly decimal _radio;
        public Circulo(decimal radio) 
        {
            _radio = radio;
        }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (_radio / 2) * (_radio / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _radio;
        }

        public string ObtenerForma(int cantidad)
        {
            return cantidad == 1 ? "Círculo" : "Círculos";
        }
    }
}
