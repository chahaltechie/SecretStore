namespace SecretStore.API.Models.Token
{
    public class UserTokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
        public string Expiry { get; set; }
    }
}