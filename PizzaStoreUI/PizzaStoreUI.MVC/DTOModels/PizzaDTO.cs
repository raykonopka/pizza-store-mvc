using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PizzaStoreUI.MVC.DTOModels
{
    
    public class PizzaDTO
    {
        
        public int Id { get; set; }

        
        public int PizzaSize { get; set; }

        
        public int CrustType { get; set; }

        
        public int SauceType { get; set; }

        
        public int CheeseType { get; set; }

        
        public int Order { get; set; }
    }
}