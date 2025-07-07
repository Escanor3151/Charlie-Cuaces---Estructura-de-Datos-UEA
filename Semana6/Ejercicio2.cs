using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> lista = new LinkedList<int>();
        Random rnd = new Random();

        // Generar 50 números aleatorios entre 1 y 999 y agregarlos a la lista
        for (int i = 0; i < 50; i++)
        {
            int num = rnd.Next(1, 1000); // 1 a 999 inclusive
            lista.AddLast(num);
        }

        // Mostrar lista inicial
        Console.WriteLine("Lista inicial de 50 números aleatorios:");
        foreach (int num in lista)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        // Leer rango desde teclado
        Console.WriteLine("\nIngrese el rango para conservar los números (mínimo y máximo):");

        int minimo, maximo;

        while (true)
        {
            Console.Write("Mínimo: ");
            if (int.TryParse(Console.ReadLine(), out minimo)) break;
            Console.WriteLine("Entrada inválida. Intente nuevamente.");
        }

        while (true)
        {
            Console.Write("Máximo: ");
            if (int.TryParse(Console.ReadLine(), out maximo) && maximo >= minimo) break;
            Console.WriteLine("Entrada inválida o máximo menor que mínimo. Intente nuevamente.");
        }

        // Eliminar nodos fuera del rango
        var nodo = lista.First;
        while (nodo != null)
        {
            var siguiente = nodo.Next; // Guardar siguiente porque podríamos eliminar el actual
            if (nodo.Value < minimo || nodo.Value > maximo)
            {
                lista.Remove(nodo);
            }
            nodo = siguiente;
        }

        // Mostrar lista después de la eliminación
        Console.WriteLine($"\nLista después de eliminar números fuera del rango [{minimo}, {maximo}]:");
        if (lista.Count == 0)
        {
            Console.WriteLine("No quedan números dentro del rango.");
        }
        else
        {
            foreach (int num in lista)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
