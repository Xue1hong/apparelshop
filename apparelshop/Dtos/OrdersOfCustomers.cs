using System.ComponentModel.DataAnnotations;
using apparelshop.Models;
using apparelshop.Repositories;

namespace apparelshop.Dtos
{
    public class OrdersOfCustomers
    {
        [Required] 
        public int CustomerID { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required] 
        public string Phone { get; set; }
        public List<String> Orders { get; set; } = new List<String>();
    }
}
