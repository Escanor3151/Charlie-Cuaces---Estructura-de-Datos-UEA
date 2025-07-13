using System;
using System.Collections.Generic;

class TorreHanoi
{
    // Se definen tres pilas que simulan las tres torres
    static Stack<int> origen = new Stack<int>();
    static Stack<int> auxiliar = new Stack<int>();
    static Stack<int> destino = new Stack<int>();

    // Método recursivo que realiza los movimientos de los discos
    static void MoverDiscos(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        if (n == 1)
        {
            // Caso base: mover un solo disco directamente de origen a destino
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
        }
        else
        {
            // Paso 1: mover n-1 discos de origen a auxiliar
            MoverDiscos(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

            // Paso 2: mover el disco restante al destino
            MoverDiscos(1, origen, destino, auxiliar, nombreOrigen, nombreDestino, nombreAuxiliar);

            // Paso 3: mover los n-1 discos desde auxiliar al destino
            MoverDiscos(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
        }
    }

    static void Main()
    {
        Console.Write("Ingrese el número de discos: ");
        int n = int.Parse(Console.ReadLine()); // Leer el número de discos

        // Llenamos la torre de origen con los discos (el disco más grande en la base)
        for (int i = n; i >= 1; i--)
            origen.Push(i);

        Console.WriteLine("\nPasos para resolver las Torres de Hanoi:");
        
        // Llamada al método que resuelve el problema recursivamente
        MoverDiscos(n, origen, destino, auxiliar, "Origen", "Destino", "Auxiliar");
    }
}