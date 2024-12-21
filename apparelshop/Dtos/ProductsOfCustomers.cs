using System.ComponentModel.DataAnnotations;
using apparelshop.Models;
namespace apparelshop.Dtos
{
    public class ProductsOfCustomers
    {
        [Required] public int CustomerID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Phone { get; set; }
        public List<String> Products{ get; set; } = new List<String>();
    }
}
