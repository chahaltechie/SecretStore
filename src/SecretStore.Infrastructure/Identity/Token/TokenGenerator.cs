﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Application.Authorization.Interfaces;
using Application.Token.Interfaces;
using Domain.Common;
using Infrastructure.Identity.Token.Interfaces;
using Infrastructure.Identity.Token.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity.Token
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IUserValidator<ApplicationUserContext> _userValidator;
        private readonly List<ITokenClaim<ApplicationUserContext>> _tokenClaims;
        private readonly JwtSecurity _jwtSecurity;
        public TokenGenerator(IUserValidator<ApplicationUserContext> userValidator,
            List<ITokenClaim<ApplicationUserContext>> tokenClaims, JwtSecurity jwtSecurity)
        {
            _userValidator = userValidator;
            _tokenClaims = tokenClaims;
            _jwtSecurity = jwtSecurity;
        }

        public async Task<Domain.Models.Token> GenerateTokenAsync(string username, string password)
        {
            var userContext = await _userValidator.ValidateUser(username, password);
            if (string.IsNullOrEmpty(userContext.Id))
                throw new InvalidCredentialException("Invalid username or password");

            var expires = DateTime.Now.AddMinutes(5);

            var claims = _tokenClaims.Select(tokenClaim => tokenClaim.GenerateClaim(userContext)).ToList();

            var token = new JwtSecurityToken(new JwtHeader(new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecurity.SecurityKey)),
                SecurityAlgorithms.HmacSha256)), new JwtPayload(claims));
            return new Domain.Models.Token
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = "REFRESH",
                UserName = userContext.Name,
                Expiry = expires.ToString(CultureInfo.InvariantCulture)
            };
        }
    }
}