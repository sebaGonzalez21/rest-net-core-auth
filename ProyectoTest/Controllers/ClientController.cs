using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProyectoTest.Dto;
using ProyectoTest.ExceptionError;
using ProyectoTest.Service;
using ProyectoTest.Util;
/**
* Sebastian Gonzalez
* 
* */
namespace ProyectoTest.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/test")]
    [ApiController]
    [EnableCors(Constant.CORS)]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _iClientService;

        public ClientController(IClientService iClientService) {
            _iClientService = iClientService;
        }


        // GET api/values
        [HttpGet("users/{email}/clients")]
        public ActionResult<ClientListDto> GetClientList(string email)
        {
            ClientListDto clientListDto = new ClientListDto();
            try
            {
                clientListDto = _iClientService.listClientByEmail(email);
            }
            catch (ExceptionGeneric exception) {
                Console.WriteLine(exception.Message);

            }
            return clientListDto;
        }

        // GET api/values/5
        [HttpGet("clients/{id}/projects")]
        public ActionResult<string> GetProyects(int id)
        {
            return "value";
        }

        // GET api/values/5
        [HttpPut("clients/{id}/entities/{idEntities}")]
        public ActionResult<ClientDto> GetClients(int id, int idEntities, [FromBody] ClientDto clientDto)
        {
            ClientDto clientDtoLocal = new ClientDto();
            try
            {
                clientDtoLocal = _iClientService.clientByEntities(id,idEntities);
            }
            catch (ExceptionGeneric exception)
            {
                Console.WriteLine(exception.Message);

            }
            return clientDtoLocal;
        }

        // POST api/values
        [HttpPost("clients/{id}/entities")]
        public void Post([FromBody] string value)
        {

        }

    }
}
