
namespace SanriJP.API.Authentication
{
    public class ResponseStatus
    {
        public const string Error = "Error";
        public const string Succes = "Success";
    } 
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
