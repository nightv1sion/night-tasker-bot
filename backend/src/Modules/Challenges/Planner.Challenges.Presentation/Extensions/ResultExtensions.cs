using Challenges.Domain.Core.Primitives;
using Challenges.Domain.Core.Primitives.Result;
using Microsoft.AspNetCore.Http.HttpResults;
using Planner.Challenges.Presentation.Extensions;

namespace Planner.Challenges.Presentation.Extensions;

internal static class ResultExtensions
{
    public static ProblemHttpResult ToProblemDetails(this Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException();
        }

        var errorType = result.Error!.Type;

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
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

    private static string GetTitle(this ErrorType errorType) =>
        errorType switch
        {
            ErrorType.Validation => "Bad Request",
            ErrorType.NotFound => "Not Found",
            _ => "Internal Server Error"
        };

    private static string GetErrorType(this ErrorType errorType) =>
        errorType switch
        {
            ErrorType.Validation => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            ErrorType.NotFound => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
            _ => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
        };
}