using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Login
    {
        public string usuario { get; set; }
        public string contrasenia { get; set; }
        public string Validado { get; set; }
        public string Error { get; set; }
    }
}