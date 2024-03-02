using SalesWebMvc10.Data;
using SalesWebMvc10.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc10.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvc10Context _context;

        public DepartmentService(SalesWebMvc10Context context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
