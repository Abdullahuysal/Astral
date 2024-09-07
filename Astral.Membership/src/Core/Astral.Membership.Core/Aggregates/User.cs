using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral.Membership.Core.Aggregates
{
    public class User
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime UpdateTime { get; private set; }
        public bool IsApproved { get; private set; }
        public static User CreateUser(string userName, string Password)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                UserName = userName,
                Password = Password,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                IsApproved = false
            };
        }
    }
}
