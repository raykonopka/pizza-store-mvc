using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStoreUI.MVC.Models
{
    public class OrderReceipt
    {
        public string size { get; set; }

        public string crust { get; set; }

        public string sauce { get; set; }

        public string cheese { get; set; }

        public string toppings { get; set; }

        public string subtotal { get; set; }

        public string taxes { get; set; }

        public string total { get; set; }

        public string paymentType { get; set; }

        public string deliveryAddress { get; set; }

        
    }
}