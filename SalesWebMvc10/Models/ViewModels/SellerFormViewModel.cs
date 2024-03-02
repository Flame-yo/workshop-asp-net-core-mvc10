using System.Collections.Generic;

namespace SalesWebMvc10.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
