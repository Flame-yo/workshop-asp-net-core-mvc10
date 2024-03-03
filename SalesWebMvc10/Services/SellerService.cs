using Microsoft.EntityFrameworkCore;
using SalesWebMvc10.Data;
using SalesWebMvc10.Models;
using SalesWebMvc10.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc10.Services
{
    public class SellerService
    {
        private readonly SalesWebMvc10Context _context;

        public SellerService(SalesWebMvc10Context context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            Seller obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Seller.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}