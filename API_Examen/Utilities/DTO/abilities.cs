using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.DTO
{
    public class abilities : Response
    {
        public int idHabilidad { get; set; }
        public int idEmpleado { get; set; }
        public string Nombre { get; set; }
        public int insertAbility { get; set; }

    }
}
