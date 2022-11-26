using Microsoft.AspNetCore.Mvc;
using HealthPlusApp.Models;
using AutoMapper;
using HealthPlus.Business.Services;
using HealthPlus.Core;
using HealthPlus.Core.DataTransferObjects;
using HealthPlus.Core.Abstractions;


namespace HealthPlusApp.Controllers
{
    public class VaccineController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVaccineService _vaccineService;

        public VaccineController(IMapper mapper, IVaccineService vaccineService)
        {
            _mapper = mapper;
            _vaccineService = vaccineService;
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
    }
}
