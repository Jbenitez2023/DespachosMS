namespace AuthenticationService.Service
{
    public interface ITokenGenerator
    {
        public Task<string> GenerateToken(string username);
    }
}
