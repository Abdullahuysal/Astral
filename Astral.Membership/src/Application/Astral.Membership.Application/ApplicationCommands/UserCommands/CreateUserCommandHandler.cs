using Astral.Membership.Core.Aggregates;
using Astral.Membership.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral.Membership.Application.ApplicationCommands.UserCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly DataContext _context;
        public CreateUserCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser =  User.CreateUser(request.UserName, request.Password);

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }
    }
}
