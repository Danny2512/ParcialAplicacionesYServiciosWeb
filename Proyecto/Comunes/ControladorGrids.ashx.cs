using System;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using libComunes.CapaObjetos;

namespace pAplicacionesWEB.Comunes
{
    public class ControladorGrids : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String DatosGrid;

            StreamReader reader = new StreamReader(context.Request.InputStream);
            DatosGrid = reader.ReadToEnd();

            viewGrid oGrid = JsonConvert.DeserializeObject<viewGrid>(DatosGrid);

            string Respuesta;

            switch (oGrid.Comando.ToUpper())
            {
                case "TABLAGUEST":
                    Respuesta = LlenarGrid(oGrid, "Huespedes_Grid",);
                    break;
                default:
                    Respuesta = "Sin definir";
                    break;
            }
            context.Response.ContentType = "application/json";

            context.Response.Write(Respuesta);
            //JsonConvert.SerializeObject(Cliente);
        }
        private string LlenarGrid(viewGrid oGrid, string SQL)
        {
            oGrid.SQL = SQL;
            clsGridListas oGridListas = new clsGridListas();
            oGridListas.oGrid = oGrid;
            return JsonConvert.SerializeObject(oGridListas.ListarGrid());
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