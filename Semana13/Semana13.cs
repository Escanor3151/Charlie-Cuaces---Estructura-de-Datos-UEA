using System;
using System.Collections.Generic;

namespace CatalogoRevistas
{
    class Program
    {
        // Catálogo de revistas como lista de strings
        static List<string> catalogo = new List<string>()
        {
            "National Geographic",
            "Time",
            "Forbes",
            "Scientific American",
            "Vogue",
            "The Economist",
            "Nature",
            "Reader's Digest",
            "Popular Science",
            "Harvard Business Review"
        };

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.WriteLine("\n--- Catálogo de Revistas ---");
                Console.WriteLine("1. Buscar un título");
                Console.WriteLine("2. Mostrar todas las revistas");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                // Validar entrada del usuario
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        BuscarRevista();
                        break;
                    case 2:
                        MostrarCatalogo();
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

            } while (opcion != 3);
        }

        // Método para mostrar todas las revistas
        static void MostrarCatalogo()
        {
            Console.WriteLine("\nRevistas en el catálogo:");
            foreach (var revista in catalogo)
            {
                Console.WriteLine("- " + revista);
            }
        }

        // Método que inicia la búsqueda de revista
        static void BuscarRevista()
        {
            Console.Write("\nIngrese el título de la revista a buscar: ");
            string titulo = Console.ReadLine();

            bool encontrado = BuscarRecursivo(catalogo, titulo, 0);

            if (encontrado)
                Console.WriteLine("Resultado: Encontrado");
            else
                Console.WriteLine("Resultado: No encontrado");
        }

        // Búsqueda recursiva en la lista de revistas
        static bool BuscarRecursivo(List<string> lista, string titulo, int indice)
        {
            // Caso base: si llegamos al final de la lista, no se encontró
            if (indice >= lista.Count)
                return false;

            // Comparar título actual con el título buscado
            if (string.Equals(lista[indice], titulo, StringComparison.OrdinalIgnoreCase))
                return true;

            // Llamada recursiva al siguiente índice
            return BuscarRecursivo(lista, titulo, indice + 1);
        }
    }
}