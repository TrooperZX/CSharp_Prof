using Microsoft.AspNetCore.Mvc;

namespace HealthPlusApp.Controllers
{
    public class VaccinationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
