using Astral.Membership.Core.Aggregates;
using Astral.Membership.Core.Helper;
using Astral.Membership.Core.Interfaces;
using Astral.Membership.Core.Services;

namespace Astral.Membership.Application.ApplicationServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public UserService(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            var user = await userRepository.FindAsync(x => x.UserName == username);

            if (user == null)
            {
                return await Task.FromResult(string.Empty);
            }

            if (!await ValidatePasswordAsync(password, user.Password))
            {
                return await Task.FromResult(string.Empty);
            }

            var token = await _tokenService.GetActiveToken(user);
            return await Task.FromResult(token);
        }

        public async Task<bool> LogoutAsync(string userName, string token)
        {
            var tokenRepository = _unitOfWork.GetRepository<Token>();
            var userRepository = _unitOfWork.GetRepository<User>();
            var user = await userRepository.FindAsync(x => x.UserName == userName);
            if (user == null)
                return false;

            var activeToken = await tokenRepository.FindAsync(x => x.Value == token && x.UserId == user.Id && x.IsActive == true && x.EndTime < DateTime.Now);
            if (activeToken == null)
                return false;
            activeToken.IsActive = false;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public Task<string> EncryptPassword(string password)
        {
            return Task.FromResult(HashHelper.ComputeSha256Hash(password));
        }

        public Task<bool> ValidatePasswordAsync(string password, string storedHashedPassword)
        {
            string hashedPassword = HashHelper.ComputeSha256Hash(password);

            bool isValid = hashedPassword == storedHashedPassword;

            return Task.FromResult(isValid);
        }
    }
}
