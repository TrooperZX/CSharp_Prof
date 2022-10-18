using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using HealthPlus.Business.Services;
using HealthPlus.Core.Abstractions;
using HealthPlus.Core.DataTransferObjects;
using HealthPlusApp.Models;
using AutoMapper;

namespace HealthPlusApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;
        public AccountController(IUserService userService,
            IMapper mapper, IUserRoleService userRoleService)
        {
            _userService = userService;
            _mapper = mapper;
            _userRoleService = userRoleService;
        }
       

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // need to create role "Ordinary User" first
                var userRoleId = await _userRoleService.GetRoleIdByNameAsync("Ordinary User");
                var userDto = _mapper.Map<UserDto>(model);
                if (userDto != null && userRoleId != null)
                {
                    userDto.RoleId = userRoleId.Value;
                    var result = await _userService.RegisterUser(userDto);
                    if (result > 0)
                    {
                        await Authenticate(model.Email);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult CheckEmail(string email)
        {
            if (email.ToLowerInvariant().Equals("test@email.com"))
            {
                return Ok(false);
            }
            return Ok(true);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var isPasswordCorrect = await _userService.CheckUserPassword(model.Email, model.Password);
            if (isPasswordCorrect)
            {
                await Authenticate(model.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }


        private async Task Authenticate(string email)
        {
            var userDto = await _userService.GetUserByEmailAsync(email);

            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userDto.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userDto.RoleName)
            };

            var identity = new ClaimsIdentity(claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
            );

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }
    }
}
