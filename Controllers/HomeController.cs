using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using crudelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace crudelicious.Controllers
{
    public class HomeController : Controller
    {
        private DishesContext dbContext;
        public HomeController(DishesContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //show 5 most recently posted dishes 
            List<Dishes> mostRecent = dbContext.Dishes
                .OrderByDescending(d => d.CreatedAt)
                .Take(5)
                .ToList();
            return View(mostRecent);
        }

        [HttpGet]
        [Route("new")]
        public IActionResult New() => View();


        [HttpPost]
        [Route("addDish")]
        public IActionResult addDish(Dishes newDish)
        {
            dbContext.Add(newDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("{Id}")]
        public IActionResult Show(int Id)
        {
            Dishes oneDish = dbContext.Dishes.FirstOrDefault(dish => dish.Id == Id);
            System.Console.WriteLine(oneDish.Name);
            return View(oneDish);
        }

        [HttpGet("edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            Dishes oneDish = dbContext.Dishes.FirstOrDefault(dish => dish.Id == Id);
            System.Console.WriteLine(oneDish.Name);

            return View(oneDish);
        }

        [HttpPost]
        [Route("editDish")]
        public IActionResult editDish(Dishes updatedDish)
        {
            System.Console.WriteLine("the updated dish:");
            System.Console.WriteLine(updatedDish.Id);
            updatedDish.UpdatedAt = DateTime.Now;
            dbContext.Dishes.Update(updatedDish);
            dbContext.SaveChanges();
            return Redirect($"{updatedDish.Id}");
        }

        [HttpGet("delete/{Id}")]
        public IActionResult Remove(int Id)
        {
            Dishes RetrievedDish = dbContext.Dishes.SingleOrDefault(dish => dish.Id == Id);
            dbContext.Dishes.Remove(RetrievedDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
