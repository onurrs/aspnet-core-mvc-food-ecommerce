using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
	public class FoodController : Controller
	{
		Context c = new Context();
        FoodRepository foodRepository = new FoodRepository();

        public IActionResult Index(int page = 1)
		{
			var user = TempData["User"] as string;
			ViewBag.message = user;
			return View(foodRepository.TList("Category").ToPagedList(page,5));
		}

		[HttpGet]
		public IActionResult AddFood()
		{
			List<SelectListItem> values = (from x in c.Categories.ToList()
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryID.ToString(),
										   }).ToList();
			ViewBag.values = values;
			return View();
		}

		[HttpPost]
		public IActionResult AddFood(Food p)
		{
            Console.WriteLine("SSS");
            foodRepository.TAdd(p);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteFood(int id)
		{
			foodRepository.TDelete(new Food { FoodID = id});
			return RedirectToAction("Index");
		}

		public IActionResult FoodGet(int id)
		{
			var x = foodRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.values = values;
            Food f = new Food { 
				FoodID = x.FoodID,
				CategoryID = x.CategoryID,
				FoodName = x.FoodName,
				Price = x.Price,
				Stock = x.Stock,
				Description = x.Description,
				ImageURL = x.ImageURL,
			};
			return View(f);
		}

		[HttpPost]
		public IActionResult FoodUpdate(Food p)
		{
			var x = foodRepository.TGet(p.FoodID);
			x.FoodName = p.FoodName;
			x.Price = p.Price;
			x.Stock = p.Stock;
			x.Description = p.Description;
			x.ImageURL = p.ImageURL;
			x.CategoryID = p.CategoryID;
			foodRepository.TUpdate(x);

			return RedirectToAction("Index");
		}

    }
}
	