

using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
	//[Authorize(Roles = "SuperAdmin")]
	public class CartController : Controller
    {
		
		private readonly DataDbContext db;
        public CartController(DataDbContext db)
        {
            this.db = db;
        }
        // GET: CartController
        public ActionResult Index()
        {
            var cart = db.Carts.FirstOrDefault(x=>x.Username==User.Identity.Name);
            var list=db.ProductCarts.Include(nameof(Product)).ToList();
            var model = new CartViewModel
            {
                ProductCartList = list,
                Cart = cart
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateQuantity(IFormCollection form)
        {

            var id = long.Parse(form["id"]);
            var qty = int.Parse(form["qty"]);
            var productInCart = db.ProductCarts.FirstOrDefault(x => x.Product.Id == id);
            productInCart.Quantity = qty;
            db.SaveChanges();
            return RedirectToAction("Index","Cart");
        }
        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
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

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
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
