using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PizzaStoreUI.MVC.DTOModels
{
    
    public class PaymentMethodDTO
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}