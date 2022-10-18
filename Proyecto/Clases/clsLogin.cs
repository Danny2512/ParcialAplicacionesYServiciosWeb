using libComunes.CapaDatos;
using Proyecto.Models;

namespace Proyecto.Clases
{
    public class clsLogin
    {
        public Login login { get; set; }
        public string Validar()
        {
            //Invocar el método insertar
            //Método para grabar en la base de datos
            string SQL = "Inicio_sesion"; //Nombre del procedimiento almacenado

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;//Para indicar que es un procedimiento almacenado
            oConexion.AgregarParametro("@prUsuario", login.usuario);
            oConexion.AgregarParametro("@prContrasenia", login.contrasenia);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    //Primero hay que poner a leer el reader
                    oConexion.Reader.Read();
                    //Hay información y se captura
                    login.Validado = oConexion.Reader.GetString(0);
                    if (login.Validado == "0")
                    {
                        login.Error = "Contraseña o correo inválidas";
                    }
                    else if (login.Validado == "1") 
                    {
                        return login.Validado = "1";
                    }
                }
                else
                {
                    return login.Error = "No hay datos para el producto con código: " + login.usuario;
                }
            }
            else
            {
                return login.Error = oConexion.Error;
            }
            return login.Error;
        }
    }
}