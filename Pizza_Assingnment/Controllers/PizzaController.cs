using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_Assingnment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Controllers
{
    public class PizzaController : Controller
    {
        PizzaDataAccessLayer PizzaDataAccessLayer = null;
        public PizzaController()
        {
            PizzaDataAccessLayer = new PizzaDataAccessLayer();
        }

        // GET: PizzaController
        public ActionResult Index()
        {
            IEnumerable<Pizza> pizzas = PizzaDataAccessLayer.GetAllPizza();
            return View(pizzas);
        }

        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            Pizza pizza = PizzaDataAccessLayer.GetPizzaData(id);
            return View(pizza);
        }

        // GET: PizzaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizza pizza)
        {
            try
            {
                PizzaDataAccessLayer.AddPizza(pizza);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id)
        {
            Pizza pizza = PizzaDataAccessLayer.GetPizzaData(id);
            return View();
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pizza pizza)
        {
            try
            {
                PizzaDataAccessLayer.UpdatePizza(pizza);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza pizza = PizzaDataAccessLayer.GetPizzaData(id);
            return View(pizza);
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Pizza pizza)
        {
            try
            {
                PizzaDataAccessLayer.DeletePizza(pizza.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
