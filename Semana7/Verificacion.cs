using System;
using System.Collections.Generic;

class VerificadorBalanceo
{
    // Método para verificar si la expresión tiene símbolos balanceados
    public static bool EstaBalanceado(string expresion)
    {
        Stack<char> pila = new Stack<char>(); // Pila para almacenar los símbolos de apertura

        foreach (char c in expresion)
        {
            // Si es un símbolo de apertura, lo apilamos
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            // Si es un símbolo de cierre, comprobamos si hay coincidencia
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si la pila está vacía, hay un símbolo de cierre sin apertura previa
                if (pila.Count == 0)
                    return false;

                char tope = pila.Pop(); // Extraemos el símbolo de apertura más reciente

                // Verificamos si el símbolo coincide con su par correspondiente
                if ((c == ')' && tope != '(') ||
                    (c == '}' && tope != '{') ||
                    (c == ']' && tope != '['))
                {
                    return false;
                }
            }
        }

        // Si la pila está vacía al final, todos los símbolos están balanceados
        return pila.Count == 0;
    }

    static void Main()
    {
        Console.Write("Ingrese una expresión: ");
        string expresion = Console.ReadLine(); // Lectura de la expresión por teclado

        // Verificamos si está balanceada e imprimimos el resultado
        if (EstaBalanceado(expresion))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula NO balanceada.");
    }
}