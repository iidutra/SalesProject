using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SaleProjetoMVC.Models
{
    public class SaleProjetoMVCContext : DbContext
    {
        public SaleProjetoMVCContext (DbContextOptions<SaleProjetoMVCContext> options)
            : base(options)
        {
        }

        public DbSet<SaleProjetoMVC.Models.Departament> Departament { get; set; }
    }
}
