using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : IFormaGeometrica
    {
        private readonly decimal _lado1;
        private readonly decimal _lado2;
        public Rectangulo(decimal lado1, decimal lado2) 
        {
            _lado1 = lado1;
            _lado2 = lado2;
        }

        public decimal CalcularArea()
        {
            return _lado1 * _lado2;
        }

        public decimal CalcularPerimetro()
        {
            return (2 * _lado1) + (2 * _lado2);
        }

        public string ObtenerForma(int cantidad)
        {
            return cantidad == 1 ? "Rectángulo" : "Rectángulos";
        }
    }
}
