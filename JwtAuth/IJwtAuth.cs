namespace ArticlesAPI.JwtAuth
{
    public interface IJwtAuth
    {
        string Authenticate(string username, string password);
    }
}