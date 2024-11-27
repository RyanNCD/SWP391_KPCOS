using Repository.DTOs.Auth;
using Repository.DTOs.User;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    internal class AuthService : IAuthService
    {
        public AuthService()
        {
            
        }
        public Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDto)
        {
            throw new NotImplementedException();
        }

        public Task RevokeTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
