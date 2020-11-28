using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantRater.Models;
using static RestaurantRater.Models.Restaurant;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _db = new RestaurantDbContext();
        // GET: Restaurant/Index
        public ActionResult Index()
        {
            return View (_db.Restaraunts.ToList());
        }

        //GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();

        }

        //POST: RestaurantCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaraunts.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

    }

    
}