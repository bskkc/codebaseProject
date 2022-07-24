using codebaseProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codebaseProjesi.Controllers
{
    public class ProductController : Controller
    {
        private readonly CodebaseContext _db;
        public ProductController(CodebaseContext db)
        {
            _db = db;
        }


        //To List Products 
        public IActionResult Index()
        {
            var productList = _db.Products.ToList();
            return View(productList);
        }


        //To Create New Product 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product pro)
        {
            if (ModelState.IsValid)
            {
                _db.Add(pro);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pro);
        }


        //To Edit Product 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("Index");
            }
            var getProduct = await _db.Products.FindAsync(id);
            return View(getProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product prod)
        {
            if (ModelState.IsValid)
            {
                _db.Update(prod);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(prod);
        }


        //To Show the Details of Product 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("Index");
            }
            var getProduct = await _db.Products.FindAsync(id);
            return View(getProduct);
        }


        //To Delete Product 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("Index");
            }
            var getProduct = await _db.Products.FindAsync(id);
            return View(getProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var getProduct = await _db.Products.FindAsync(id);
            _db.Products.Remove(getProduct);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        //To Create Order and Customer
        public IActionResult CreateOrder()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult CreateOrder(CustOrder ord, int id)
        {
            CustOrder order = new CustOrder();
            order.OrderNumber = ord.OrderNumber;
            order.CustomerName = ord.CustomerName;
            order.ProductNumber = id;
            if (ord.OrderNumber > id)
            {
                ModelState.AddModelError("", "Order quantity exceeds product quantity.");
                return View(ord);
            }

            Customer customer = new Customer();
            customer.CustomerName = ord.CustomerName;

            _db.Add(customer);
            _db.Add(order);
            _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
