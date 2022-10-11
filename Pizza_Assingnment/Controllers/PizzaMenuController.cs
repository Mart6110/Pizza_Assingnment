using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_Assingnment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Controllers
{
    public class PizzaMenuController : Controller
    {
        PizzaMenuDataAccessLayer pizzaMenuDataAccessLayer = null;
        public PizzaMenuController()
        {
            pizzaMenuDataAccessLayer = new PizzaMenuDataAccessLayer();
        }

        // GET: PizzaMenuController
        public ActionResult Index()
        {
            IEnumerable<PizzaMenu> pizzaMenus = pizzaMenuDataAccessLayer.GetAllPizzaMenu();
            return View(pizzaMenus);
        }

        // GET: PizzaMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PizzaMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PizzaMenuController/Create
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

        // GET: PizzaMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PizzaMenuController/Edit/5
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

        // GET: PizzaMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PizzaMenuController/Delete/5
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
