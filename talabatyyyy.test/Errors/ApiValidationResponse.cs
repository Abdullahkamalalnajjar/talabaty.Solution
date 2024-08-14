namespace talabatyyyy.test.Errors
{
    public class ApiValidationResponse
    {
        public List<string> Errors { get; set; }

        public ApiValidationResponse() { 
        Errors = new List<string>();
        }
    }
}
