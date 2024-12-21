using apparelshop.Models;
using System.ComponentModel.DataAnnotations;

namespace apparelshop.Dtos
{
    public class CustomersDetailsOfCalendar
    {
        [Required] 
        public int ProductsId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Stock { get; set; }
        public List<Customers> Members { get; set; } = new List<Customers>();
    }
}
