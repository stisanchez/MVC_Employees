using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.DTO
{
    public class Employee : Response
    {
        public int idEmpleado { get; set; }
        public string nombreCompleto { get; set; }
        public string cedula { get; set; }
        public string correo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime fechaIngreso { get; set; }
        public int idJefe { get; set; }
        public string nombreJefe { get; set; }
        public int idArea { get; set; }
        public string nombreArea { get; set; }
        public byte [] foto { get; set; }
    }
}
