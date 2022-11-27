using Microsoft.AspNetCore.Mvc;
using HealthPlusApp.Models;
using AutoMapper;
using HealthPlus.Business.Services;
using HealthPlus.Core;
using HealthPlus.Core.DataTransferObjects;
using HealthPlus.Core.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Serilog;
using HealthPlusApp.Controllers;
using HealthPlus.DataBase;


namespace HealthPlusApp.Controllers
{
    public class VaccineController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVaccineService _vaccineService;
        private readonly IUserService _userService;
         

        public VaccineController(IMapper mapper, IVaccineService vaccineService
            ,IUserService userService)
        {
            _mapper = mapper;
            _vaccineService = vaccineService;
            _userService = userService;
        }

        [Authorize(Roles = "Ordinary User")]
        public IActionResult Index()
        {
            return View();
        }

        // user request vaccine view for creation
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // user sent vaccine data for creation
        [HttpPost]
        public async Task<IActionResult> Create(VaccineModel model)
        {
            try
            {
                if (model != null)
                {
                    model.Id = Guid.NewGuid();
                    var dto = _mapper.Map<VaccineDto>(model);
                    var result = await _vaccineService.CreateVaccineAsync(dto);
                    return RedirectToAction("UserRole", "Index");
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

        // user request vaccine data for editing
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id != Guid.Empty)
            {
                var vaccineDto = await _vaccineService.GetVaccineByIdAsync(id);
                if (vaccineDto == null)
                {
                    return BadRequest();
                }

                var editModel = _mapper.Map<VaccineModel>(vaccineDto);

                return View(editModel);
            }

            return BadRequest();
        }

        // user send vaccine data for editing
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(VaccineModel model)
        {
            try
            {
                if (model != null)
                {
                    var dto = _mapper.Map<VaccineDto>(model);

                    await _vaccineService.UpdateVaccineAsync(model.Id, dto);

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

        // delete vaccine
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _vaccineService.DeleteVaccineById(id);
                return RedirectToAction("Index", "DocAppointment");
            }

            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return StatusCode(500);
            }
        }
    }
}
