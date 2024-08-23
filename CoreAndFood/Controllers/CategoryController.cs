using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
	public class CategoryController : Controller
	{
        CategoryRepository categoryRepository = new CategoryRepository();

        public IActionResult Index()
		{
			var user = TempData["User"] as string;
			ViewBag.message = user;
			return View(categoryRepository.TList());
		}

		[HttpGet]
		public IActionResult CategoryAdd()
		{
			return View();
		}

		[HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
			categoryRepository.TAdd(p);
			return RedirectToAction("Index");
        }

		public IActionResult CategoryGet(int id)
		{
			var x = categoryRepository.TGet(id);
			Category ctx = new Category
			{
				CategoryName = x.CategoryName,
				CategoryDescription = x.CategoryDescription,
				CategoryID = x.CategoryID,
			};
			return View(ctx);
		}

		[HttpPost]
		public IActionResult CategoryUpdate(Category p)
		{
			var x = categoryRepository.TGet(p.CategoryID);
			x.CategoryName = p.CategoryName;
			x.CategoryDescription = p.CategoryDescription;
			x.Status = true;
			categoryRepository.TUpdate(x);
			return RedirectToAction("Index");
		}

		public IActionResult CategoryDelete(int id) 
		{
			var x = categoryRepository.TGet(id);
			x.Status = false;
			categoryRepository.TUpdate(x);
			return RedirectToAction("Index");
		}
    }
}
