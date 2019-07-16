using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaleProjetoMVC.Models;

namespace SaleProjetoMVC.Controllers
{
    public class DepartamentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departament> list = new List<Departament>();

            list.Add(new Departament { id = 1, name = "Eletronicos" });
            list.Add(new Departament { id = 2, name = "Fashion" });

            return View(list);
        }
    }
}