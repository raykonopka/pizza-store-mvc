using PizzaStoreAPI.Service.Controllers;
using PizzaStoreAPI.Service.PizzaStoreDataService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PizzaStoreAPI.Tests
{
    public class ApiTests
    {
        //Test After API Is Published

        [Fact]
        public void Test_GetAllSauces()
        {
            HttpClient httpClient = new HttpClient();

            var actual = httpClient.GetAsync("http://ec2-54-147-132-20.compute-1.amazonaws.com/pizza-store-api/api/sauces/").Result;

            if (actual.IsSuccessStatusCode)
            {
                Debug.WriteLine("Sauce JSON Content Received.");
            }
            else
            {
                Debug.WriteLine("Sauce JSON Failed To Send.");
            }

            Assert.True(actual.IsSuccessStatusCode);
        }

    }
}
