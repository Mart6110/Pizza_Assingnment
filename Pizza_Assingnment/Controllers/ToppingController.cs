using Microsoft.AspNetCore.Http;
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

        // GET: ToppingController
        public ActionResult Index()
        {
            // Getting all the toppings
            IEnumerable<Toppings> toppings = toppingsDataAccessLayer.GetAllTopping();
            return View(toppings);
        }

        // GET: ToppingController/Details/5
        public ActionResult Details(int Id)
        {
            // Getting a specific toppings detials
            Toppings toppings = toppingsDataAccessLayer.GetToppingsData(Id);
            return View(toppings);
        }

        // GET: ToppingController/Create
        public ActionResult Create()
        {
            // Getting a view for creating a new topping
            return View();
        }

        // POST: ToppingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Toppings toppings)
        {
            // A try/catch that POST the input value 
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

        // GET: ToppingController/Edit/5
        public ActionResult Edit(int id)
        {
            Toppings toppings = toppingsDataAccessLayer.GetToppingsData(id);
            return View(toppings);
        }

        // POST: ToppingController/Edit/5
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

        // GET: ToppingController/Delete/5
        public ActionResult Delete(int id)
        {
            Toppings toppings = toppingsDataAccessLayer.GetToppingsData(id);
            return View(toppings);
        }

        // POST: ToppingController/Delete/5
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
