using PizzaStoreUI.MVC.DTOModels;
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

            List<PizzaSizeDTO> sizes = ApiAccess.getItemsFromApi<List<PizzaSizeDTO>>("sizes");

            foreach (PizzaSizeDTO sz in sizes)
            {
                SelectListItem selectItem = new SelectListItem() { Text = sz.Name, Value = sz.Name };
                

                sizeSelectList.Add(selectItem);
            }

            return sizeSelectList;
        }

        public static List<SelectListItem> GetCrusts()
        {
            var crustSelectList = new List<SelectListItem>();

            List<CrustTypeDTO> crusts = ApiAccess.getItemsFromApi<List<CrustTypeDTO>>("crusts");

            
            foreach (CrustTypeDTO c in crusts)
            {
                SelectListItem selectItem = new SelectListItem() { Text = c.Name, Value = c.Name };
                

                crustSelectList.Add(selectItem);
            }

            return crustSelectList;
        }

        public static List<SelectListItem> GetSauces()
        {
            var sauceSelectList = new List<SelectListItem>();

            List<SauceTypeDTO> sauces = ApiAccess.getItemsFromApi<List<SauceTypeDTO>>("sauces");

            
            foreach(SauceTypeDTO s in sauces)
            {
                SelectListItem selectItem =  new SelectListItem () { Text = s.Name, Value = s.Name };
                

                sauceSelectList.Add(selectItem);
            }

            return sauceSelectList;
        }

        public static List<SelectListItem> GetCheeses()
        {
            var cheeseSelectList = new List<SelectListItem>();

            List<CheeseTypeDTO> cheeses = ApiAccess.getItemsFromApi<List<CheeseTypeDTO>>("cheeses");

            
            foreach (CheeseTypeDTO ch in cheeses)
            {
                SelectListItem selectItem = new SelectListItem() { Text = ch.Name, Value = ch.Name };
               

                cheeseSelectList.Add(selectItem);
            }

            return cheeseSelectList;
        }

        public static List<SelectListItem> GetVegetableToppings()
        {
            var vegetableToppingSelectList = new List<SelectListItem>();

            List<ToppingDTO> vegetableToppings = ApiAccess.getItemsFromApi<List<ToppingDTO>>("vegetabletoppings");

            
            foreach (ToppingDTO tp in vegetableToppings)
            {
                SelectListItem selectItem = new SelectListItem() { Text = tp.Name, Value = tp.Name };
                

                vegetableToppingSelectList.Add(selectItem);
            }

            return vegetableToppingSelectList;
        }

        public static List<SelectListItem> GetMeatToppings()
        {
            var meatToppingSelectList = new List<SelectListItem>();

            List<ToppingDTO> meatToppings = ApiAccess.getItemsFromApi<List<ToppingDTO>>("meattoppings");

            
            foreach (ToppingDTO tp in meatToppings)
            {
                SelectListItem selectItem = new SelectListItem() { Text = tp.Name, Value = tp.Name };
                

                meatToppingSelectList.Add(selectItem);
            }

            return meatToppingSelectList;
        }

        public static List<SelectListItem> GetAdditionalCheeseToppings()
        {
            var additionalCheeseToppingSelectList = new List<SelectListItem>();

            List<ToppingDTO> additionalCheeseToppings = ApiAccess.getItemsFromApi<List<ToppingDTO>>("additionalcheesetoppings");

            
            foreach (ToppingDTO tp in additionalCheeseToppings)
            {
                SelectListItem selectItem = new SelectListItem() { Text = tp.Name, Value = tp.Name };
                

                additionalCheeseToppingSelectList.Add(selectItem);
            }

            return additionalCheeseToppingSelectList;
        }

        public static List<SelectListItem> GetToppingPlacements()
        {
            var toppingPlacementsSelectList = new List<SelectListItem>();

            List<ToppingPlacementDTO> toppingPlacements = ApiAccess.getItemsFromApi<List<ToppingPlacementDTO>>("toppingplacements");

            
            foreach (ToppingPlacementDTO tpl in toppingPlacements)
            {
                SelectListItem selectItem = new SelectListItem() { Text = tpl.Type, Value = tpl.Type };
                

                toppingPlacementsSelectList.Add(selectItem);
            }

            return toppingPlacementsSelectList;
        }

        public static List<SelectListItem> GetPaymentMethods()
        {
            var paymentMethodsSelectList = new List<SelectListItem>();

            List<PaymentMethodDTO> paymentMethods = ApiAccess.getItemsFromApi<List<PaymentMethodDTO>>("paymentmethods");

            
            foreach (PaymentMethodDTO pm in paymentMethods)
            {
                SelectListItem selectItem = new SelectListItem() { Text = pm.Name, Value = pm.Name };
                

                paymentMethodsSelectList.Add(selectItem);
            }

            return paymentMethodsSelectList;
        }

        #endregion

    }
}