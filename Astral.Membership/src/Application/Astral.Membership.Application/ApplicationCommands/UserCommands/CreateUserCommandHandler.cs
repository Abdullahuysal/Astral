using Astral.Membership.Core.Aggregates;
using Astral.Membership.Core.Interfaces;
using Astral.Membership.Core.Services;
using Astral.Membership.Core.Shared;
using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.UserCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }
        public async Task<Result<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            if (string.IsNullOrEmpty(request.Password))
            {
               return Result.Failure<bool>(ApplicationErrors.NotFound("Password Is Null","Password Can Not Be Null Or Empty"));
            }
            var hashedPassword = await _userService.EncryptPassword(request.Password);
            var newUser = User.CreateUser(request.UserName, hashedPassword);
            userRepository.Add(newUser);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
