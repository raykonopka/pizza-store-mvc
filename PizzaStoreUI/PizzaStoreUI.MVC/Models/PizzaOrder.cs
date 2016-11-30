using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStoreUI.MVC.Models
{
    public class PizzaOrder
    {
        public string size { get; set; }
        public string crust { get; set; }
        public string sauce { get; set; }
        public string cheese { get; set; }

        public string vegetableToppings { get; set; }
        public string meatToppings { get; set; }
        public string additionalCheeseToppings { get; set; }

        public string customerId { get; set; }

        public string addressStreet { get; set; }
        public string addressCity { get; set; }
        public string addressState { get; set; }
        public string addressZip { get; set; }
        public string paymentMethod { get; set; }
    }
}