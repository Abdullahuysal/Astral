using Astral.Membership.Core.Aggregates;
using Astral.Membership.Core.Interfaces;
using Astral.Membership.Core.Services;
using Astral.Membership.Core.Shared;
using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.TokenCommands
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, Result<string>>
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTokenCommandHandler(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        async Task<Result<string>> IRequestHandler<CreateTokenCommand, Result<string>>.Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            var tokenRepository = _unitOfWork.GetRepository<Token>();
            var user = await userRepository.FindAsync(x => x.UserName == request.UserName);

            if (user == null)
            {
                return Result.Failure<string>(ApplicationErrors.NotFound("Application Failure","User Can Not Be Null"));

            }

            if (!await _userService.ValidatePasswordAsync(request.Password, user.Password))
            {
                return Result.Failure<string>(ApplicationErrors.Invalid("Application Failure", "Password is not valid"));
            }

            var generatedToken = "";
            var newToken = Token.CreateToken(user.Id, generatedToken);
            tokenRepository.Add(newToken);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success(generatedToken);
        }
    }
}