using Lab07.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace Lab07.Controllers
{
	public class ProductsController : Controller
	{
		private readonly MvcNiieLabContext _context;

		public ProductsController(MvcNiieLabContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var data = _context.Products
				.Include(p => p.Category)
				.Include(p => p.Supplier);
			return View(data.ToList());
		}


		#region Create_Product
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Categories= new SelectList(
				_context.Categories.ToList(),
				"Id", "NameVn");
			ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product model)
		{
			ViewBag.Categories = new SelectList(
				_context.Categories.ToList(),
				"Id", "NameVn");
			ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name");
			return View();
		}
		#endregion
	}
}
