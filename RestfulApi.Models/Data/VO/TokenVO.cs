namespace RestfulApi.Models.Data.VO
{
    public class TokenVO
    {
        public TokenVO(bool isAuthenticated, string created, string expiration, string acessToken, string refreshToken)
        {
            IsAuthenticated = isAuthenticated;
            Created = created;
            Expiration = expiration;
            AcessToken = acessToken;
            RefreshToken = refreshToken;
        }

        public bool IsAuthenticated { get; set; }

        public string Created { get; set; }

        public string Expiration { get; set; }

        public string AcessToken { get; set; }

        public  string RefreshToken { get; set; }
    }
}
