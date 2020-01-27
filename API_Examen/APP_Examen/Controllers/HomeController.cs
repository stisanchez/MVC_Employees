using APP_Examen.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace APP_Examen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<EmployeeModel> empleados = GetEmployees();
            List<TreeViewNode> nodes = new List<TreeViewNode>();
            //Load the fathers nodes
            foreach (var employee in empleados.Where(obj => obj.idJefe.Equals(0)))
            {
                nodes.Add(new TreeViewNode { id = employee.idEmpleado.ToString(), parent = "#", text = employee.nombreCompleto });
            }

            ////Load the sons
            foreach (var employee in empleados.Where(obj => !obj.idJefe.Equals(0)))
            {
                nodes.Add(new TreeViewNode { id = employee.idEmpleado.ToString(), parent = employee.idJefe.ToString(), text = employee.nombreCompleto });
            }

            ViewBag.Json = JsonConvert.SerializeObject(nodes);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private List<EmployeeModel> GetEmployees()
        {
            var resultList = new List<EmployeeModel>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["API_URL_GET_EMPLOYEES"]);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = WebRequestMethods.Http.Get;

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                resultList = JsonConvert.DeserializeObject<List<EmployeeModel>>(result);
            }
            return resultList;
        }

    }
}