using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_Examen.Model
{
    public class AreaModel : ResponseModel
    {
        public int idArea { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}