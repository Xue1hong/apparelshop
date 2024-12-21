using System.ComponentModel.DataAnnotations;
using apparelshop.Models;
namespace apparelshop.Dtos
{
    public class CustomersOfProducts
    {
        [Required] 
        public int ProductID { get; set; }
        [Required] 
        public string Name { get; set; }
        public List<String> Customers{ get; set; } = new List<String>();
    }
}
