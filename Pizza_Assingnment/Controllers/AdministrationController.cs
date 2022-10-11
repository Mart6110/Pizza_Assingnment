using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: AdministrationController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminOverview()
        {
            return View();
        }
    }
}
