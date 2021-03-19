using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using Application.Authorization.Interfaces;
using Application.Token.Interfaces;
using Domain.Models;

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
            return new Token
            {
                AccessToken = "SUCCESS",
                RefreshToken = "REFRESH",
                UserName = userContext.Name,
                Expiry = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()
            };
        }
    }
}