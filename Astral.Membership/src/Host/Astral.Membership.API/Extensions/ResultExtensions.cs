using Astral.Membership.Core.Shared;

namespace Astral.Membership.API.Extensions
{
    public static class ResultExtensions
    {
        public static Microsoft.AspNetCore.Http.IResult ToProblemDetails(this Result result)
        {
            if (result.IsSuccess)
            {
                throw new InvalidOperationException();
            }

            return Results.Problem(
                statusCode: GetStatusCode(result.Error.Type),
                title: GetTitle(result.Error.Type),
                extensions: new Dictionary<string, object?>
                {
                    {"errors", new  []{result.Error }
                }
                });


            static int GetStatusCode(ErrorType errorType) =>
                errorType switch
                {
                    ErrorType.NotFound => StatusCodes.Status404NotFound,
                    ErrorType.Invalid => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };

            static string GetTitle(ErrorType errorType) =>
                errorType switch
                {
                    ErrorType.NotFound => "Not Found",
                    ErrorType.Invalid => "Invalid",
                    _ => "Internal Server Error"
                };

        }
    }
}
