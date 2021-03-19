using System;
using System.Collections.Generic;
using System.Globalization;
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

            var expires = DateTime.Now.AddMinutes(5);
            //var tokenExp = EpochTime.GetIntDate(expires).ToString(), ClaimValueTypes.Integer64
            var claims = new List<Claim>()
            {
                new Claim("Issuer", "SecretStoreApp"),
                new Claim("UserName", userContext.Name),
                new Claim("Identifier", userContext.Id),
                new Claim("exp", EpochTime.GetIntDate(expires).ToString(), ClaimValueTypes.Integer64),
                new Claim("Role", userContext.Role.Name)
            };

            var token = new JwtSecurityToken(new JwtHeader(new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyWhichNoOneCanHack")),
                SecurityAlgorithms.HmacSha256)), new JwtPayload(claims));
            return new Token
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = "REFRESH",
                UserName = userContext.Name,
                Expiry = expires.ToString(CultureInfo.InvariantCulture)
            };
        }
    }
}