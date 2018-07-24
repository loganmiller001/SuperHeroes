using SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class SuperHeroes : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SuperHeroes
        public ActionResult Index()
        {
            return View(db.SuperHeroes.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs]
        [HttpPost]
        public ActionResult Create(SuperHeroes superHeroes)
        {
            if (ModelState.IsValid)
            {
                
                return View(superHeroes);
            }

            return View(superHeroes);
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Read()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}