using SaleProjetoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaleProjetoMVC.Services
{
    public class DepartamentService
    {

        private readonly SaleProjetoMVCContext _context;

        public DepartamentService(SaleProjetoMVCContext context)
        {
            _context = context;
        }
        public List<Departament> FindAll()
        {
            return _context.Departament.OrderBy(x => x.name).ToList();
        }
    }
}
