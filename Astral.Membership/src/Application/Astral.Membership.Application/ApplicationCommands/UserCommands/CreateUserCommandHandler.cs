using Astral.Membership.Core.Aggregates;
using Astral.Membership.Core.Interfaces;
using Astral.Membership.Infrastructure.Context;
using Astral.Membership.Infrastructure.Repositories;
using MediatR;

namespace Astral.Membership.Application.ApplicationCommands.UserCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            var newUser = User.CreateUser(request.UserName, request.Password);
            userRepository.Add(newUser);
            await _unitOfWork.SaveChangesAsync();
            return await userRepository.FindAsync(x => x.Id == newUser.Id);
        }
    }
}
