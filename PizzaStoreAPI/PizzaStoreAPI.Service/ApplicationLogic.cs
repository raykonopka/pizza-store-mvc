using PizzaStoreAPI.Service.PizzaStoreDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStoreAPI.Service
{
    public class ApplicationLogic
    {
        private PizzaStoreDataServiceClient psDataClient = new PizzaStoreDataServiceClient();

        #region Options For Ordering Pizza
        public List<PaymentMethodDAO> GetPaymentMethods()
        {
            return psDataClient.GetPaymentMethods().ToList();
        }

        //Pizza Options
        public List<PizzaSizeDAO> GetPizzaSizes()
        {
            return psDataClient.GetPizzaSizes().ToList();
        }

        public List<SauceTypeDAO> GetSauceTypes()
        {
            return psDataClient.GetSauceTypes().ToList();
        }

        public List<CrustTypeDAO> GetCrustTypes()
        {
            return psDataClient.GetCrustTypes().ToList();
        }

        public List<CheeseTypeDAO> GetCheeseTypes()
        {
            return psDataClient.GetCheeseTypes().ToList();
        }


        //Topping Options
        public List<ToppingDAO> GetVegetableToppings()
        {
            var vegCategory = psDataClient.GetToppingCategories().Where(vc => vc.Name == "Vegetables");
            int vegCategoryId;

            if(vegCategory.Count() == 1)
            {
                vegCategoryId = vegCategory.First().Id;

                var vegetableToppings = psDataClient.GetToppings().Where(vt => vt.Category == vegCategoryId).ToList();

                return vegetableToppings;
            }

            else
            {
                return null;
            }
        }

        public List<ToppingDAO> GetMeatToppings()
        {
            var meatCategory = psDataClient.GetToppingCategories().Where(mc => mc.Name == "Meats");
            int meatCategoryId;

            if (meatCategory.Count() == 1)
            {
                meatCategoryId = meatCategory.First().Id;

                var meatToppings = psDataClient.GetToppings().Where(mt => mt.Category == meatCategoryId).ToList();

                return meatToppings;
            }

            else
            {
                return null;
            } 
        }

        public List<ToppingDAO> GetAddionalCheeseToppings()
        {
            var addCheeseCategory = psDataClient.GetToppingCategories().Where(cc => cc.Name == "Additional Cheeses");
            int addCheeseCategoryId;

            if (addCheeseCategory.Count() == 1)
            {
                addCheeseCategoryId = addCheeseCategory.First().Id;

                var addCheeseToppings = psDataClient.GetToppings().Where(ac => ac.Category == addCheeseCategoryId).ToList();

                return addCheeseToppings;
            }

            else
            {
                return null;
            }
        }

        public List<ToppingPlacementDAO> GetToppingPlacements()
        {
            return psDataClient.GetToppingPlacements().ToList();
        }

        #endregion

        #region Functions For Ordering Pizza
        public void sentOrder(OrderDAO newOrder)
        {
           psDataClient.postOrder(newOrder);
        }


        #endregion
    }
}