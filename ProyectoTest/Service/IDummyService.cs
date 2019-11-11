using ProyectoTest.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTest.Service
{
    public interface IDummyService
    {
        UserDto Authenticate(LoginDto loginDto);

        UserDto getUser();

    }
}
