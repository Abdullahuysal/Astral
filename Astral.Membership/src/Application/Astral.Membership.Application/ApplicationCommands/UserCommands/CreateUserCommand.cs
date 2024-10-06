using Astral.Membership.Core.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral.Membership.Application.ApplicationCommands.UserCommands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}
