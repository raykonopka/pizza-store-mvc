using PizzaStoreAPI.Service.PizzaStoreDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PizzaStoreAPI.Service.Controllers
{
    public class SaucesController : ApiController
    {
        ApplicationLogic processedData = new ApplicationLogic();

        [HttpGet]
        public HttpResponseMessage GetAllSauces()
        {
            return Request.CreateResponse(HttpStatusCode.OK, processedData.GetSauceTypes(), "application/json");
        }
    }
}
