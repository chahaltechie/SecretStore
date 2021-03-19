namespace Application.Token.Models
{
    public class UserTokenResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
        public string Expiry { get; set; }
    }
}