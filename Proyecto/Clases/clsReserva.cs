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
                return "Se insertó la reserva en la base de datos";
            }
            else
            {
                reserva.Error = oConexion.Error;
                return reserva.Error;
            }
        }
        public string Actualizar()
        {
            string SQL = "Actualizar_Reserva";
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@IdReserva", reserva.IdReserva);
            oConexion.AgregarParametro("@numeroAdulto", reserva.NumAdultos);
            oConexion.AgregarParametro("@numeroNinos", reserva.NumeroNinos);
            oConexion.AgregarParametro("@fechaIngreso", reserva.FechaIngreso);
            oConexion.AgregarParametro("@fechaSalida", reserva.FechaSalida);
            oConexion.AgregarParametro("@idPlanAlimentacion", reserva.PlanAlimentancion);
            oConexion.AgregarParametro("@idHabitacion", reserva.Habitacion);
            if (oConexion.EjecutarSentencia())
            {
                return "Se actualizó la reserva en la base de datos";
            }
            else
            {
                reserva.Error = oConexion.Error;
                return reserva.Error;
            }
        }
        public string Eliminar()
        {
            string SQL = "Eliminar_Reserva"; 
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@IdReserva", reserva.IdReserva);
            if (oConexion.EjecutarSentencia())
            {
                return "Se elimnó la reserva en la base de datos";
            }
            else
            {
                reserva.Error = oConexion.Error;
                return reserva.Error;
            }
        }
        public string CheckIn()
        {
            string SQL = "CheckIn_Reserva";
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@IdReserva", reserva.IdReserva);
            if (oConexion.EjecutarSentencia())
            {
                return "La reserva #"+reserva.IdReserva+" fue confirmada con éxito.";
            }
            else
            {
                reserva.Error = oConexion.Error;
                return reserva.Error;
            }
        }
        public bool Consultar()
        {
            string SQL = "Consultar_Reserva";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;//Para indicar que es un procedimiento almacenado
            oConexion.AgregarParametro("@IdReserva", reserva.IdReserva);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    //Primero hay que poner a leer el reader
                    oConexion.Reader.Read();
                    //Hay información y se captura
                    reserva.NombrePersona = oConexion.Reader.GetString(0);
                    reserva.DocumentoPersona = oConexion.Reader.GetString(1);
                    return true;
                }
                else
                {
                    //No hay datos, se levanta un error
                    reserva.Error = "No hay datos para la reserva con código: " + reserva.IdReserva;
                    return false;
                }
            }
            else
            {
                reserva.Error = oConexion.Error;
                return false;
            }
        }
        public string RegistrarHuesped()
        {
            string SQL = "Insertar_Huesped";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@IdReserva", reserva.IdReserva);
            oConexion.AgregarParametro("@IdTipoPersona", reserva.TipoPersona);
            oConexion.AgregarParametro("@IdSexo", reserva.Sexo);
            oConexion.AgregarParametro("@Nombre", reserva.NombreHuespede);
            if (oConexion.EjecutarSentencia())
            {
                return "Se insertó el huesped en la base de datos";
            }
            else
            {
                reserva.Error = oConexion.Error;
                return reserva.Error;
            }
        }
    }
}
