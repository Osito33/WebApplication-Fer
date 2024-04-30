using Microsoft.AspNetCore.Mvc;
namespace WebApplication_Fer.Controllers
{
    public class CurriculumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
