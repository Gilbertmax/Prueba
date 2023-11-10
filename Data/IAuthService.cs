namespace YourSolucion.Bussiness
{
    public interface IAuthService
    {
        Task<string> Authenticate(string username, string password);
    }
}