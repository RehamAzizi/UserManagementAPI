using TaskOne.Domain.ResultPattern;

namespace TaskOne.Api.Extensions
{
    public static class ResultHttpExtensions
    {
        public static IResult ToIResult<T>(this ResultT<T> result)
        {
            if (result.IsSuccess)
                return Results.Ok(result.Value);

            return result.Error!.ErrorType switch
            {
                ErrorType.Validation => Results.BadRequest(result.Error),
                ErrorType.NotFound => Results.NotFound(result.Error),
                ErrorType.Conflict => Results.Conflict(result.Error),
                ErrorType.AccessUnAuthorized => Results.Unauthorized(),
                ErrorType.AccessForbidden => Results.Forbid(),
                _ => Results.Problem(result.Error.Description)
            };
        }

        public static IResult ToIResult(this Result result)
        {
            if (result.IsSuccess)
                return Results.Ok();

            return result.Error!.ErrorType switch
            {
                ErrorType.Validation => Results.BadRequest(result.Error),
                ErrorType.NotFound => Results.NotFound(result.Error),
                _ => Results.Problem(result.Error.Description)
            };
        }
    }
}