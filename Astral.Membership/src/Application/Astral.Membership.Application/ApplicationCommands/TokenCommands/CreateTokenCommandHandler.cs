using Astral.Membership.Core.Aggregates;
using Astral.Membership.Core.Common;
using Astral.Membership.Core.Interfaces;
using Astral.Membership.Core.Services;
using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.TokenCommands
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, Response<string>>
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTokenCommandHandler(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        async Task<Response<string>> IRequestHandler<CreateTokenCommand, Response<string>>.Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            var tokenRepository = _unitOfWork.GetRepository<Token>();
            var user = await userRepository.FindAsync(x => x.UserName == request.UserName);

            if (user == null)
            {
                return new Response<string>(false, "User not found", string.Empty);
            }

            if (!await _userService.ValidatePasswordAsync(request.Password, user.Password))
            {
                return new Response<string>(false, "Invalid password", string.Empty);
            }

            var generatedToken = "";
            var newToken = Token.CreateToken(user.Id, generatedToken);
            tokenRepository.Add(newToken);
            await _unitOfWork.SaveChangesAsync();

            return new Response<string>(true, "Token generated successfully", newToken.Value);
        }
    }
}