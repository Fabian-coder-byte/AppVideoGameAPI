namespace APIJustEatProject.Configuration
{
    public class JwtBearerTokenSettings
    {
        public string Authority { get; set; }
        public string SecretKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpiryTimeInSeconds { get; set; }
    }
}
