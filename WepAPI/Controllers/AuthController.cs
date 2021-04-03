using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userIsExists = _authService.UserExists(userForRegisterDto.Email);
            if (userIsExists.Success)
            {
                return BadRequest(userIsExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            var accessToken = _authService.CreateAccessToken(registerResult.Data);

            if (accessToken.Success)
            {
                return Ok(accessToken);
            }

            return BadRequest(accessToken.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(UserForUpdateDto userForUpdateDto)
        {
            // defensive :)
            var userIsExists = _authService.UserExists(userForUpdateDto.Email);
            if (userIsExists.Success)
            {
                return BadRequest(userIsExists.Message);
            }

            var updateResult = _authService.Update(userForUpdateDto);
           

            if (updateResult.Success)
            {
                return Ok(updateResult);
            }

            return BadRequest(updateResult.Message);
        }

        [HttpGet("getuserbyemail")]
        public IActionResult  GetUserByEmail(string email)
        {
            var result = _authService.GetUserByEmail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
