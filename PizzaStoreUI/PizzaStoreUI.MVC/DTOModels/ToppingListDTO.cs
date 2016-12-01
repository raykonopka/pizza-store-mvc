using System.Runtime.Serialization;

namespace PizzaStoreUI.MVC.DTOModels
{
    
    public class ToppingListDTO
    {
        
        public int Id { get; set; }
        
        public int Pizza { get; set; }
        
        public int Topping { get; set; }
        
        public int Placement { get; set; }

    }
}