using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using RyansEventManager.Models;
using System.Net;


namespace RyansEventManager.Controllers
{
    public class HomeController : Controller
    {
        private RyansEventManagerDB db = new RyansEventManagerDB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //Last Minute Deal
        public ActionResult LastMinuteDeal()
        {
            var events = GetLastMinuteDeal();


            return PartialView("_LastMinuteDeal", events);
        }
        //Last Minunte Deal
        private List<Event> GetLastMinuteDeal()
        {
            var searchStartDate = DateTime.Now;
            var daysPlusTwo = searchStartDate.AddDays(2);

            return db.Events
                .Where(e => e.StartDate >= searchStartDate && e.StartDate < daysPlusTwo)
                .ToList();

        }

        //Events near you
        public ActionResult EventSearch(string a, string q)
        {
            var events = GetEvents(a, q);

            return PartialView("_EventSearch", events);
        }

        //Events near you
        private List<Event> GetEvents(string searchTitleType, string searchCityState)
        {
            return db.Events
                .Where(e => e.EventTitle.Contains(searchTitleType) || e.EventType.EventTypeName.Contains(searchTitleType) && e.EventLocation.Contains(searchCityState))
                .ToList();

        }

        

        


    }
}