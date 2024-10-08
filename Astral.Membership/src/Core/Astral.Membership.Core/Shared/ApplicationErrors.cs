using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral.Membership.Core.Shared
{
    public static class ApplicationErrors
    {
        public static Error NotFound(string code, string message) => Error.NotFound(code, message);
        public static Error Invalid(string code, string message) => Error.Failure(code, message);
    }
}
