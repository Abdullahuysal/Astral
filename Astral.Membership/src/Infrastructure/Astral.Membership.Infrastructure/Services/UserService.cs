using Astral.Membership.Core.Helper;
using Astral.Membership.Core.Interfaces;
using Astral.Membership.Core.Services;

namespace Astral.Membership.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
