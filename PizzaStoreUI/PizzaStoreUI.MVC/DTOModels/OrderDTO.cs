using System;
using System.Runtime.Serialization;

namespace PizzaStoreUI.MVC.DTOModels
{
    
    public class OrderDTO
    {
        
        public int Id { get; set; }
        
        public Nullable<decimal> Subtotal { get; set; }
        
        public Nullable<decimal> Taxes { get; set; }
        
        public Nullable<decimal> Total { get; set; }
        
        public Nullable<DateTime> Timestamp { get; set; }
        
        public int Customer { get; set; }
        
        public int PaymentMethod { get; set; }
    }
}