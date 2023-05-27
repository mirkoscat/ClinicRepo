using System.Data;
using System.Data.Entity;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly DataDbContext db;
        public StoreController(IStoreService ss, DataDbContext db)
        {
            _storeService = ss;
            this.db = db;

        }
        // GET: StoreController
        public ActionResult Index()
        {
            var list = _storeService.GetProducts().ToList();
            return View(list);
        }

        // GET: StoreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {
            try
            {
                var result = _storeService.CreateProduct(p);
                if (result != null)
                    return RedirectToAction(nameof(Index));
                return View(p);
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(int id, int qty, Product p)
        {//need changes, should not call db in controller
            var cart = db.Carts.FirstOrDefault(x => x.Username == User.Identity.Name);
            var product = db.Products.Single(x => x.Id == id);


            if (cart == null)
            {
                var c = new Cart()
                {
                    Username = User.Identity.Name
                };
                db.Carts.Add(c);
                db.SaveChanges();
                var result = _storeService.AddToCart(product, c, qty);
                if (result != null)
                    return RedirectToAction(nameof(Index));

            }
            else
            {
                var result = _storeService.AddToCart(product, cart, qty);

                if (result != null)
                    return RedirectToAction(nameof(Index));

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
