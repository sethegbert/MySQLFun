using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySQLFun.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLFun.Controllers
{
    public class HomeController : Controller
    {
        private BowlerDbContext context { get; set; }
        // Constructor
        public HomeController(BowlerDbContext temp)
        {
            // load up the repository
            context = temp;
        }

        // we are setting it up so the id is set to 0 to load all records. This will allow 
        // us to better control the problems with "id"
        public IActionResult Index(int id=0)
        {
            // set up our dataset, and return in the view the information from the dataset
            if(id == 0)
            {
                var bowlers = context.bowlers.OrderBy(x => x.BowlerLastName).ToList();
                ViewBag.Teams = context.teams.ToList();
                ViewBag.CurrentTeamID = id;
                return View(bowlers);
            }
            else
            {
                var bowlers = context.bowlers.Include(x => x.Team).Where(x => x.TeamID == id).ToList();
                ViewBag.Teams = context.teams.ToList();
                ViewBag.CurrentTeamID = id;
                return View(bowlers);
            }
        }

        public IActionResult ConfirmDelete()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddBowler()
        {
            ViewBag.Teams = context.teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            // use validation
            if (ModelState.IsValid)
            {
                context.Add(b);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teams = context.teams.ToList();
                return View(b);
            }
        }

        [HttpGet]
        public IActionResult Edit()
        {
            int id = Convert.ToInt32(RouteData.Values["id"]);
            var bowler = context.bowlers.Single(x => x.BowlerID == id);
            ViewBag.Teams = context.teams.ToList();
            return View("AddBowler", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            // validation again
            if (ModelState.IsValid)
            {
                context.Update(b);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teams = context.teams.ToList();
                return View("AddBowler", b);
            }
        }

        [HttpGet]
        public IActionResult Delete()
        {
            int id = Convert.ToInt32(RouteData.Values["id"]);
            var bowler = context.bowlers.Single(x => x.BowlerID == id);

            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            context.Remove(b);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
