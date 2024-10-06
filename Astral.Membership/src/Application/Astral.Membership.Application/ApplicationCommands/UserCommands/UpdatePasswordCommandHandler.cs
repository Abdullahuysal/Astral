using Astral.Membership.Core.Aggregates;
using Astral.Membership.Core.Interfaces;
using Astral.Membership.Core.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Astral.Membership.Application.ApplicationCommands.UserCommands
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UpdatePasswordCommandHandler(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<bool> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var userRepository = _unitOfWork.GetRepository<User>();

            var user = await userRepository.FindAsync(x => x.UserName == request.UserName) ?? throw new Exception("User not found");

            bool isValid = await _userService.ValidatePasswordAsync(request.OldPassword, user.Password);

            if (!isValid)
            {
                throw new Exception("Invalid password");
            }

            var hashedPassword = await _userService.EncryptPassword(request.NewPassword);
            user.UpdatePassword(hashedPassword);

            userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
