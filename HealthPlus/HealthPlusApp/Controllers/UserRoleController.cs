using Microsoft.AspNetCore.Mvc;
using HealthPlusApp.Models;
using AutoMapper;
using HealthPlus.Business.Services;
using HealthPlus.Core;
using HealthPlus.Core.DataTransferObjects;
using HealthPlus.Core.Abstractions;


namespace HealthPlusApp.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IMapper mapper, IUserRoleService userRoleService)
        {
            _mapper = mapper;
            _userRoleService = userRoleService;
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
        public async Task<IActionResult> Create(UserRoleModel model)
        {
            try
            {
                if (model != null)
                {
                    model.Id = Guid.NewGuid();
                    var dto = _mapper.Map<UserRoleDto>(model);
                    var result = await _userRoleService.CreateUserRoleAsync(dto);
                    return RedirectToAction("UserRole","Index");
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
