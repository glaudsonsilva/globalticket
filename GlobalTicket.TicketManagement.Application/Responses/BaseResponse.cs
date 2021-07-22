using System.Collections.Generic;

namespace GlobalTicket.TicketManagement.Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; } = new List<string>();

        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }

    }
}
