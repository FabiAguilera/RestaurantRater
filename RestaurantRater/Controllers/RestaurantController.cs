﻿using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _db = new RestaurantDbContext();
        // GET: Restaurant
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");   // if ModelState is not IsValid (false), then we return to the View.
            }
            return View(restaurant);    // If ModelState is IsValid (true), then we add and save changes and return a new method called RedirectToCTion("Index"); which takes the string name of another action (the Index method) and redirects the code to that action. Here, the return kicks us over to the Index action and takes us to the Index view.
        }
    }
}