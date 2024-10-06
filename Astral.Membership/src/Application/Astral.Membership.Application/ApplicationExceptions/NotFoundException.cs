using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral.Membership.Application.ApplicationExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Not Found")
        {
            
        }

        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}
