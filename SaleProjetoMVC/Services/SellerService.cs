using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleProjetoMVC.Models;

namespace SaleProjetoMVC.Services
{
    public class SellerService
    {

        private readonly SaleProjetoMVCContext _context;   

        public SellerService(SaleProjetoMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        public void Insert(Seller obj)
        {
            _context.Add(obj); 
            _context.SaveChanges();
        }
    }
}
