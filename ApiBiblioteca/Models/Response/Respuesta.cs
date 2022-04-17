using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiBiblioteca.Models.Response
{
    public class Respuesta
    {
        public bool vBoolRespuesta { get; set; } 
        public string vStrMensaje { get; set; }
        public object vObjData { get; set; }

    }
}