using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral.Membership.Core.Shared
{
    public record Error : IEquatable<Error>
    {
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
        public static readonly Error NullValue = new("Error.NullValue",string.Empty, ErrorType.Failure);

        public string Code { get; set; }
        public string Description { get; set; }
        public ErrorType Type { get; set; }

        private Error(string code, string description, ErrorType errorType)
        {
            Code = code;
            Description = description;
            Type = errorType;
        }

        public static Error Failure(string code, string description) => new Error(code, description, ErrorType.Failure);
        public static Error NotFound (string code, string description) => new Error(code, description, ErrorType.NotFound);
        public static Error Invalid (string code, string description) => new Error(code, description, ErrorType.Invalid);
        public static Error Unauthorized (string code, string description) => new Error(code, description, ErrorType.Unauthorized);
        public static Error Forbidden (string code, string description) => new Error(code, description, ErrorType.Forbidden);
        public static Error Conflict (string code, string description) => new Error(code, description, ErrorType.Conflict);
        public static Error Internal (string code, string description) => new Error(code, description, ErrorType.Internal);
        public static Error External (string code, string description) => new Error(code, description, ErrorType.External);


    }
    public enum ErrorType
    {
        Failure,
        NotFound,
        Invalid,
        Unauthorized,
        Forbidden,
        Conflict,
        Internal,
        External
    }
}
