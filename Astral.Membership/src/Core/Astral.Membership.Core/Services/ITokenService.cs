using Astral.Membership.Core.Aggregates;

namespace Astral.Membership.Core.Services
{
    public interface ITokenService
    {
        Task<string> GetActiveToken(User user);
        Task<bool> IsTokenValid(User user, string token);
        Task<string> GenerateToken(User user);
        Task<bool> ValidateToken(User user ,string token);
        Task DeactivateToken(Token token);
    }
}
