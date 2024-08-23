using CoreAndFood.Data;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
			var user = TempData["User"] as string;
			ViewBag.message = user;
			return View();
        }

        public IActionResult Index2()
        {
			var user = TempData["User"] as string;
			ViewBag.message = user;
			return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(FoodList());
        }

        public List<Class2> FoodList()
        {
            List<Class2> cs = new List<Class2>();

            using (var c = new Context())
            {
                cs = c.Foods.Select(x => new Class2
                {
                    foodname = x.FoodName,
                    stock = x.Stock,
                }).ToList();
            }

            return cs;
        }

        public IActionResult Statistics()
        {
            Context c = new Context();

            var d1 = c.Foods.Count();
            ViewBag.d1 = d1;

            var d2 = c.Categories.Count();
            ViewBag.d2 = d2;

            var fruitID = c.Categories.Where(y => y.CategoryName == "Fruits").Select(z => z.CategoryID).FirstOrDefault();
            var vegetableID = c.Categories.Where(y => y.CategoryName == "Vegetables").Select(z => z.CategoryID).FirstOrDefault();
            var legumeID = c.Categories.Where(y => y.CategoryName == "Legumes").Select(z => z.CategoryID).FirstOrDefault();

            var d3 = c.Foods.Where(x => x.CategoryID == fruitID).Count();
            ViewBag.d3 = d3;

            var d4 = c.Foods.Where(x => x.CategoryID == vegetableID).Count();
            ViewBag.d4 = d4;

            var d5 = c.Foods.Where(x => x.CategoryID == legumeID).Count();
            ViewBag.d5 = d5;

            var d6 = c.Foods.Sum(x => x.Stock);
            ViewBag.d6 = d6;

            var d7 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d7 = d7;

            var d8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d8 = d8;

            var d9 = c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d9 = d9;

            var d10 = c.Foods.Where(x => x.CategoryID == fruitID).Sum(y => y.Stock);
            ViewBag.d10 = d10;

            var d11 = c.Foods.Where(x => x.CategoryID == vegetableID).Sum(y => y.Stock);
            ViewBag.d11 = d11;

            var d12 = c.Foods.Where(x => x.CategoryID == legumeID).Sum(y => y.Stock);
            ViewBag.d12 = d12;

            return View();
        }
    }
}
