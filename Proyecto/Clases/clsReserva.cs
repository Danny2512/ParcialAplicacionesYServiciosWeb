using System;
using System.Collections.Generic;
using libComunes.CapaDatos;
using Proyecto.Models;

namespace Proyecto.Clases
{

    public class clsReserva
    {
        public Reserva reserva { get; set; }

        public string Insertar()
        {
            //Invocar el método insertar
            //Método para grabar en la base de datos
            string SQL = "Insertar_Reserva"; //Nombre del procedimiento almacenado

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;//Para indicar que es un procedimiento almacenado
            oConexion.AgregarParametro("@Nombre", reserva.NombrePersona);
            oConexion.AgregarParametro("@Documento", reserva.DocumentoPersona);
            oConexion.AgregarParametro("@numeroNinos", reserva.NumeroNinos);
            oConexion.AgregarParametro("@numeroAdulto", reserva.NumAdultos);
            oConexion.AgregarParametro("@fechaIngreso", reserva.FechaIngreso);
            oConexion.AgregarParametro("@fechaSalida", reserva.FechaSalida);
            oConexion.AgregarParametro("@idPlanAlimentacion", reserva.PlanAlimentancion);
            oConexion.AgregarParametro("@idHabitacion", reserva.Habitacion);
            if (oConexion.EjecutarSentencia())
            {
                return "Se insertó el prestamo en la base de datos";
            }
            else
            {
                reserva.Error = oConexion.Error;
                return reserva.Error;
            }
        }
    }
}