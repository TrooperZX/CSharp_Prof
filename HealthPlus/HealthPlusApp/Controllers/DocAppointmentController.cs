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
    public class DocAppointmentController : Controller
    {
        private readonly IDocAppointmentService _docAppointmentService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private int _pageSize = 10;
        public DocAppointmentController(IDocAppointmentService DocAppointmentService,
            IMapper mapper, IUserService userService)
        {
            _docAppointmentService = DocAppointmentService;
            _mapper = mapper;
            _userService = userService;
        }

        [Authorize]
        public async Task<IActionResult> Index(int page)
        {
            try
            {
                var currentUser = _userService.GetUserByEmailAsync(HttpContext.User.Identity.Name).Result;
                var docAppointments = await _docAppointmentService
                    .GetDocAppointmentByPageNumberPageSizeAndUserIdAsync(page, _pageSize, currentUser.Id);

                DocAppointmentsList docAppointmentsList = new DocAppointmentsList();
                docAppointmentsList.DocAppointments = docAppointments;
                if (docAppointmentsList.DocAppointments.Any() || !docAppointmentsList.DocAppointments.Any())
                {
                    return View(docAppointmentsList);
                }
                else
                {
                    throw new ArgumentException(nameof(page));
                }
            }
            catch (Exception e)
            {
                Log.Error($"{e.Message}. {Environment.NewLine} {e.StackTrace}");
                return BadRequest();
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        // user send data to create doc app-nt
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(DocAppointmentModel model)
        {
            try
            {
                if (model != null)
                {
                    var useremail = HttpContext.User.Identity.Name;
                    var currentUser = _userService.GetUserByEmailAsync(useremail).Result;
                    model.Id = Guid.NewGuid();
                    model.AppointmentDate = model.AppointmentDate.ToUniversalTime();
                    var dto = _mapper.Map<DocAppointmentDto>(model);
                    dto.UserId = currentUser.Id;
                    var result = await _docAppointmentService.CreateDocAppointmentAsync(dto);
                    return RedirectToAction("Index", "DocAppointment");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // user request doc appointment for editing
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id != Guid.Empty)
            {
                var docAppointmentDto = await _docAppointmentService.GetDocAppointmentByIdAsync(id);
                if (docAppointmentDto == null)
                {
                    return BadRequest();
                }

                var editModel = _mapper.Map<DocAppointmentModel>(docAppointmentDto);

                return View(editModel);
            }

            return BadRequest();
        }

        // user send doc appointment for editing
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(DocAppointmentModel model)
        {
            try
            {
                if (model != null)
                {
                    var dto = _mapper.Map<DocAppointmentDto>(model);

                    await _docAppointmentService.UpdateDocAppointmentAsync(model.Id, dto);

                    return RedirectToAction("Index", "DocAppointment");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return StatusCode(500);
            }
        }

        // delete doc appointment
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _docAppointmentService.DeleteDocAppointmentById(id);
                return RedirectToAction("Index", "DocAppointment");
            }

            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return StatusCode(500);
            }
            return RedirectToAction("Index", "DocAppointment");
        }
    }
}
