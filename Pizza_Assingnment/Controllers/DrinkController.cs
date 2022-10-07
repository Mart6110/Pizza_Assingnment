using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_Assingnment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Controllers
{
    public class DrinkController : Controller
    {
        DrinkDataAccessLayer drinkDataAccessLayer = null;
        public DrinkController()
        {
            drinkDataAccessLayer = new DrinkDataAccessLayer();
        }

        // GET: DrinkController
        public ActionResult Index()
        {
            IEnumerable<Drink> drinks = drinkDataAccessLayer.GetAllDrink();
            return View(drinks);
        }

        // GET: DrinkController/Details/5
        public ActionResult Details(int id)
        {
            Drink drink = drinkDataAccessLayer.GetDrinkData(id);
            return View(drink);
        }

        // GET: DrinkController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrinkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Drink drink)
        {
            try
            {
                drinkDataAccessLayer.AddDrink(drink);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DrinkController/Edit/5
        public ActionResult Edit(int id)
        {
            Drink drink = drinkDataAccessLayer.GetDrinkData(id);
            return View(drink);
        }

        // POST: DrinkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Drink drink)
        {
            try
            {
                drinkDataAccessLayer.UpdateDrink(drink);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DrinkController/Delete/5
        public ActionResult Delete(int id)
        {
            Drink drink = drinkDataAccessLayer.GetDrinkData(id);
            return View(drink);
        }

        // POST: DrinkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Drink drink)
        {
            try
            {
                drinkDataAccessLayer.DeleteDrink(drink.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
