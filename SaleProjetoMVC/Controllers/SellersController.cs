using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaleProjetoMVC.Models;
using SaleProjetoMVC.Models.ViewModels;
using SaleProjetoMVC.Services;
using SaleProjetoMVC.Services.Exceptions;

namespace SaleProjetoMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartamentService _departamentService;

        public SellersController(SellerService sellerService, DepartamentService departamentService)
        {
            _sellerService = sellerService;
            _departamentService = departamentService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Departaments = await _departamentService.FindAllAsync();
            var departaments = await _departamentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departmants = await _departamentService.FindAllAsync();
                var ViewModel = new SellerFormViewModel { Seller = seller, Departaments = departmants };
                return View(ViewModel);
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
             if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
            }
            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
            }
            List<Departament> departaments = await _departamentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departaments = departaments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {

            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.FindAllAsync();
                var ViewModel = new SellerFormViewModel { Seller = seller, Departaments = departaments };
                return View(ViewModel);
            }
           
            if(id != seller.id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
               await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });    
            }

        }
        public IActionResult Error(string message)
        {
            var ViewModel = new ErrorViewModel

            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(ViewModel);
        }

    }
}