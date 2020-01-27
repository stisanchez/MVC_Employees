using APP_Examen.Model;
using APP_Examen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace APP_Examen.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Area
        public ActionResult Index()
        {
            var Employees= GetEmployees(new EmployeeModel());
            return View(Employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            EmployeeModel employee = ((List<EmployeeModel>)Session["EMPLOYEES"]).Find(obj => obj.idEmpleado == id);

            if (employee == null)
            {
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            EmployeeModel employee = new EmployeeModel();
            employee.listaAreas = GetAreas();
            employee.listaEmpleados = GetEmployees(new EmployeeModel());
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel pEmployee, HttpPostedFileBase image1)
        {
            if(image1 != null)
            {
                pEmployee.foto = new byte[image1.ContentLength];
                image1.InputStream.Read(pEmployee.foto, 0, image1.ContentLength);
            }
            AddEmployee(pEmployee);
            return RedirectToAction("Index");
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeModel employee = ((List<EmployeeModel>)Session["EMPLOYEES"]).Find(obj => obj.idEmpleado == id);
            employee.listaAreas = GetAreas();
            employee.listaEmpleados = GetEmployees(new EmployeeModel());

            if (employee == null)
            {
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeModel pEmployee, HttpPostedFileBase image1)
        {
            if (image1 != null)
            {
                pEmployee.foto = new byte[image1.ContentLength];
                image1.InputStream.Read(pEmployee.foto, 0, image1.ContentLength);
            }
            EditEmployee(pEmployee);
            return RedirectToAction("Index");
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeModel objEmployee = ((List<EmployeeModel>)Session["EMPLOYEES"]).Find(obj => obj.idEmpleado == id);

            if (objEmployee == null)
            {
                return RedirectToAction("Index");
            }

            return View(objEmployee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            DeleteEmployee(new EmployeeModel { idEmpleado = id });
            return RedirectToAction("Index");
        }

        #region ConsumeAPI

        /// <summary>
        /// Add new employee
        /// </summary>
        /// <param name="pEmployee"></param>
        /// <returns></returns>
        private EmployeeModel AddEmployee(EmployeeModel pEmployee)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["API_URL_ADD_EMPLOYEE"]);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = WebRequestMethods.Http.Post;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(pEmployee);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                pEmployee = JsonConvert.DeserializeObject<EmployeeModel>(result);
            }
            return pEmployee;
        }

        private EmployeeModel EditEmployee(EmployeeModel pEmployee)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["API_URL_EDIT_EMPLOYEE"]);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = WebRequestMethods.Http.Put;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(pEmployee);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                pEmployee = JsonConvert.DeserializeObject<EmployeeModel>(result);
            }
            return pEmployee;
        }

        private EmployeeModel DeleteEmployee(EmployeeModel pEmployee)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["API_URL_DELETE_EMPLOYEE"]);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(pEmployee);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                pEmployee = JsonConvert.DeserializeObject<EmployeeModel>(result);
            }
            return pEmployee;
        }

        private List<EmployeeModel> GetEmployees(EmployeeModel employeeModel)
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
            Session["EMPLOYEES"] = resultList;
            return resultList;
        }

        /// <summary>
        /// Get all areas.
        /// </summary>
        /// <returns></returns>
        private List<AreaModel> GetAreas()
        {
            var resultList = new List<AreaModel>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["API_URL_GET_AREAS"]);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = WebRequestMethods.Http.Get;

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                resultList = JsonConvert.DeserializeObject<List<AreaModel>>(result);
            }
            return resultList;
        }
        #endregion
    }
}
