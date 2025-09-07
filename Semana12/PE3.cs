using System;
using System.Collections.Generic;

class Biblioteca
{
    // Diccionario: Categoría → Conjunto de libros
    static Dictionary<string, HashSet<string>> biblioteca = new Dictionary<string, HashSet<string>>();

    // Registrar una nueva categoría
    static void RegistrarCategoria(string categoria)
    {
        if (!biblioteca.ContainsKey(categoria))
        {
            biblioteca[categoria] = new HashSet<string>();
            Console.WriteLine($"Categoría '{categoria}' registrada.");
        }
        else
        {
            Console.WriteLine("La categoría ya existe.");
        }
    }

    // Registrar un libro en una categoría
    static void RegistrarLibro(string categoria, string titulo)
    {
        if (biblioteca.ContainsKey(categoria))
        {
            biblioteca[categoria].Add(titulo);
            Console.WriteLine($"Libro '{titulo}' agregado a la categoría '{categoria}'.");
        }
        else
        {
            Console.WriteLine("La categoría no existe.");
        }
    }

    // Mostrar todos los libros por categoría
    static void MostrarLibros()
    {
        foreach (var cat in biblioteca)
        {
            Console.WriteLine($"\nCategoría: {cat.Key}");
            Console.WriteLine("Libros: " + string.Join(", ", cat.Value));
        }
    }

    // Reporte: todos los libros de la biblioteca (unión de conjuntos)
    static HashSet<string> TodosLosLibros()
    {
        HashSet<string> total = new HashSet<string>();
        foreach (var libros in biblioteca.Values)
        {
            total.UnionWith(libros);
        }
        return total;
    }

    // Consulta: buscar un libro en toda la biblioteca
    static void BuscarLibro(string titulo)
    {
        foreach (var cat in biblioteca)
        {
            if (cat.Value.Contains(titulo))
            {
                Console.WriteLine($"El libro '{titulo}' está en la categoría '{cat.Key}'.");
                return;
            }
        }
        Console.WriteLine($" El libro '{titulo}' no se encuentra en la biblioteca.");
    }

    static void Main(string[] args)
    {
        // Ejemplo de uso
        RegistrarCategoria("Ciencia Ficción");
        RegistrarCategoria("Historia");

        RegistrarLibro("Ciencia Ficción", "Dune");
        RegistrarLibro("Ciencia Ficción", "Neuromante");
        RegistrarLibro("Historia", "Sapiens");
        RegistrarLibro("Historia", "El Imperio Romano");

        MostrarLibros();

        Console.WriteLine("\nTodos los libros en la biblioteca:");
        Console.WriteLine(string.Join(", ", TodosLosLibros()));

        Console.WriteLine("\nBuscando un libro:");
        BuscarLibro("Dune");
        BuscarLibro("Harry Potter");

        Console.ReadKey();
    }
}
