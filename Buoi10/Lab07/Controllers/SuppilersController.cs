using Lab07.Data;
using Lab07.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab07.Controllers
{
	public class SuppilersController : Controller
	{
		private readonly MvcNiieLabContext _context;

		public SuppilersController(MvcNiieLabContext context)
		{
			_context = context;
		}

		public IActionResult Index(string? TuKhoa)
		{
			var data = _context.Suppliers.AsQueryable();
			if (TuKhoa != null)
			{
				data = data.Where(s => s.Name.Contains(TuKhoa) || s.Email.Contains(TuKhoa) || s.Phone.Contains(TuKhoa));
			}
			return View(data.ToList());
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Supplier model, IFormFile Logo)
		{
			try
			{
				if (Logo != null)
				{
					model.Logo = MyTool.UploadImageToFolder(Logo, "Suppliers");
				}
				_context.Add(model);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ViewBag.Exception = "Lỗi: " + ex.Message;
				return View();
			}
		}
	}
}
