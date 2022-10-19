using System;

namespace Proyecto.Models
{
    public class Reserva
    {
        public int? IdReserva { get; set; }
        public string NombrePersona { get; set; }
        public string DocumentoPersona { get; set; }
        public string NombreHuespede { get; set; }
        public int? NumeroNinos { get; set; }
        public int? NumAdultos { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public int? PlanAlimentancion { get; set; }
        public int? Habitacion { get; set; }
        public int? TipoPersona { get; set; }
        public int? Sexo { get; set; }

        public float? ValorPagar { get; set; }
        public string Error { get; set; }
        public string Comando { get; set; }
    }
}