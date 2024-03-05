using Microsoft.EntityFrameworkCore;
using SalesWebMvc10.Data;
using SalesWebMvc10.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc10.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvc10Context _context;

        public DepartmentService(SalesWebMvc10Context context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
