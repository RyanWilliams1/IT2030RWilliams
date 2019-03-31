using MVCMusicStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {
        private MVCMusicStoreDBContext db = new MVCMusicStoreDBContext();

        // GET: Store
        public ActionResult Index(int id)
        {
            var albums =
                from album in db.Albums
                where album.GenreId == id
                select album;

            return View(albums.ToList());
            
        }

        public ActionResult Browse()
        {
            return View(db.Genres.ToList());
        }

        public ActionResult Details(int id)
        {
            Album album = db.Albums.Find(id);
            
            return View(album);
        }
    }
}