using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RyansEventManager.Models;

namespace RyansEventManager.Controllers
{
    public class OrderCartController : Controller
    {
        RyansEventManagerDB db = new RyansEventManagerDB();

        [Authorize]
        // GET: OrderCart
        public ActionResult Index()
        {
            OrderCart cart = OrderCart.GetCart(this.HttpContext);

            OrderCartViewModel vm = new OrderCartViewModel()
            {
                OrderItems = cart.GetCartItems()
            };

            return View(vm);
        }

        //GET
        public ActionResult AddToCart(int id)
        {
            OrderCart cart = OrderCart.GetCart(this.HttpContext);

            cart.AddToCart(id);

            return RedirectToAction("Index");
 
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            OrderCart cart = OrderCart.GetCart(this.HttpContext);

            Event events = db.Orders.SingleOrDefault(c => c.RecordId == id).EventSelected;

            int newItemCount = cart.RemoveFromCart(id);

            OrderCartRemoveViewModel vm = new OrderCartRemoveViewModel()
            {
                DeleteId = id,
                ItemCount = newItemCount,
                Message = events.EventTitle + " has been removed from the cart"
            };

            return Json(vm);
        }
    }
}