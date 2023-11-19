using TicketsHandler.Data.Entities;

namespace TicketsHandler.Data.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public TicketStatus? Status { get; set; }
        public string? Color { get; set; }
    }
}
