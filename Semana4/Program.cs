public record Paciente //Registro de Pacientes
{
    public int Id { get; init; }
    public string Nombres { get; init; }
    public string Apellidos { get; init; }
    public string Cedula { get; init; }
    public string Telefono { get; init; }
}
public struct Turno //Estructura de Turno
{
    public int Dia; // 0 = Lunes, 1 = Martes, ..., 6 = Domingo
    public int Hora; // 8 = 08:00, 9 = 09:00 ..., 17 = 17:00
    public string Motivo;
    public string Estado; // Pendiente, Confirmado, Cancelado
    public Paciente Paciente;
}
public class AgendaClinica // Agendamiento de cita
{
    private Turno[,] agenda = new Turno[7, 10]; // 7 días x 10 horas (8h a 17h)

    public void AgendarTurno(int dia, int hora, Paciente paciente, string motivo)
    {
        if (agenda[dia, hora - 8].Paciente != null)
        {
            Console.WriteLine("Turno ya asignado.");
            return;
        }

        agenda[dia, hora - 8] = new Turno
        {
            Dia = dia,
            Hora = hora,
            Motivo = motivo,
            Estado = "Pendiente",
            Paciente = paciente
        };

        Console.WriteLine("Turno asignado correctamente.");
    }

    public void MostrarAgendaDia(int dia) //Mostrar en Pantalla la agenda del dia
    {
        Console.WriteLine($"Agenda del día {(DayOfWeek)dia}:");
        for (int h = 0; h < 10; h++)
        {
            var turno = agenda[dia, h];
            if (turno.Paciente != null)
            {
                Console.WriteLine($"{h + 8}:00 - {turno.Paciente.Nombres} {turno.Paciente.Apellidos} ({turno.Motivo}) [{turno.Estado}]");
            }
            else
            {
                Console.WriteLine($"{h + 8}:00 - Disponible");
            }
        }
    }
}
class Program
{
    static void Main()
    {
        AgendaClinica agenda = new AgendaClinica();

        Paciente p1 = new Paciente
        {
            Id = 1,
            Nombres = "Charlie",
            Apellidos = "Cuaces",
            Cedula = "1725161150",
            Telefono = "0987868559"
        };
        Paciente p2 = new Paciente
        {
            Id = 2,
            Nombres = "Alberto",
            Apellidos = "Loarte",
            Cedula = "1725161120",
            Telefono = "0987868549"
        };

        agenda.AgendarTurno(1, 11, p1, "Fisioterapia"); // Lunes a las 11:00
        agenda.AgendarTurno(2, 8, p2, "Medica general"); // Martes a las 8:00

        agenda.MostrarAgendaDia(1); // Mostrar agenda del Lunes
        agenda.MostrarAgendaDia(2); // Mostrar agenda del martes
    }
}
