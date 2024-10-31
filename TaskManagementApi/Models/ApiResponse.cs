using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace TaskManagementApi.Models
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode{ get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }= new List<string>();
        public object? result { get; set; }

        public static void FailedResponse(ApiResponse response, Exception ex)
        {
            response.IsSuccess = false;
            response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        public static void SuccessResponse(ApiResponse response, HttpStatusCode statusCode,
            bool isSuccess,string? ErrorMessages, object? result)
        {
            response.StatusCode = statusCode;
            response.IsSuccess = isSuccess;
            response.result = result;
            if (!ErrorMessages.IsNullOrEmpty())
            {
                response.ErrorMessages.Add(ErrorMessages);
            }
        }
    }
}
