using Proyecto.Clases;
using Proyecto.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;

namespace Proyecto.Controladores
{
    public class ReservaControlador : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string DatosReserva;
                StreamReader reader = new StreamReader(context.Request.InputStream);
                DatosReserva = reader.ReadToEnd();


                Reserva reserva = JsonConvert.DeserializeObject<Reserva>(DatosReserva);

                context.Response.Write(ProcesarComando(reserva));
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        private string ProcesarComando(Reserva reserva)
        {
            clsReserva oReserva = new clsReserva();
            oReserva.reserva = reserva;
            switch (reserva.Comando.ToUpper())
            {
                case "RESERVAR":
                    return oReserva.Insertar();

                default:
                    return "No se ha definido el comando";
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}