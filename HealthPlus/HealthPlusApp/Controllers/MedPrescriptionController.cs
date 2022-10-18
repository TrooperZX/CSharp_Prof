using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HealthPlusApp.Controllers
{
    public class MedPrescriptionController : Controller
    {
        [Authorize] // требование авторизации
        public IActionResult Index()
        {
            return View();
        }
    }
}
