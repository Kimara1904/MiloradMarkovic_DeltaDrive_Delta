using AutoMapper;
using Exceptions.Exeptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;
using MiloradMarkovic_DeltaDrive_Delta.Models;
using MiloradMarkovic_DeltaDrive_Delta.Repositories.Interfaces;
using MiloradMarkovic_DeltaDrive_Delta.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiloradMarkovic_DeltaDrive_Delta.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Passenger> _passwordHasher;

        public AuthenticationService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper,
            IPasswordHasher<Passenger> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Login(LoginDTO login)
        {
            var passengers = await _unitOfWork._passengerRepository.GetAllAsync();
            var passenger = passengers
                .Where(p => p.Email.Equals(login.Email) && _passwordHasher.VerifyHashedPassword(p, p.Password, login.Password) == PasswordVerificationResult.Success)
                .FirstOrDefault() ?? throw new NotFoundException($"There is no user with email: {login.Email} and password {login.Password}.");

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"] ?? "default"),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("PassengerId", passenger.Id.ToString()),
                        new Claim("Email", passenger.Email)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "default"));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task Register(RegisterDTO newPassenger)
        {
            var passengers = await _unitOfWork._passengerRepository.GetAllAsync();
            var passenger = passengers.Where(p => p.Email.Equals(newPassenger.Email)).FirstOrDefault();

            if (passenger != null)
            {
                throw new ConflictException(string.Format("User with email: {0} already exists.", passenger.Email));
            }

            var newPassengerData = _mapper.Map<Passenger>(newPassenger);

            var hashPassword = _passwordHasher.HashPassword(newPassengerData, newPassenger.Password);
            newPassengerData.Password = hashPassword;

            await _unitOfWork._passengerRepository.Insert(newPassengerData);
            await _unitOfWork.Save();
        }
    }
}
