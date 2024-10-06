namespace Astral.Membership.Core.Services
{
    public interface IUserService
    {
        Task<string> EncryptPassword(string password);
        Task<bool> ValidatePasswordAsync(string password, string storedHashedPassword);
    }
}
