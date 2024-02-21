namespace GeradorCenarioMVC.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterUser(string email, string password, string firstname, string lastname);
        Task<bool> RegisterUserFull(string email, string password, string firstname, string lastname, bool? recebeEmail, byte[]? picture);
        Task<bool> DeleteUser(string id);
        Task<bool> UpdateUser(string email, string password, string firstname, string lastname, bool? recebeEmail, byte[]? picture);
        Task Logout();
    }
}
