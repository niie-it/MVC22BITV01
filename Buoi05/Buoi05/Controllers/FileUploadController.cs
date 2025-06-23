using Microsoft.AspNetCore.Mvc;

namespace Buoi05.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadFile(IFormFile MyFile, string Description)
        {
            if (MyFile == null)
            {
                TempData["Message"] = "Có lỗi upload file.";
            }
            else
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", MyFile.FileName);
                using (var file = new FileStream(fullPath, FileMode.CreateNew))
                {
                    MyFile.CopyTo(file);
                }
                TempData["Message"] = "Upload file thành công.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult UploadFiles(List<IFormFile> MyFiles)
        {
            if (MyFiles == null)
            {
                TempData["Message"] = "Chưa có file để upload.";
            }
            else
            {
                foreach (var MyFile in MyFiles)
                {
                    var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", MyFile.FileName);
                    using (var file = new FileStream(fullPath, FileMode.CreateNew))
                    {
                        MyFile.CopyTo(file);
                    }
                }
                TempData["Message"] = "Upload file thành công.";
            }
            return RedirectToAction("Index");
        }
    }
}
