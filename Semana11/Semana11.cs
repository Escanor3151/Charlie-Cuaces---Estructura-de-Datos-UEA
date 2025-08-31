using System;
using System.Collections.Generic;

class Traductor
{
    // Diccionario base Español -> Inglés
    static Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        {"tiempo", "time"},
        {"persona", "person"},
        {"año", "year"},
        {"camino", "way"},
        {"forma", "way"},
        {"día", "day"},
        {"cosa", "thing"},
        {"hombre", "man"},
        {"mundo", "world"},
        {"vida", "life"},
        {"mano", "hand"},
        {"parte", "part"},
        {"niño", "child"},
        {"niña", "child"},
        {"ojo", "eye"},
        {"mujer", "woman"},
        {"lugar", "place"},
        {"trabajo", "work"},
        {"semana", "week"},
        {"caso", "case"},
        {"punto", "point"},
        {"tema", "point"},
        {"gobierno", "government"},
        {"empresa", "company"},
        {"compañía", "company"}
    };

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("MENÚ");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese un número válido.\n");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;
                case 2:
                    AgregarPalabra();
                    break;
                case 0:
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.\n");
                    break;
            }
        } while (opcion != 0);
    }

    static void TraducirFrase()
    {
        Console.Write("Ingrese la frase en español: ");
        string frase = Console.ReadLine();

        string[] palabras = frase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<string> traduccion = new List<string>();

        foreach (var palabra in palabras)
        {
            // Limpio puntuación para que no afecte la traducción
            string limpio = palabra.Trim(',', '.', ';', '!', '?');
            string puntuacion = palabra.Length > limpio.Length ? palabra.Substring(limpio.Length) : "";

            if (diccionario.ContainsKey(limpio.ToLower()))
                traduccion.Add(diccionario[limpio.ToLower()] + puntuacion);
            else
                traduccion.Add(palabra); // deja igual si no existe
        }

        Console.WriteLine("Traducción: " + string.Join(" ", traduccion) + "\n");
    }

    static void AgregarPalabra()
    {
        Console.Write("Ingrese la palabra en español: ");
        string esp = Console.ReadLine().Trim().ToLower();

        Console.Write("Ingrese su traducción al inglés: ");
        string eng = Console.ReadLine().Trim().ToLower();

        if (!diccionario.ContainsKey(esp))
        {
            diccionario.Add(esp, eng);
            Console.WriteLine($"✅ Palabra '{esp}' agregada con traducción '{eng}'.\n");
        }
        else
        {
            Console.WriteLine("⚠️ Esa palabra ya existe en el diccionario.\n");
        }
    }
}