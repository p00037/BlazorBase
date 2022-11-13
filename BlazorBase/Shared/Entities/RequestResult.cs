using BlazorBase.Shared.Enums;

namespace BlazorBase.Shared.Entities
{
    public class RequestResult
    {
        public RequestResult()
        {
        }

        private RequestResult(bool isSuccessful, ErrorType errorType = ErrorType.None, string errorMessage = "")
        {
            IsSuccessful = isSuccessful;
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public ErrorType ErrorType { get; set; }

        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }

        public static RequestResult CreateSuccess()
        {
            return new RequestResult(true);
        }

        public static RequestResult CreateFailure(ErrorType errorType, string errorMessage)
        {
            return new RequestResult(false, errorType, errorMessage);
        }
    }
}
