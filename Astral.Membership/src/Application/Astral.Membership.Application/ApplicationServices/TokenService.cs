using Astral.Membership.Core.Aggregates;
using Astral.Membership.Core.Interfaces;
using Astral.Membership.Core.Services;

namespace Astral.Membership.Application.ApplicationServices
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TokenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GenerateToken(User user)
        {
            var tokenRepository = _unitOfWork.GetRepository<Token>();
            var userAllOldTokens = await tokenRepository.FindAllAsync(x => x.UserId == user.Id && x.IsActive == true && x.EndTime < DateTime.Now);
            foreach (var oldtoken in userAllOldTokens)
            {
                oldtoken.IsActive = false;
                tokenRepository.Update(oldtoken);
            }
            var generatedToken = Guid.NewGuid().ToString();
            Token token = Token.CreateToken(user.Id, generatedToken);
            tokenRepository.Add(token);
            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(generatedToken);
        }

        public async Task<string> GetActiveToken(User user)
        {
            var tokenRepository = _unitOfWork.GetRepository<Token>();

            Token activeToken = await tokenRepository.FindAsync(x => x.UserId == user.Id && x.IsActive && x.EndTime > DateTime.Now);
            if (activeToken == null)
            {
                return await GenerateToken(user);
            }
            return activeToken.Value;
        }

        public async Task<bool> IsTokenValid(User user, string token)
        {
            var tokenRepository = _unitOfWork.GetRepository<Token>();
            var activeToken = await tokenRepository.FindAsync(x => x.UserId == user.Id && x.IsActive && x.Value == token);
            if (activeToken == null)
            {
                return false;
            }
            return true;
        }

        public Task<bool> ValidateToken(User user, string token)
        {
            var tokenRepository = _unitOfWork.GetRepository<Token>();
            var activeToken = tokenRepository.FindAsync(x => x.UserId == user.Id && x.IsActive && x.Value == token);
            if (activeToken == null)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task DeactivateToken(Token token)
        {
            var tokenRepository = _unitOfWork.GetRepository<Token>();
            token.IsActive = false;
            tokenRepository.Update(token);
            _unitOfWork.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
