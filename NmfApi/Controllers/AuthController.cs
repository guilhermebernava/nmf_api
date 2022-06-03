using System;
using Infra.Context;
using Infra.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NmfApi.Interfaces;
using Services.Services;

namespace NmfApi.Controllers
{
    public class AuthController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration, UserContext db) : base(db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }




        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVm vm)
        {
            var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password,
                 isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok(JwtServices.BuildToken(vm, _configuration));
            }

            ModelState.AddModelError(string.Empty, "login inválido.");
            return BadRequest(ModelState);

        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] LoginVm vm)
        {
            var user = new ApplicationUser()
            {
                Email = vm.Email,
                UserName = vm.Email,
            };
            var result = await _userManager.CreateAsync(user, vm.Password);

            if (result.Succeeded)
            {
                return Ok(JwtServices.BuildToken(vm, _configuration));
            }

            return BadRequest("Usuário ou senha inválidos");

        }


    }
}

