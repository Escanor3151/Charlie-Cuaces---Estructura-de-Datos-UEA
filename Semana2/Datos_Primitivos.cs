using System;

namespace FigurasGeometricas
{
    // Clase Círculo
    public class Circulo
    {
        private double radio;

        public Circulo(double radio)
        {
            this.radio = radio;
        }
        // Calculo de Area
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }
        // Calculo de Perimetro
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }
    // Clase Rectángulo
    public class Rectangulo
    {
        private double largo;
        private double ancho;

        public Rectangulo(double largo, double ancho)
        {
            this.largo = largo;
            this.ancho = ancho;
        }
        // Calculo de Area
        public double CalcularArea()
        {
            return largo * ancho;
        }
        // Calculo de Perimeto
        public double CalcularPerimetro()
        {
            return 2 * (largo + ancho);
        }
    }
    //Programa para probrar clases
    class Program
    {
        static void Main(string[] args)
        {
            Circulo miCirculo = new Circulo(9.6);
            Console.WriteLine("Círculo:");
            Console.WriteLine($"Área: {miCirculo.CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {miCirculo.CalcularPerimetro():F2}");

            Rectangulo miRectangulo = new Rectangulo(5, 2.6);
            Console.WriteLine("\nRectángulo:");
            Console.WriteLine($"Área: {miRectangulo.CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {miRectangulo.CalcularPerimetro():F2}");
        }
    }
}