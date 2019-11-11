using ProyectoTest.Dto;
using ProyectoTest.Dummy;
using ProyectoTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTest.Imp
{
    public class ImpUser : IUserService
    {
        private readonly IDummyService _iDummyService;
        public ImpUser(IDummyService iDummyService) {
            _iDummyService = iDummyService;
        }

        public UserDto generateKey(LoginDto loginDto)
        {
            UserDto userDtoLocal = new UserDto();
            try
            {
                userDtoLocal = _iDummyService.Authenticate(loginDto);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return userDtoLocal;
        }

        public UserDto getUser()
        {
            UserDto userDtoLocal = new UserDto();
            try
            {
                userDtoLocal = _iDummyService.getUser();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return userDtoLocal;
        }
    }
}
