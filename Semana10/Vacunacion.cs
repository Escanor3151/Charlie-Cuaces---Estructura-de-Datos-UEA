using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // 1. Crear 500 ciudadanos ficticios
        var ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        // Crear 75 ciudadanos vacunados con Pfizer
        var vacunadosPfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            vacunadosPfizer.Add($"Ciudadano {i}");
        }

        // Crear 75 ciudadanos vacunados con AstraZeneca
        var vacunadosAstraZeneca = new HashSet<string>();
        for (int i = 50; i < 125; i++) // algunos coinciden con Pfizer para simular doble dosis
        {
            vacunadosAstraZeneca.Add($"Ciudadano {i}");
        }

        // Operaciones de teoría de conjuntos
        // Ciudadanos con ambas dosis (intersección)
        var ambasDosis = new HashSet<string>(vacunadosPfizer);
        ambasDosis.IntersectWith(vacunadosAstraZeneca);

        // Solo Pfizer (diferencia)
        var soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstraZeneca);

        // Solo AstraZeneca (diferencia)
        var soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
        soloAstraZeneca.ExceptWith(vacunadosPfizer);

        // No vacunados (diferencia entre total y la unión de vacunados)
        var vacunados = new HashSet<string>(vacunadosPfizer);
        vacunados.UnionWith(vacunadosAstraZeneca);

        var noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunados);

        // Mostrar resultados
        Console.WriteLine("--| Ciudadanos NO vacunados |--");
        foreach (var c in noVacunados) Console.WriteLine(c);

        Console.WriteLine("\n--| Ciudadanos con ambas dosis |--");
        foreach (var c in ambasDosis) Console.WriteLine(c);

        Console.WriteLine("\n--| Ciudadanos con SOLO Pfizer |--");
        foreach (var c in soloPfizer) Console.WriteLine(c);

        Console.WriteLine("\n--| Ciudadanos con SOLO AstraZeneca |--");
        foreach (var c in soloAstraZeneca) Console.WriteLine(c);
    }
}