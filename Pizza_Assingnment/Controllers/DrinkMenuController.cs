using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_Assingnment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Controllers
{
    public class DrinkMenuController : Controller
    {
        DrinkMenuDataAccessLayer drinkMenuDataAccessLayer = null;
        public DrinkMenuController()
        {
            drinkMenuDataAccessLayer = new DrinkMenuDataAccessLayer();
        }

        // GET: DrinkMenuController
        public ActionResult Index()
        {
            IEnumerable<DrinkMenu> drinkMenus = drinkMenuDataAccessLayer.GetAllDrinkMenu();
            return View(drinkMenus);
        }

        // GET: DrinkMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DrinkMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrinkMenuController/Create
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

        // GET: DrinkMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DrinkMenuController/Edit/5
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

        // GET: DrinkMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DrinkMenuController/Delete/5
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
