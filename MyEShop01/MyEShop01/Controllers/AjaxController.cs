using Microsoft.AspNetCore.Mvc;
using MyEShop01.Entities;
using MyEShop01.Models;

namespace MyEShop01.Controllers
{
	public class AjaxController : Controller
	{
		private readonly MyEshopContext _context;

		public AjaxController(MyEshopContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Search()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Search(string keyword)
		{
			var dsHangHoa = _context.HangHoas.Where(p => p.TenHh.Contains(keyword));

			var data = dsHangHoa.Select(hh => new KetQuaTimKiemVM
			{
				MaHh = hh.Id,
				TenHh = hh.TenHh,
				Hinh = hh.Hinh,
				DonGia = hh.DonGia.Value,
				NgaySX = hh.NgaySx,
				Loai = hh.MaLoaiNavigation.TenLoai
			}).ToList();
			return PartialView("TimKiemPartial", data);
		}


	}
}
