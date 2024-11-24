namespace UDV_Benefits.Domain.Errors
{
    public static class ResultExtensions
    {
        public static IActionResult Match<IActionResult, TValue>(
            this ValueResult<TValue> result,
            Func<TValue, IActionResult> onSuccess,
            Func<Error, IActionResult> onFailure)
        {
            return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error!);
        }

        public static IActionResult Match<IActionResult>(
            this Result result,
            Func<IActionResult> onSuccess,
            Func<Error, IActionResult> onFailure)
        {
            return result.IsSuccess ? onSuccess() : onFailure(result.Error!);
        }
    }
}
