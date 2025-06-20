using Buoi04.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi04.Controllers
{
	public class StudentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Manage(Student model, string LoaiFile)
		{
			//xử

			return View(model);
		}
	}
}
