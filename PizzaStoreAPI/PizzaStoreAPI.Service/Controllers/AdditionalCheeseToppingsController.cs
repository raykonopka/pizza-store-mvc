using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PizzaStoreAPI.Service.Controllers
{
    public class AdditionalCheeseToppingsController : ApiController
    {
        ApplicationLogic processedData = new ApplicationLogic();

        [HttpGet]
        public HttpResponseMessage GetAllAdditionalCheeseToppings()
        {
            return Request.CreateResponse(HttpStatusCode.OK, processedData.GetAddionalCheeseToppings(), "application/json");
        }
    }
}
