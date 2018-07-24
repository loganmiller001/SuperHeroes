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
        public ActionResult Create(SuperHero superHero)
        {
            if (ModelState.IsValid)
            {
                db.SuperHeroes.Add(superHero);
                db.SaveChanges();
            }

            return View(superHero);
        }

        public ActionResult Update(SuperHero superHero)
        {
            SuperHero updatedHero = (from s in db.SuperHeroes
                                     where s.SuperId == superHero.SuperId
                                     select s).FirstOrDefault();
            updatedHero.Name = superHero.Name;
            updatedHero.PrimaryPower = superHero.PrimaryPower;
            updatedHero.SecondaryPower = superHero.SecondaryPower;
            updatedHero.AlterEgo = superHero.AlterEgo;
            updatedHero.CatchPhrase = superHero.CatchPhrase;
            db.SaveChanges();

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