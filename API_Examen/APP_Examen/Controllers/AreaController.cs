using APP_Examen.Model;
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
    public class AreaController : Controller
    {
        // GET: Area
        public ActionResult Index()
        {
            var Areas = GetAreas(new AreaModel { idArea = 0 });
            return View(Areas);
        }

        // GET: Area/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new AreaModel());
        }

        [HttpPost]
        public ActionResult Create(AreaModel pArea)
        {
            AddArea(pArea);
            return RedirectToAction("Index");
        }

        // GET: Area/Edit/5
        public ActionResult Edit(int id)
        {
            AreaModel objArea = ((List<AreaModel>)Session["AREAS"]).Find(obj => obj.idArea == id);

            if (objArea == null)
            {
                return RedirectToAction("Index");
            }

            return View(objArea);
        }

        // POST: Area/Edit/5
        [HttpPost]
        public ActionResult Edit(AreaModel pArea)
        {
            EditArea(pArea);
            return RedirectToAction("Index");
        }

        // GET: Area/Delete/5
        public ActionResult Delete(int id)
        {
            AreaModel objArea = ((List<AreaModel>)Session["AREAS"]).Find(obj => obj.idArea == id);

            if (objArea == null)
            {
                return RedirectToAction("Index");
            }

            return View(objArea);
        }

        // POST: Area/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            DeleteArea(new AreaModel { idArea = id});
            return RedirectToAction("Index");
        }

        #region ConsumeAPI
        /// <summary>
        /// Create a new Area with parameters sent it
        /// </summary>
        /// <param name="pAreaModel"></param>
        /// <returns></returns>
        private AreaModel AddArea(AreaModel pArea)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["API_URL_ADD_AREAS"]);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = WebRequestMethods.Http.Post;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(pArea);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                pArea = JsonConvert.DeserializeObject<AreaModel>(result);
            }
            return pArea;
        }

        /// <summary>
        /// Delete Area sent through by parameter
        /// </summary>
        /// <param name="pAreaModel"></param>
        /// <returns></returns>
        private AreaModel DeleteArea(AreaModel pArea)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["API_URL_DELETE_AREAS"]);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(pArea);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                pArea = JsonConvert.DeserializeObject<AreaModel>(result);
            }
            return pArea;
        }


        /// <summary>
        /// Edit an Area with parameters sent it
        /// </summary>
        /// <param name="pAreaModel"></param>
        /// <returns></returns>
        private AreaModel EditArea(AreaModel pArea)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["API_URL_EDIT_AREAS"]);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = WebRequestMethods.Http.Put;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(pArea);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                pArea = JsonConvert.DeserializeObject<AreaModel>(result);
            }
            return pArea;
        }

        /// <summary>
        /// Get all areas or a specific area sent through parameter.
        /// </summary>
        /// <param name="pArea"></param>
        /// <returns></returns>
        private List<AreaModel> GetAreas(AreaModel pArea)
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
            Session["AREAS"] = resultList;
            return resultList;
        }
        #endregion
    }
}
