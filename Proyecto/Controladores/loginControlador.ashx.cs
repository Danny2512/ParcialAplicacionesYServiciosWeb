using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;
using Proyecto.Models;
using Proyecto.Clases;

namespace Proyecto.Controladores
{
    public class loginControlador : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string DatosLogin;
                StreamReader reader = new StreamReader(context.Request.InputStream);
                DatosLogin = reader.ReadToEnd();


                Login login = JsonConvert.DeserializeObject<Login>(DatosLogin);

                context.Response.Write(Validar(login));
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }

        private string Validar(Login login)
        {
            clsLogin oLogin = new clsLogin();
            oLogin.login = login;
            return oLogin.Validar();
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