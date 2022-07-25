using codebaseProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codebaseProjesi.Controllers
{
    public class OrderController : Controller
    {
        private readonly CodebaseContext _db;
        public OrderController(CodebaseContext db)
        {
            _db = db;
        }


        //To List Orders 
        public IActionResult Index()
        {
            var productList = _db.CustOrders.ToList();
            return View(productList);
        }


        //To Edit Order 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("Index");
            }
            var getProduct = await _db.CustOrders.FindAsync(id);
            return View(getProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustOrder ord)
        {
            if (ModelState.IsValid)
            {
                _db.Update(ord);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ord);
        }


        //To Delete Order 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("Index");
            }
            var getProduct = await _db.CustOrders.FindAsync(id);
            return View(getProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var getOrder = await _db.CustOrders.FindAsync(id);
            _db.CustOrders.Remove(getOrder);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
