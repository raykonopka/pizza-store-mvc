using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaStoreUI.MVC.Models
{
    public class PizzaModel
    {
        //Pizza Options
        public List<SelectListItem> sizeOptions { get; set; }
        public List<SelectListItem> crustOptions { get; set; }
        public List<SelectListItem> sauceOptions { get; set; }
        public List<SelectListItem> cheeseOptions { get; set; }
        public List<SelectListItem> paymentOptions { get; set; }

        //Topping Options
        public List<SelectListItem> vegetableToppingOptions { get; set; }
        public List<SelectListItem> meatToppingOptions { get; set; }
        public List<SelectListItem> additionalCheeseToppingOptions { get; set; }
        public List<SelectListItem> toppingPlacementOptions { get; set; }


        public PizzaModel()
        {
            sizeOptions = ClientHelper.GetSizes();
            crustOptions = ClientHelper.GetCrusts();
            sauceOptions = ClientHelper.GetSauces();
            cheeseOptions = ClientHelper.GetCheeses();

            vegetableToppingOptions = ClientHelper.GetVegetableToppings();
            meatToppingOptions = ClientHelper.GetMeatToppings();
            additionalCheeseToppingOptions = ClientHelper.GetAdditionalCheeseToppings();
            toppingPlacementOptions = ClientHelper.GetToppingPlacements();
            paymentOptions = ClientHelper.GetPaymentMethods();
        }
    }
}