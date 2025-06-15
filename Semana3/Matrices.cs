using System;

namespace RegistroEstudianteApp
{
    public class Estudiante
    {
        // Atributos del estudiante
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; } // Arreglo para almacenar los 3 teléfonos

        // Constructor
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;

            if (telefonos.Length == 3)
                Telefonos = telefonos;
            else
                throw new ArgumentException("Debe ingresar exactamente 3 números de teléfono.");
        }

        // Método para mostrar los datos del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Arreglo con 3 teléfonos
            string[] telefonos = { "0987868559", "0978554712", "0996668735" };

            // Crear una instancia de Estudiante
            Estudiante estudiante = new Estudiante(
                id: 5,
                nombres: "Charlie",
                apellidos: "Cuaces",
                direccion: "Quito, Cumbaya, Barrio Santa Ines",
                telefonos: telefonos
            );

            // Mostrar la información del estudiante
            estudiante.MostrarInformacion();

            Console.ReadLine();
        }
    }

}
