using APP_Examen.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APP_Examen.Models
{
    public class EmployeeModel
    {
        public int idEmpleado { get; set; }
        public string nombreCompleto { get; set; }
        public string cedula { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string correo { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime fechaNacimiento { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime fechaIngreso { get; set; }
        public int idJefe { get; set; }
        public string nombreJefe { get; set; }
        public int idArea { get; set; }
        public string nombreArea { get; set; }
        public byte[] foto { get; set; }
        public List<AreaModel> listaAreas { get; set; }
        public List<EmployeeModel> listaEmpleados { get; set; }
    }
}