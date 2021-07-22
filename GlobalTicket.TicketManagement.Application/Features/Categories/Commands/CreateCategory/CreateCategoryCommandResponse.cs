using GlobalTicket.TicketManagement.Application.Responses;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CategoryResponse Category { get; set; }
    }
}