using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySuperHeroProject.Data;
using MySuperHeroProject.Models;

namespace MySuperHeroProject.Controllers
{
    public class SuperHeroController : Controller
    {

        private readonly ApplicationDbContext _context;
        private SuperHero superHero;
        private SuperHero superhero;

        public SuperHeroController(ApplicationDbContext context) 
        {
            _context = context;
        
        }
        // GET: SuperHero
        public ActionResult Index()
        {
            List<Models.SuperHero> superherolist = _context.superheroes.ToList();
            return View(superherolist);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            SuperHero superHeroDetails = _context.superheroes.Where(s => s.id == id).FirstOrDefault();
            return View(superHeroDetails);
           
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind( "id,name,alterEgo,ability, secondaryAbility, catchPhrase" )]SuperHero superhero)
        {

            // TODO: Add insert logic here
            _context.Add(superhero);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        
           
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {

            SuperHero superHeroDetails = _context.superheroes.Find(id);
            return View(superHeroDetails);
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SuperHero superHero)
        {
            try
            {
                SuperHero superHeroDetails = _context.superheroes.Find(superHero.id);
                superHeroDetails.name = superHero.name;
                superHeroDetails.ability = superHero.ability;
                superHeroDetails.secondaryAbility = superHero.secondaryAbility;
                superHeroDetails.alterEgo = superHero.alterEgo;
                superHeroDetails.catchPhrase = superHero.catchPhrase;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));

            }
            catch
            {

                return View();

            }
           

            // TODO: Add update logic here
           // _//context.Update(superHero);
            //_//context.SaveChanges();
            //return View(superHero);
            
                
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int? id)
        {
            SuperHero superHero = _context.superheroes.Where(s => s.id == id).FirstOrDefault();
            return View(superHero);
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SuperHero superHero)
        {
            try
            {
                _context.superheroes.Remove(superHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }  
    }
}