
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using chefndish.Models;

namespace chefndish.Controllers
{
   public class HomeController : Controller
    {
        private ChefContext dbContext;
        public HomeController(ChefContext context)
        {
            dbContext = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(dish => dish.Dishes).ToList();
            ViewBag.allchefs = AllChefs;
            return View();
        }

        [HttpGet]
        [Route("Dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(chef => chef.Creator).ToList();
            ViewBag.alldishes = AllDishes;
            return View("Dishes");
        }
        [HttpGet]
        [Route("AddChefView")]

        public IActionResult AddChefView()
        {
            return View("AddChef");
        }
        [HttpGet]
        [Route("AddDishView")]
        public IActionResult AddDishView()
        {
            List<Chef> AllChefs = dbContext.Chefs.ToList();
            ViewBag.allchefs = AllChefs;
            return View("AddDish");
        }
        [HttpPost]
        [Route("AddChef")]
        public IActionResult AddChef(Chef chef)
        {
            if(ModelState.IsValid)
            {
                if(chef.Birthday >= DateTime.Today)
                {
                    ModelState.AddModelError("Birthday", "Birthday must be from the past!");
                    return View("AddChef");
                }
                Chef newChef = new Chef
                {
                    FirstName = chef.FirstName,
                    LastName = chef.LastName,
                    Birthday = chef.Birthday,
                };
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddChef");
            }
        }
        [HttpPost]
        [Route("AddDish")]
        public IActionResult AddDish(Dish dish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("AddDishView");
            }
            else
            {
                List<Chef> AllChefs = dbContext.Chefs.ToList();
                ViewBag.allchefs = AllChefs;
                return View("AddDish", dish);
            }
        }
        }
    }


   









