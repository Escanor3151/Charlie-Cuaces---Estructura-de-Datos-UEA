using System;
using System.Collections.Generic;

class Programa
{
    static void Main()
    {
        List<int> lista1 = new List<int>();
        List<int> lista2 = new List<int>();

        Console.Write("Ingrese la cantidad de elementos para la primera lista: ");
        int cantidad1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese los elementos para la primera lista:");
        for (int i = 0; i < cantidad1; i++)
        {
            Console.Write($"Elemento {i + 1}: ");
            int dato = int.Parse(Console.ReadLine());
            lista1.Insert(0, dato); // Insertar por el inicio
        }

        Console.Write("\nIngrese la cantidad de elementos para la segunda lista: ");
        int cantidad2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese los elementos para la segunda lista:");
        for (int i = 0; i < cantidad2; i++)
        {
            Console.Write($"Elemento {i + 1}: ");
            int dato = int.Parse(Console.ReadLine());
            lista2.Insert(0, dato); // Insertar por el inicio
        }

        // Comparación de tamaño y contenido
        if (lista1.Count == lista2.Count)
        {
            bool iguales = true;
            for (int i = 0; i < lista1.Count; i++)
            {
                if (lista1[i] != lista2[i])
                {
                    iguales = false;
                    break;
                }
            }

            if (iguales)
            {
                Console.WriteLine("\nLas listas son iguales en tamaño y contenido.");
            }
            else
            {
                Console.WriteLine("\nLas listas son iguales en tamaño pero no en contenido.");
            }
        }
        else
        {
            Console.WriteLine("\nLas listas no tienen el mismo tamaño ni contenido.");
        }
    }
}
