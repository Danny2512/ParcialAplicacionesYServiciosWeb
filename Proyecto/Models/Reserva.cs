using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Reserva
    {
        public string NombrePersona { get; set; }
        public string DocumentoPersona { get; set; }
        public int NumeroNinos { get; set; }
        public int NumAdultos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public int PlanAlimentancion { get; set; }
        public int Habitacion { get; set; }
        public float? ValorPagar { get; set; }
        public string Error { get; set; }
        public string Comando { get; set; }
    }
}