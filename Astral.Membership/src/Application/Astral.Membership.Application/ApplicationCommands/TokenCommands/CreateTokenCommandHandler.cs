using Astral.Membership.Core.Aggregates;
using Astral.Membership.Core.Interfaces;
using Astral.Membership.Core.Services;
using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.TokenCommands
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, string>
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTokenCommandHandler(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        async Task<string> IRequestHandler<CreateTokenCommand, string>.Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            var tokenRepository = _unitOfWork.GetRepository<Token>();
            var user = await userRepository.FindAsync(x => x.UserName == request.UserName) ?? throw new Exception("User not found");

            if (!await _userService.ValidatePasswordAsync(request.Password, user.Password))
            {
                throw new Exception("Invalid password");
            }

            var generatedToken = "";
            var newToken = Token.CreateToken(user.Id, generatedToken);
            tokenRepository.Add(newToken);
            await _unitOfWork.SaveChangesAsync();
            return newToken.Value;
        }
    }
}
