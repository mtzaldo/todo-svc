using FluentResults;

namespace Todo.Broker.Domain.Boundaries;

public record ApiResponse(bool IsSuccess, IEnumerable<string> Errors);

public record ApiResponse<T>(T Content, bool IsSuccess, IEnumerable<string> Errors) 
    : ApiResponse(IsSuccess, Errors);

public static class ApiResponseExtensions
{
    public static ApiResponse ToApiResponse(this Result result)
    {
        if (result.IsSuccess)
            return new ApiResponse(true, []);

        return new ApiResponse(false, result.Errors.Select(e => e.Message));
    }

    public static ApiResponse ToApiResponse<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            return new ApiResponse<T>(result.Value, true, []);

        return new ApiResponse(false, result.Errors.Select(e => e.Message));
    }
}