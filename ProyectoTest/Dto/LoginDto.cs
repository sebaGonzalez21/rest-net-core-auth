using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTest.Dto
{
    public class LoginDto
    {
        private string _userNameDto;
        private string _userPasswordDto;

        public string UserNameDto { get => _userNameDto; set => _userNameDto = value; }
        public string UserPasswordDto { get => _userPasswordDto; set => _userPasswordDto = value; }
    }
}
