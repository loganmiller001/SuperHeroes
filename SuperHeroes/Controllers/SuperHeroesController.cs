using SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class SuperHeroesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.SuperHero.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.SuperId = new SelectList(db.SuperHero, "SuperId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name, AlterEgo, PrimaryPower, SecondaryPower, CatchPhrase")]SuperHero superHero)
        {
            if (ModelState.IsValid)
            {
                db.SuperHero.Add(superHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(superHero);
        }

        public ActionResult Delete(int id)
        {
            var deleteHero = (from h in db.SuperHero
                              where h.SuperId == id
                              select h).FirstOrDefault();
            return View(deleteHero);
        }

        [HttpPost]
        public ActionResult Edit(int id, SuperHero superHero)
        {
            SuperHero updatedHero = (from s in db.SuperHero
                                     where s.SuperId == id
                                     select s).FirstOrDefault();
            updatedHero.Name = superHero.Name;
            updatedHero.PrimaryPower = superHero.PrimaryPower;
            updatedHero.SecondaryPower = superHero.SecondaryPower;
            updatedHero.AlterEgo = superHero.AlterEgo;
            updatedHero.CatchPhrase = superHero.CatchPhrase;
            db.SaveChanges();

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuperHero superHero = db.SuperHero.Find(id);
            if (ModelState.IsValid)
            {
                db.SuperHero.Remove(superHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(superHero);

        }

        public ActionResult Details(int id)
        {
            SuperHero display = (from d in db.SuperHero
                                where d.SuperId == id
                                select d).FirstOrDefault();
            SuperHero superHero = db.SuperHero.Find(id);
            display.Name = superHero.Name;
            display.PrimaryPower = superHero.PrimaryPower;
            display.SecondaryPower = superHero.SecondaryPower;
            display.AlterEgo = superHero.AlterEgo;
            display.CatchPhrase = superHero.CatchPhrase;
            return View(display);

        }
    }
}