using codebaseProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codebaseProjesi.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CodebaseContext _db;
        public CustomerController(CodebaseContext db)
        {
            _db = db;
        }

        //To Create New Customer
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Customer cus)
        {
            if (ModelState.IsValid)
            {
                _db.Add(cus);
                await _db.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View(cus);
        }

        //To List Customers
        public IActionResult List()
        {
            var customerList = _db.Customers.ToList();
            return View(customerList);
        }

        //To Edit Customer 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("Index");
            }
            var getProduct = await _db.Customers.FindAsync(id);
            return View(getProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer cust)
        {
            if (ModelState.IsValid)
            {
                _db.Update(cust);
                await _db.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View(cust);
        }

        //To Delete Customer 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("Index");
            }
            var getCustomer = await _db.Customers.FindAsync(id);
            return View(getCustomer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var getCustomer = await _db.Customers.FindAsync(id);
            _db.Customers.Remove(getCustomer);
            await _db.SaveChangesAsync();
            return RedirectToAction("List");
        }

    }
}
