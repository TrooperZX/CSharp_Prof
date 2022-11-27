using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HealthPlus.Core;
using HealthPlus.Core.Abstractions;
using HealthPlus.Core.DataTransferObjects;
using HealthPlusApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlusApp.Controllers
{
    public class MedPrescriptionController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
