using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class SuperHeroes : Controller
    {
        // GET: SuperHeroes
        public ActionResult Index()
        {
            return View();
        }
    }
}