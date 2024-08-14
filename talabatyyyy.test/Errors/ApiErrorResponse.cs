namespace talabatyyyy.test.Errors
{
    public class ApiErrorResponse
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        public ApiErrorResponse(int statusCode , string? errorMessage=null)
        {
            StatusCode = statusCode;
            ErrorMessage = GetErrorMessage(statusCode);
        }

        private string? GetErrorMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad Request , You Have Made",
                401 => "Authorized  you are not",
                404 => "Resource Not Found",
                500 => "There is Server Error",
                _ => null
            };
        }
    }
}
