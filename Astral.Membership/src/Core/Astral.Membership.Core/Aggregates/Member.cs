using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral.Membership.Core.Aggregates
{
    public class Member
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Title { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
