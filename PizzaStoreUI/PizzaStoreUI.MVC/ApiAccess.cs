using PizzaStoreUI.MVC.Models;
using PizzaStoreUI.MVC.PizzaStoreDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Xml.Serialization;

namespace PizzaStoreUI.MVC
{
    public class ApiAccess
    {
        public static T getItemsFromApi<T>(string controllerName) where T:class,new()
        {
            HttpClient httpClient = new HttpClient();

            var httpResponse = httpClient.GetAsync("http://ec2-54-147-132-20.compute-1.amazonaws.com/pizza-store-api/api/" + controllerName + "/").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var stream = httpResponse.Content.ReadAsStreamAsync().Result;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                T items = serializer.ReadObject(stream) as T;

                return items;
            }
            else
            {
                return null;
            }
        }

        public static OrderReceipt GetPendingOrderReceipt(PizzaOrder pendingOrder)
        {
            OrderReceipt pendingReceipt = new OrderReceipt();

            List<PizzaSizeDAO> sizes = ApiAccess.getItemsFromApi<List<PizzaSizeDAO>>("sizes");
            var matchingSizes = sizes.Where(x => x.Name == pendingOrder.size);
            decimal sizePrice = matchingSizes.First().Price;

            List<CrustTypeDAO> crusts = ApiAccess.getItemsFromApi<List<CrustTypeDAO>>("crusts");
            var matchingCrusts = crusts.Where(x => x.Name == pendingOrder.crust);
            decimal crustPrice = matchingCrusts.First().Price;

            List<SauceTypeDAO> sauces = ApiAccess.getItemsFromApi<List<SauceTypeDAO>> ("sauces");
            var matchingSauces = sauces.Where(x => x.Name == pendingOrder.sauce);
            decimal saucePrice = matchingSauces.First().Price;

            List<CheeseTypeDAO> cheeses = ApiAccess.getItemsFromApi<List<CheeseTypeDAO>>("cheeses");
            var matchingCheeses = cheeses.Where(x => x.Name == pendingOrder.cheese);
            decimal cheesePrice = matchingCheeses.First().Price;

            decimal toppingTotalPrice = 0;
            string toppingString = "";
            List<ToppingDAO> vegetableToppings = ApiAccess.getItemsFromApi<List<ToppingDAO>>("vegetabletoppings");

                var matchingVegetableToppings = vegetableToppings.Where(x => x.Name == pendingOrder.vegetableToppings);
                toppingTotalPrice = toppingTotalPrice + matchingVegetableToppings.First().Price;
                toppingString = toppingString + " " + pendingOrder.vegetableToppings;

            List<ToppingDAO> meatToppings = ApiAccess.getItemsFromApi<List<ToppingDAO>>("meattoppings");

                var matchingMeatToppings = meatToppings.Where(x => x.Name == pendingOrder.meatToppings);
                toppingTotalPrice = toppingTotalPrice + matchingMeatToppings.First().Price;
                toppingString = toppingString + " " + pendingOrder.meatToppings;

            List<ToppingDAO> additionalCheeseToppings = ApiAccess.getItemsFromApi<List<ToppingDAO>>("additionalcheesetoppings");


                var matchingAdditionalCheeseToppings = additionalCheeseToppings.Where(x => x.Name == pendingOrder.additionalCheeseToppings);
                toppingTotalPrice = toppingTotalPrice + matchingAdditionalCheeseToppings.First().Price;
                toppingString = toppingString + " " + pendingOrder.additionalCheeseToppings;

            pendingReceipt.cheese = pendingOrder.cheese;
            pendingReceipt.size = pendingOrder.size;
            pendingReceipt.sauce = pendingOrder.sauce;
            pendingReceipt.crust = pendingOrder.crust;
            pendingReceipt.deliveryAddress = (pendingOrder.addressStreet + " " + pendingOrder.addressCity + " " + pendingOrder.addressState + " " + pendingOrder.addressZip);
            pendingReceipt.paymentType = pendingOrder.paymentMethod;

            decimal subTotalAmt = (sizePrice + cheesePrice + saucePrice + crustPrice + toppingTotalPrice);
            pendingReceipt.subtotal = subTotalAmt.ToString();

            pendingReceipt.taxes = (1).ToString();

            decimal totalAmt = (sizePrice + cheesePrice + saucePrice + crustPrice + toppingTotalPrice) + 1;
            pendingReceipt.total = totalAmt.ToString();

            pendingReceipt.toppings = toppingString;
            return pendingReceipt;
        }



        public static bool SubmitOrder(OrderDAO newOrder)
        {
            PizzaStoreDataServiceClient psDataClient = new PizzaStoreDataServiceClient();

            return psDataClient.postOrder(newOrder);
        }




        public static int getUserId(string username, string password)
        {
            return 1;
        }
        
    }
}