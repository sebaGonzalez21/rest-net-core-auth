using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectoTest.Dto;
using ProyectoTest.Service;
using ProyectoTest.Util;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTest.Dummy
{
    public class UserDummy : IDummyService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<UserDto> _usersList = new List<UserDto>
        {
            new UserDto { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" },
            new UserDto { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = null }
        };

        public UserDummy(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public UserDto Authenticate(LoginDto loginDto)
        {
            UserDto userDto = null;
            try
            {
                userDto = _usersList.SingleOrDefault(x => x.Username == loginDto.UserNameDto && x.Password == loginDto.UserPasswordDto);

                // return null if user not found
                if (userDto == null)
                    return null;
                /*
                 // authentication successful so generate jwt token
                 var tokenHandler = new JwtSecurityTokenHandler();
                 //var name = Configuration.GetConnectionString(Constant.SECRET);
                 var key = Encoding.ASCII.GetBytes(Configuration.GetConnectionString(Constant.SECRET));
                 var tokenDescriptor = new SecurityTokenDescriptor
                 {
                     Subject = new ClaimsIdentity(new Claim[]
                     {
                     new Claim(ClaimTypes.Name, userDto.Id.ToString())
                     }),
                     Expires = DateTime.UtcNow.AddMinutes(15),
                     SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                 };
                 var token =tokenHandler.CreateToken(tokenDescriptor);
                 userDto.Token = tokenHandler.WriteToken(token);

                 // remove password before returning*/
                //Set issued at date

                /*
                DateTime issuedAt = DateTime.UtcNow;
                //set the time when it expires
                DateTime expires = DateTime.UtcNow.AddDays(7);

                //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
                var tokenHandler = new JwtSecurityTokenHandler();

                //create a identity and add claims to the user which we want to log in
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, loginDto.UserNameDto)
                 });

                const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
                var now = DateTime.UtcNow;
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
                var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


                //create the jwt
                var token =
                    (JwtSecurityToken)
                        tokenHandler.CreateJwtSecurityToken(
                            subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
                var tokenString = tokenHandler.WriteToken(token);*/

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                //var name = Configuration.GetConnectionString(Constant.SECRET);
                var key = Encoding.ASCII.GetBytes(Configuration.GetConnectionString(Constant.SECRET));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                     new Claim(ClaimTypes.Name, userDto.Username.ToString()),
                     new Claim(ClaimTypes.PrimarySid, userDto.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                userDto.Token = tokenHandler.WriteToken(token);

                userDto.Password = null;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return userDto;
        }

        private object GetRandomBytes(int v)
        {
            throw new NotImplementedException();
        }

        public UserDto getUser()
        {
            var user = _usersList.SingleOrDefault(x => x.Password == null);

            return user;
        }

    }
}
