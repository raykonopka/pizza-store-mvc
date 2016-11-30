using PizzaStoreUI.MVC.PizzaStoreDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace PizzaStoreUI.MVC
{
    public class ClientHelper
    {

        #region Selection For Ordering Pizza

        public static List<SelectListItem> GetSizes()
        {
            var sizeSelectList = new List<SelectListItem>();

            List<PizzaSizeDAO> sizes = ApiAccess.getItemsFromApi<List<PizzaSizeDAO>>("sizes");

            foreach (PizzaSizeDAO sz in sizes)
            {
                SelectListItem selectItem = new SelectListItem() { Text = sz.Name, Value = sz.Name };
                

                sizeSelectList.Add(selectItem);
            }

            return sizeSelectList;
        }

        public static List<SelectListItem> GetCrusts()
        {
            var crustSelectList = new List<SelectListItem>();

            List<CrustTypeDAO> crusts = ApiAccess.getItemsFromApi<List<CrustTypeDAO>>("crusts");

            
            foreach (CrustTypeDAO c in crusts)
            {
                SelectListItem selectItem = new SelectListItem() { Text = c.Name, Value = c.Name };
                

                crustSelectList.Add(selectItem);
            }

            return crustSelectList;
        }

        public static List<SelectListItem> GetSauces()
        {
            var sauceSelectList = new List<SelectListItem>();

            List<SauceTypeDAO> sauces = ApiAccess.getItemsFromApi<List<SauceTypeDAO>>("sauces");

            
            foreach(SauceTypeDAO s in sauces)
            {
                SelectListItem selectItem =  new SelectListItem () { Text = s.Name, Value = s.Name };
                

                sauceSelectList.Add(selectItem);
            }

            return sauceSelectList;
        }

        public static List<SelectListItem> GetCheeses()
        {
            var cheeseSelectList = new List<SelectListItem>();

            List<CheeseTypeDAO> cheeses = ApiAccess.getItemsFromApi<List<CheeseTypeDAO>>("cheeses");

            
            foreach (CheeseTypeDAO ch in cheeses)
            {
                SelectListItem selectItem = new SelectListItem() { Text = ch.Name, Value = ch.Name };
               

                cheeseSelectList.Add(selectItem);
            }

            return cheeseSelectList;
        }

        public static List<SelectListItem> GetVegetableToppings()
        {
            var vegetableToppingSelectList = new List<SelectListItem>();

            List<ToppingDAO> vegetableToppings = ApiAccess.getItemsFromApi<List<ToppingDAO>>("vegetabletoppings");

            
            foreach (ToppingDAO tp in vegetableToppings)
            {
                SelectListItem selectItem = new SelectListItem() { Text = tp.Name, Value = tp.Name };
                

                vegetableToppingSelectList.Add(selectItem);
            }

            return vegetableToppingSelectList;
        }

        public static List<SelectListItem> GetMeatToppings()
        {
            var meatToppingSelectList = new List<SelectListItem>();

            List<ToppingDAO> meatToppings = ApiAccess.getItemsFromApi<List<ToppingDAO>>("meattoppings");

            
            foreach (ToppingDAO tp in meatToppings)
            {
                SelectListItem selectItem = new SelectListItem() { Text = tp.Name, Value = tp.Name };
                

                meatToppingSelectList.Add(selectItem);
            }

            return meatToppingSelectList;
        }

        public static List<SelectListItem> GetAdditionalCheeseToppings()
        {
            var additionalCheeseToppingSelectList = new List<SelectListItem>();

            List<ToppingDAO> additionalCheeseToppings = ApiAccess.getItemsFromApi<List<ToppingDAO>>("additionalcheesetoppings");

            
            foreach (ToppingDAO tp in additionalCheeseToppings)
            {
                SelectListItem selectItem = new SelectListItem() { Text = tp.Name, Value = tp.Name };
                

                additionalCheeseToppingSelectList.Add(selectItem);
            }

            return additionalCheeseToppingSelectList;
        }

        public static List<SelectListItem> GetToppingPlacements()
        {
            var toppingPlacementsSelectList = new List<SelectListItem>();

            List<ToppingPlacementDAO> toppingPlacements = ApiAccess.getItemsFromApi<List<ToppingPlacementDAO>>("toppingplacements");

            
            foreach (ToppingPlacementDAO tpl in toppingPlacements)
            {
                SelectListItem selectItem = new SelectListItem() { Text = tpl.Type, Value = tpl.Type };
                

                toppingPlacementsSelectList.Add(selectItem);
            }

            return toppingPlacementsSelectList;
        }

        public static List<SelectListItem> GetPaymentMethods()
        {
            var paymentMethodsSelectList = new List<SelectListItem>();

            List<PaymentMethodDAO> paymentMethods = ApiAccess.getItemsFromApi<List<PaymentMethodDAO>>("paymentmethods");

            
            foreach (PaymentMethodDAO pm in paymentMethods)
            {
                SelectListItem selectItem = new SelectListItem() { Text = pm.Name, Value = pm.Name };
                

                paymentMethodsSelectList.Add(selectItem);
            }

            return paymentMethodsSelectList;
        }

        #endregion

    }
}