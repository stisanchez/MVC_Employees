using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilities;

namespace API_Examen.Controllers
{
    public class AreaController : ApiController
    {

        [HttpPost]
        [ActionName("AddArea")]
        public Area AddArea(Area pArea)
        {
            return new DBConnector().AddEmployee(pArea);
        }

        [HttpDelete]
        [ActionName("DeleteArea")]
        public Area DeleteArea(Area pArea)
        {
            return new DBConnector().DeleteAreas(pArea);
        }

        [HttpPut]
        [ActionName("EditArea")]
        public Area EditArea(Area pArea)
        {
            return new DBConnector().EditAreas(pArea);
        }

        [HttpGet]
        [ActionName("GetAreas")]
        public IEnumerable<Area> GetAreas()
        {
            return new DBConnector().GetAreas();
        }
    }
}
