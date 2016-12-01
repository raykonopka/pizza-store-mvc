using PizzaStoreUI.MVC.DTOModels;
using PizzaStoreUI.MVC.Models;
using PizzaStoreUI.MVC.PizzaStoreDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            var httpResponse = httpClient.GetAsync("http://34.193.163.157/pizza-store-api/api/" + controllerName + "/").Result;

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

            List<PizzaSizeDTO> sizes = ApiAccess.getItemsFromApi<List<PizzaSizeDTO>>("sizes");
            var matchingSizes = sizes.Where(x => x.Name == pendingOrder.size);
            decimal sizePrice = matchingSizes.First().Price;

            List<CrustTypeDTO> crusts = ApiAccess.getItemsFromApi<List<CrustTypeDTO>>("crusts");
            var matchingCrusts = crusts.Where(x => x.Name == pendingOrder.crust);
            decimal crustPrice = matchingCrusts.First().Price;

            List<SauceTypeDTO> sauces = ApiAccess.getItemsFromApi<List<SauceTypeDTO>> ("sauces");
            var matchingSauces = sauces.Where(x => x.Name == pendingOrder.sauce);
            decimal saucePrice = matchingSauces.First().Price;

            List<CheeseTypeDTO> cheeses = ApiAccess.getItemsFromApi<List<CheeseTypeDTO>>("cheeses");
            var matchingCheeses = cheeses.Where(x => x.Name == pendingOrder.cheese);
            decimal cheesePrice = matchingCheeses.First().Price;

            decimal toppingTotalPrice = 0;
            string toppingString = "";
            List<ToppingDTO> vegetableToppings = ApiAccess.getItemsFromApi<List<ToppingDTO>>("vegetabletoppings");

                var matchingVegetableToppings = vegetableToppings.Where(x => x.Name == pendingOrder.vegetableToppings);
                toppingTotalPrice = toppingTotalPrice + matchingVegetableToppings.First().Price;
                toppingString = toppingString + " " + pendingOrder.vegetableToppings;

            List<ToppingDTO> meatToppings = ApiAccess.getItemsFromApi<List<ToppingDTO>>("meattoppings");

                var matchingMeatToppings = meatToppings.Where(x => x.Name == pendingOrder.meatToppings);
                toppingTotalPrice = toppingTotalPrice + matchingMeatToppings.First().Price;
                toppingString = toppingString + " " + pendingOrder.meatToppings;

            List<ToppingDTO> additionalCheeseToppings = ApiAccess.getItemsFromApi<List<ToppingDTO>>("additionalcheesetoppings");


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



        public static bool SubmitOrder(OrderDTO newOrder)
        {
            PizzaStoreDataServiceClient pizzaStoreData = new PizzaStoreDataServiceClient();

            OrderDAO orderToDAO = new OrderDAO();
            orderToDAO.Id = newOrder.Id;
            orderToDAO.Subtotal = newOrder.Subtotal;
            orderToDAO.Taxes = newOrder.Taxes;
            orderToDAO.Total = newOrder.Total;
            orderToDAO.Timestamp = newOrder.Timestamp;
            orderToDAO.Customer = newOrder.Customer;
            orderToDAO.PaymentMethod = newOrder.PaymentMethod;


            return pizzaStoreData.PostNewOrder(orderToDAO);
        }


        public static int getUserId(string username, string password)
        {
            return 1;
        }
        
    }
}