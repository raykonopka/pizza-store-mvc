using PizzaStoreUI.MVC.Models;
using PizzaStoreUI.MVC.PizzaStoreDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaStoreUI.MVC.Controllers
{
    public class PizzaStoreController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginAttempt(string username, string password)
        {
            int userId = ApiAccess.getUserId(username, password);

            if (userId > 0)
            {
                //Remove any existing cookies
                if (Request.Cookies["CustomerUserInfo"] != null)
                {
                    HttpCookie myCookie = new HttpCookie("CustomerUserInfo");
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                }

                //Add cookie with registrar user id
                HttpCookie customerCookie = new HttpCookie("CustomerUserInfo");
                customerCookie["CustomerUserInfo"] = userId.ToString();
                customerCookie.Expires = DateTime.Now.AddDays(1d);
                Response.Cookies.Add(customerCookie);

                return Redirect("http://ec2-54-147-132-20.compute-1.amazonaws.com/pizza-store-mvc/PizzaStore/Order");
            }

            else
            {
                return Redirect("http://ec2-54-147-132-20.compute-1.amazonaws.com/pizza-store-mvc/PizzaStore/Login");
            }
        }

        public ActionResult Order()
        {
            if (Request.Cookies["CustomerUserInfo"] != null)
            {
                ViewBag.Message = "Order Online";

                var model = new PizzaModel();
                return View(model);
            }

            else
            {
                return Redirect("http://ec2-54-147-132-20.compute-1.amazonaws.com/pizza-store-mvc/PizzaStore/Login");
            }
        }

        public ActionResult OrderPending(
            string size,
            string crust,
            string sauce,
            string cheese,
            string vegetableToppings,
            string meatToppings,
            string additionalCheeseToppings,
            string addressStreet,
            string addressCity,
            string addressState,
            string addressZip,
            string paymentMethod,
            string creditCard
            )
        {
            
            var pendingOrder = new PizzaOrder();

            pendingOrder.size = size;
            pendingOrder.crust = crust;
            pendingOrder.sauce = sauce;
            pendingOrder.cheese = cheese;
            pendingOrder.vegetableToppings = vegetableToppings;
            pendingOrder.meatToppings = meatToppings;
            pendingOrder.additionalCheeseToppings = additionalCheeseToppings;
            pendingOrder.addressStreet = addressStreet;
            pendingOrder.addressCity = addressCity;
            pendingOrder.addressState = addressState;
            pendingOrder.addressZip = addressZip;
            pendingOrder.paymentMethod = paymentMethod;

            //ADD USER ID TO PENDING ORDER
            //Look for user info cookie
            HttpCookie myCookie = new HttpCookie("CustomerUserInfo");
            myCookie = Request.Cookies["CustomerUserInfo"];
            int userIdFromCookie;

            if (myCookie != null)
            {
                string[] cookieInfo = myCookie.Value.Split('=');
                Int32.TryParse(cookieInfo[1], out userIdFromCookie);
                pendingOrder.customerId = userIdFromCookie.ToString();
            }

            //If there is no cookie found with proper user info, send back to corresponding login screen
            else
            {
                Response.Redirect("http://ec2-54-147-132-20.compute-1.amazonaws.com/pizza-store-mvc/PizzaStore/Login");
            }

            var orderPreview = ApiAccess.GetPendingOrderReceipt(pendingOrder);

            return View(orderPreview);
        }

        public ActionResult OrderConfirmed(string subtotal, string taxes, string total, string paymentType)
        {
            OrderDAO orderToSend = new OrderDAO();

            DateTime orderDateTime = DateTime.Now;
            orderToSend.Timestamp = orderDateTime;

            
            List<PaymentMethodDAO> paymentMethods = ApiAccess.getItemsFromApi<List<PaymentMethodDAO>>("paymentmethods");
            var matchingMethods = paymentMethods.Where(x => x.Name == paymentType);
            int paymentMethodId = matchingMethods.First().Id;
            orderToSend.PaymentMethod = paymentMethodId;
            

            //ADD USER ID TO PENDING ORDER
            //Look for user info cookie
            HttpCookie myCookie = new HttpCookie("CustomerUserInfo");
            myCookie = Request.Cookies["CustomerUserInfo"];
            int userIdFromCookie;

            if (myCookie != null)
            {
                string[] cookieInfo = myCookie.Value.Split('=');
                Int32.TryParse(cookieInfo[1], out userIdFromCookie);
                orderToSend.Customer = userIdFromCookie;
            }

            //If there is no cookie found with proper user info, send back to corresponding login screen
            else
            {
                Response.Redirect("http://ec2-54-147-132-20.compute-1.amazonaws.com/pizza-store-mvc/PizzaStore/Login");
            }
            

            orderToSend.Subtotal = decimal.Parse(subtotal);
            orderToSend.Taxes = decimal.Parse(taxes);
            orderToSend.Total = decimal.Parse(total);


            bool orderSent = ApiAccess.SubmitOrder(orderToSend);

            if (orderSent)
            {
                ViewBag.Title = "Order Confirmed";
                ViewBag.Message = "Order Confirmned!";

                return View();
            }

            else
            {
                ViewBag.Title = "Error Placing Order";
                ViewBag.Message = "There was an error and we could not place your order.";

                return View();
            }
        }

        public ActionResult OrderHistory()
        {
            ViewBag.Message = "Order History";

            PizzaStoreDataServiceClient psDataClient = new PizzaStoreDataServiceClient();
            List<OrderDAO> orderHistory = psDataClient.GetOrders().ToList();

            ViewBag.Orders(orderHistory);

            return View();
        }
    }
}