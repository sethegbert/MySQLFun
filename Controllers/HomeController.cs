using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySQLFun.Models;
using MySQLFun.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLFun.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository repo { get; set; }

        // Constructor
        public HomeController(IBowlersRepository temp)
        {
            // load up the repository
            repo = temp;
        }

        public IActionResult Index()
        {
            // set up our dataset, and return in the view the information from the dataset
            var blah = repo.Bowlers
                .ToList();

            return View(blah);
        }

        public IActionResult ConfirmDelete()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddBowler(int bowlerid)
        {
            ViewBag.Bowler = repo.Bowlers.ToList();

            return View(
            new Bowler
            {
                //bowler = repo.Bowlers.Single(x => x.BowlerID == bowlerid)
            }
            );
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                repo.SaveBowler(b);

                return View("ConfirmAdd", b);
            }
            else
            {
                return View(b);
            }
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Bowler = repo.Bowlers.ToList();

            ViewBag.person = repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("Index");
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            repo.SaveBowler(b);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int BowlerIdNumber)
        {
            var person = repo.Bowlers.Single(x => x.BowlerID == BowlerIdNumber);

            return View("ConfirmDelete", person);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            repo.DeleteBowler(b);

            return RedirectToAction("ConfirmDelete");
        }
    }
}
