using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral.Membership.Core.Aggregates
{
    public class Token
    {
        public Token()
        {

        }
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Value { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public bool IsActive { get; set; }

        public static Token CreateToken(Guid userId, string value)
        {
            return new Token
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Value = value,
                CreateTime = DateTime.Now,
                EndTime = DateTime.Now.AddMinutes(1),
                IsActive = true
            };
        }

        public bool IsValid()
        {
            return DateTime.Now < EndTime;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
