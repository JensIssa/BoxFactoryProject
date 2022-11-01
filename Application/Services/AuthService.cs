using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.DTOs;
using Application.Helpers;
using Application.InterfacesRepos;
using Application.InterfacesServices;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly AppSettings _appSettings;
    private readonly IManagerRepository _managerRepository;
    
    public AuthService(IManagerRepository managerRepository, IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
        _managerRepository = managerRepository;
    }
    
    public string Register(LoginAndRegisterDTO dto)
    {
        try
        {
            _managerRepository.GetManagerByUsername(dto.Username);
        }
        catch (KeyNotFoundException)
        {
            var salt = RandomNumberGenerator.GetBytes(32).ToString();
            var manager = new Manager
            {
                Username = dto.Username,
                Salt = salt,
                Hash = BCrypt.Net.BCrypt.HashPassword(dto.Password + salt)
            };
            _managerRepository.CreateNewManager(manager);
            return GenerateToken(manager);
        }


        throw new Exception("Username " + dto.Username + " is already taken");
    }

    private string GenerateToken(Manager manager)
    {
       var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
       var tokenDescriptor = new SecurityTokenDescriptor()
       {
           Subject = new ClaimsIdentity(new[] { new Claim("username", manager.Username) }),
           Expires = DateTime.UtcNow.AddDays(7),
           SigningCredentials =
               new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
       };
       var tokenHandler = new JwtSecurityTokenHandler();
       return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
    }
    
    public string Login(LoginAndRegisterDTO dto)
    {
        var manager = _managerRepository.GetManagerByUsername(dto.Username);
        if (BCrypt.Net.BCrypt.Verify(dto.Password + manager.Salt, manager.Hash))
        {
            return GenerateToken(manager);
        }

        throw new Exception("Invalid login");
    }
}