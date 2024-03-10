using LMS.Core.Data;
using LMS.Core.Repository;
using LMS.Core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService (IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public string AdminLogin(Adminuserlogin login)
        {
            var result = _authRepository.Adminlogin(login);
            if (result == null)
            {
                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345"));
                var signCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claimes = new List<Claim>
                    {
                    new Claim("email", result.Email),
                    new Claim("roleid" , result.Roleid.ToString())

                    };

                var tokenOptions = new JwtSecurityToken(
                    claims: claimes,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signCredentials
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return token;
            }
        }

        public string Login(Studentuserlogin login)
        {
            var result = _authRepository.Login(login);
            if (result == null)
            {
                return null;
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345"));
                var signCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claimes = new List<Claim>
                    {
                    new Claim("email", result.Email),
                    new Claim("roleid" , result.Roleid.ToString())

                    };

                var tokenOptions = new JwtSecurityToken(
                    claims: claimes,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signCredentials
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return token;
            }
        }
    }
}

