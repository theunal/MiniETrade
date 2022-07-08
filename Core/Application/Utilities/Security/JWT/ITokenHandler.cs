namespace Application.Utilities.Security.JWT
{
    public interface ITokenHandler
    {
        AccessToken CreateToken();
    }
}
