using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_Assingnment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Controllers
{
    public class PricesController : Controller
    {
        PricesDataAccessLayer PricesDataAccessLayer = null;
        public PricesController()
        {
            PricesDataAccessLayer = new PricesDataAccessLayer();
        }

        // GET: PricesController
        public ActionResult Index()
        {
            IEnumerable<Prices> prices = PricesDataAccessLayer.GetAllPrices();
            return View(prices);
        }

        // GET: PricesController/Details/5
        public ActionResult Details(int id)
        {
            Prices prices = PricesDataAccessLayer.GetPricesData(id);
            return View(prices);
        }

        // GET: PricesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PricesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prices prices)
        {
            try
            {
                PricesDataAccessLayer.AddPrice(prices);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: PricesController/Edit/5
        public ActionResult Edit(int id)
        {
            Prices prices = PricesDataAccessLayer.GetPricesData(id);
            return View(prices);
        }

        // POST: PricesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Prices prices)
        {
            try
            {
                PricesDataAccessLayer.UpdatePrice(prices);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PricesController/Delete/5
        public ActionResult Delete(int id)
        {
            Prices prices = PricesDataAccessLayer.GetPricesData(id);
            return View(prices);
        }

        // POST: PricesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Prices prices)
        {
            try
            {
                PricesDataAccessLayer.DeletePrice(prices.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
