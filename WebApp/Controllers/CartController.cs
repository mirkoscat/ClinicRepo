

using BusinessLayer;
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
		
		private readonly DataDbContext _context;
		private readonly IStoreService _storeService;
        public CartController(DataDbContext db, IStoreService ss)
        {
            _context = db;
            _storeService = ss;
        }
        // GET: CartController
        public ActionResult Index()
        {
            var cart = _context.Carts.FirstOrDefault(x=>x.Username==User.Identity.Name);
            var list=_context.ProductCarts.Include(nameof(Product)).ToList();
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
            var productInCart = _context.ProductCarts.FirstOrDefault(x => x.Product.Id == id);
            productInCart.Quantity = qty;
            _context.SaveChanges();
            return RedirectToAction("Index","Cart");
        }


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Checkout(CartViewModel model)
		{
			try
			{
                var cart = model.Cart;
                var list = model.ProductCartList.ToList();
                var street = model.StreetName;
                var result = _storeService.Checkout(cart,list,street);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
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
