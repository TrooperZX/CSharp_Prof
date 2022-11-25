using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HealthPlusApp.Controllers
{
    public class VaccinationController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
