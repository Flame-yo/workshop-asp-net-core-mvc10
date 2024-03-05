using Microsoft.EntityFrameworkCore;
using SalesWebMvc10.Data;
using SalesWebMvc10.Models;
using SalesWebMvc10.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc10.Services
{
    public class SellerService
    {
        private readonly SalesWebMvc10Context _context;

        public SellerService(SalesWebMvc10Context context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                Seller obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("You can't delete this seller because he/she has sales");
            }
        }

        public async Task UpdateAsync(Seller seller)
        {
            if (! await _context.Seller.AnyAsync(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}