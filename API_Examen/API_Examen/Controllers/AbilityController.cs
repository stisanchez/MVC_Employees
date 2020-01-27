using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilities;
using Utilities.DTO;

namespace API_Examen.Controllers
{
    public class AbilityController : ApiController
    {
        [HttpGet]
        [ActionName("GetAbilities")]
        public IEnumerable<abilities> GetAbilities()
        {
            return new DBConnector().GetAbilities();
        }

        [HttpPost]
        [ActionName("SetAbilities")]
        public abilities SetAbilities(abilities pAbility)
        {
            return new DBConnector().SetAbilities(pAbility);
        }
    }
}
