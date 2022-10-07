﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_Assingnment.Models;
using System.Collections;
using System.Collections.Generic;

namespace Pizza_Assingnment.Controllers
{
    public class ToppingController : Controller
    {
        ToppingsDataAccessLayer toppingsDataAccessLayer = null;
        public ToppingController()
        {
            toppingsDataAccessLayer = new ToppingsDataAccessLayer();
        }

        // GET: ToppingController1
        public ActionResult Index()
        {
            IEnumerable<Toppings> toppings = toppingsDataAccessLayer.GetAllTopping();
            return View(toppings);
        }

        // GET: ToppingController1/Details/5
        public ActionResult Details(int Id)
        {
            Toppings toppings = toppingsDataAccessLayer.GetToppingsData(Id);
            return View(toppings);
        }

        // GET: ToppingController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToppingController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Toppings toppings)
        {
            try
            {
                toppingsDataAccessLayer.AddTopping(toppings);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToppingController1/Edit/5
        public ActionResult Edit(int id)
        {
            Toppings toppings = toppingsDataAccessLayer.GetToppingsData(id);
            return View(toppings);
        }

        // POST: ToppingController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Toppings toppings)
        {
            try
            {
                toppingsDataAccessLayer.UpdateTopping(toppings);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToppingController1/Delete/5
        public ActionResult Delete(int id)
        {
            Toppings toppings = toppingsDataAccessLayer.GetToppingsData(id);
            return View(toppings);
        }

        // POST: ToppingController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Toppings toppings)
        {
            try
            {
                toppingsDataAccessLayer.DeleteToppings(toppings.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
