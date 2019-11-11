using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoTest.Dto;
using ProyectoTest.ExceptionError;
using ProyectoTest.Service;
using ProyectoTest.Util;

namespace ProyectoTest.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/test")]
    [ApiController]
    [EnableCors(Constant.CORS)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _iUserService;

        public UserController(IUserService iUserService) {
            _iUserService = iUserService;
        }


        // GET api/values
        [AllowAnonymous]
        [HttpPost("user/token")]
        public ActionResult<UserDto> PostUserToken(LoginDto loginDto)
        {
            UserDto userDto = new UserDto();
            try
            {
                userDto = _iUserService.generateKey(loginDto);
                if (userDto == null)
                    return BadRequest(new { message = "Username or password is incorrect" });
            }
            catch (ExceptionGeneric exception)
            {
                Console.WriteLine(exception.Message);

            }
            return Ok(userDto);
        }

        // GET api/values
        [HttpGet("user")]
        public ActionResult<UserDto> getUser()
        {
            UserDto userDto = new UserDto();
            try
            {
                userDto = _iUserService.getUser();
                
            }
            catch (ExceptionGeneric exception)
            {
                Console.WriteLine(exception.Message);

            }
            return Ok(userDto);
        }
    }
}