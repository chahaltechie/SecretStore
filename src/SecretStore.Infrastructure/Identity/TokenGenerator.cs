using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Authorization.Interfaces;
using Application.Token.Interfaces;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IUserValidator<ApplicationUserContext> _userValidator;

        public TokenGenerator(IUserValidator<ApplicationUserContext> userValidator)
        {
            _userValidator = userValidator;
        }

        public async Task<Token> GenerateTokenAsync(string username, string password)
        {
            var userContext = await _userValidator.ValidateUser(username, password);
            if (string.IsNullOrEmpty(userContext.Id))
                throw new InvalidCredentialException("Invalid username or password");

            var tokenExp = new DateTimeOffset(DateTime.Now).AddDays(1).ToUnixTimeSeconds().ToString();
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userContext.Name),
                new Claim(ClaimTypes.NameIdentifier, userContext.Id),
                new Claim(JwtRegisteredClaimNames.Exp,
                    tokenExp),
                new Claim(ClaimTypes.Role, userContext.Role.Name)
            };

            var token = new JwtSecurityToken(new JwtHeader(new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyWhichNoOneCanHack")),
                SecurityAlgorithms.HmacSha256)), new JwtPayload(claims));
            return new Token
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = "REFRESH",
                UserName = userContext.Name,
                Expiry = tokenExp
            };
        }
    }
}