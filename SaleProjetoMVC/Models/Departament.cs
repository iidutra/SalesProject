using System;
using System.Collections.Generic;
using System.Linq;
namespace SaleProjetoMVC.Models
{
    public class Departament
    {

        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Seller> Sellers  { get; set; } = new List<Seller>();

        public Departament()
        {

        }

        public Departament(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
