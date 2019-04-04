 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStoreApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        //GET: ShoppingCart/AddToCart
        public ActionResult AddToCart()
        {
            throw new NotImplementedException();
        }

        //POST: ShoppingCart/RemoveFromCart
        [HttpPost]
        public ActionResult RemoveFromCart()
        {
            throw new NotImplementedException();
        }
    }
}