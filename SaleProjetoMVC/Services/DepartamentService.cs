using SaleProjetoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SaleProjetoMVC.Services
{
    public class DepartamentService
    {

        private readonly SaleProjetoMVCContext _context;

        public DepartamentService(SaleProjetoMVCContext context)
        {
            _context = context;
        }
        public async Task<List<Departament>> FindAllAsync()
        {
            return await _context.Departament.OrderBy(x => x.name).ToListAsync();
        }
    }
}
