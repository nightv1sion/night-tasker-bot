using Planner.Common.Domain.Core.Primitives;
using Planner.Common.Domain.Core.Primitives.Result;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;

namespace Planner.Challenges.Presentation.Extensions;

internal static class ResultExtensions
{
    public static ProblemHttpResult ToProblemDetails(this Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException();
        }

        ErrorType errorType = result.Error!.Type;

        return TypedResults.Problem(
            statusCode: errorType.GetStatusCode(),
            title: errorType.GetTitle(),
            type: errorType.GetErrorType(),
            extensions: new Dictionary<string, object?>
            {
                {
                    "errors",
                    new[] { result.Error }
                }
            });
    }

    private static int GetStatusCode(this ErrorType errorType) =>
        errorType switch
        {
            ErrorType.Problem => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

    private static string GetTitle(this ErrorType errorType) =>
        errorType switch
        {
            ErrorType.Problem => "Bad Request",
            ErrorType.NotFound => "Not Found",
            _ => "Internal Server Error"
        };

    private static string GetErrorType(this ErrorType errorType) =>
        errorType switch
        {
            ErrorType.Problem => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            ErrorType.NotFound => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
            _ => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
        };
}
