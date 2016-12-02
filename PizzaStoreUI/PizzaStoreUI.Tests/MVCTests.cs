using PizzaStoreUI.MVC;
using PizzaStoreUI.MVC.DTOModels;
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
        public void Test_SubmitOrder()
        {
            OrderDTO orderToSend = new OrderDTO();

            orderToSend.PaymentMethod = 1;
            orderToSend.Customer = 1;
            orderToSend.Subtotal = 8;
            orderToSend.Taxes = 1;
            orderToSend.Total = 9;
            orderToSend.Timestamp = DateTime.Now;

            var actual = ApiAccess.SubmitOrder(orderToSend);

            Assert.True(actual);
        }

    }
}
