using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleProjetoMVC.Models;
using SaleProjetoMVC.Models.Enums;

namespace SaleProjetoMVC.Data
{
    public class SeedingService
    {

        private SaleProjetoMVCContext _context;
         
        public SeedingService(SaleProjetoMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Departament.Any() || _context.SalesRecord.Any())
            {
                return; //Db has been populed
            }

            Departament d1 = new Departament(0, "Computers");
            Departament d2 = new Departament(0, "Books");
            Departament d3 = new Departament(0, "Eletronics");
            Departament d4 = new Departament(0, "Games");

            Seller s1 = new Seller(0, "Bob Brown", "bob@gmail.com", new DateTime(1988, 4, 21), 1000.00, d1);
            Seller s2 = new Seller(0, "Mano Brown", "Mano@gmail.com", new DateTime(1989, 4, 22), 2000.00, d2);
            Seller s3 = new Seller(0, "Thiago Salvador", "ThiagoDelas@gmail.com", new DateTime(1989, 4, 30), 3000.00, d4);
            Seller s4 = new Seller(0, "Maria Alana", "Maria@gmail.com", new DateTime(1989, 4, 30), 3000.00, d3);

            SalesRecord r1 = new SalesRecord(0, new DateTime(2018, 09, 25), 11000.00, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(0, new DateTime(2018, 09, 23), 10000.00, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(0, new DateTime(2018, 09, 14), 19000.00, SaleStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(0, new DateTime(2018, 09, 23), 1000.00, SaleStatus.Billed, s4);
            SalesRecord r5 = new SalesRecord(0, new DateTime(2018, 09, 23), 17000.00, SaleStatus.Billed, s2);
            SalesRecord r6 = new SalesRecord(0, new DateTime(2018, 09, 23), 16000.00, SaleStatus.Billed, s1);
            SalesRecord r7 = new SalesRecord(0, new DateTime(2018, 09, 23), 124000.00, SaleStatus.Billed, s3);
            SalesRecord r8 = new SalesRecord(0, new DateTime(2018, 09, 23), 12000.00, SaleStatus.Billed, s2);

            _context.Departament.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8);
            _context.SaveChanges();
           

        }
    }
}
