﻿using SuperHeroes.Models;
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
        // GET: SuperHeroes
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

        public ActionResult Edit(SuperHero superHero)
        {
            SuperHero updatedHero = (from s in db.SuperHero
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

        public ActionResult Delete(SuperHero superHero)
        {
            SuperHero hero = (from h in db.SuperHero
                              where h.SuperId == superHero.SuperId
                              select h).FirstOrDefault();
            db.SuperHero.Remove(hero);
            db.SaveChanges();
            return View();
        }
    }
}