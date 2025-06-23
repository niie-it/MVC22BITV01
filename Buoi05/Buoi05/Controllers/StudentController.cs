using Buoi05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi05.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student model, IFormFile Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    var fileName = $"{DateTime.Now.Ticks}_{Photo.Name}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Photo", fileName);
                    using (var file = new FileStream(filePath, FileMode.CreateNew))
                    {
                        Photo.CopyTo(file);
                    }
                    model.Photo = fileName;
                }
                var jsonFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student.json");
                System.IO.File.WriteAllText(jsonFile, System.Text.Json.JsonSerializer.Serialize(model));
            }
            return View();
        }
    }
}
