using System.Runtime.Serialization;

namespace PizzaStoreUI.MVC.DTOModels
{
    public class CheeseTypeDTO
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }
    }
}