namespace Astral.Membership.Core.Services
{
    public interface IUserService
    {
        Task<string> LoginAsync(string username, string password);
        Task<string> EncryptPassword(string password);
        Task<bool> ValidatePasswordAsync(string password, string storedHashedPassword);
        Task<bool> LogoutAsync(string token, string token1);
    }
}
