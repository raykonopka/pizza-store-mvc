using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PizzaStoreUI.Tests
{
    public class MVCTests
    {
        //Test After API Is Published

        [Fact]
        public void Test_LoadOrderPage()
        {
            HttpClient httpClient = new HttpClient();

            var actual = httpClient.GetAsync("http://34.193.163.157/pizza-store-mvc/PizzaStore/Order").Result;

            if (actual.IsSuccessStatusCode)
            {
                Debug.WriteLine("Order Page Sucessfully Loaded.");
            }
            else
            {
                Debug.WriteLine("Order Page Failed To Load.");
            }

            Assert.True(actual.IsSuccessStatusCode);
        }

    }
}
