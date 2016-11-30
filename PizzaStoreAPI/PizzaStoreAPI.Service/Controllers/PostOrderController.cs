using PizzaStoreAPI.Service.PizzaStoreDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Http;

namespace PizzaStoreAPI.Service.Controllers
{
    public class PostOrderController : ApiController
    {
        ApplicationLogic processedData = new ApplicationLogic();

        [HttpPost]
        public void ReceiveOrder([FromBody] OrderDAO newOrder)
        {
            processedData.sentOrder(newOrder);
        }

    }
}
