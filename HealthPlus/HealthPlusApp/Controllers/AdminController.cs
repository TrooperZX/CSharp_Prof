using Microsoft.AspNetCore.Mvc;
using HealthPlus.DataBase;
using HealthPlus.Core;
using HealthPlus.Core.Abstractions;
using HealthPlus.Core.DataTransferObjects;
using HealthPlusApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Serilog;
using HealthPlusApp.Controllers;

namespace HealthPlusApp.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Ordinary User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
