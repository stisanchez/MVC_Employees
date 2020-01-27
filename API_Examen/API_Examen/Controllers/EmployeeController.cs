using DataAccess;
using System.Collections.Generic;
using System.Web.Http;
using Utilities.DTO;

namespace API_Examen.Controllers
{
    public class EmployeeController : ApiController
    {

        [HttpPost]
        [ActionName("AddEmployee")]
        public Employee AddEmployee(Employee pEmployee)
        {
            return new DBConnector().AddEmployee(pEmployee);
        }

        [HttpDelete]
        [ActionName("DeleteEmployee")]
        public Employee DeleteEmployee(Employee pEmployee)
        {
            return new DBConnector().DeleteAreas(pEmployee);
        }

        [HttpPut]
        [ActionName("EditEmployee")]
        public Employee EditEmployee(Employee pEmployee)
        {
            return new DBConnector().EditAreas(pEmployee);
        }

        [HttpGet]
        [ActionName("GetEmployees")]
        public IEnumerable<Employee> GetEmployees()
        {
            return new DBConnector().GetEmployees();
        }
    }
}
