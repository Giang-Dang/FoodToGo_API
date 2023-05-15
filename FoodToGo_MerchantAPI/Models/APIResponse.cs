using System.Net;

namespace FoodToGo_API.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
        public APIResponse() 
        { 
            ErrorMessages = new List<string>();
            IsSuccess = true;
        }
    }
}
