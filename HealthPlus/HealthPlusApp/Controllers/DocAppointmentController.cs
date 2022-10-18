using Microsoft.AspNetCore.Mvc;
using HealthPlus.DataBase;
using HealthPlus.Core;
using HealthPlus.Core.Abstractions;
using HealthPlus.Core.DataTransferObjects;
using HealthPlusApp.Models;
using AutoMapper;

namespace HealthPlusApp.Controllers
{
    public class DocAppointmentController : Controller
    {
        private readonly IDocAppointmentService _DocAppointmentService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public DocAppointmentController(IDocAppointmentService DocAppointmentService,
            IMapper mapper, IUserService userService)
        {
            _DocAppointmentService = DocAppointmentService;
            _mapper = mapper;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocAppointment(DocAppointmentModel model)
        {
            if (ModelState.IsValid)
            {
                // userId берется из залогиненного акка
                // var userId = await _userService.GetIdByNameAsync("Ordinary User");

                //var userDto = _mapper.Map<DocAppointmentDto>(model);
                //if (userDto != null && userRoleId != null)
                //{
                //    userDto.RoleId = userRoleId.Value;
                //    var result = await _userService.RegisterUser(userDto);
                //    if (result > 0)
                //    {
                //        await Authenticate(model.Email);
                //        return RedirectToAction("Index", "Home");
                //    }
                //}
            }
            return View(model);

        }
    }
}
