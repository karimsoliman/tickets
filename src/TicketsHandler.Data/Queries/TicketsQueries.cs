using Microsoft.EntityFrameworkCore;
using TicketsHandler.Data.Contexts;
using TicketsHandler.Data.DataTransfer;
using TicketsHandler.Data.Entities;
using TicketsHandler.Data.Models;

namespace TicketsHandler.Data.Queries
{
    public class TicketsQueries : ITicketsQueries
    {
        #region Fields

        private readonly TicketsContext _context;

        #endregion

        #region Constructor

        public TicketsQueries(TicketsContext dbContext)
        {
            _context = dbContext;
        }

        #endregion

        #region ITicketsQueries

        public async Task<PayloadResponse<TicketDto>> GetAllTickets(int pageNumber)
        {
            try
            {
                var skip = pageNumber * 5;
                var query = await _context.Tickets.ToListAsync();
                var count = query.Count();
                var tickets = query.Skip(skip).Take(5).Select(t => Map(t)).ToList();
                return new PayloadResponse<TicketDto>
                {
                    Payload = tickets,
                    IsSuccess = true,
                    Count = count
                };
            }
            catch (Exception e)
            {
                return new PayloadResponse<TicketDto>
                {
                    IsSuccess = false
                };
            }
        }

        #endregion

        #region HelperMethods

        private TicketDto Map(Ticket ticket)
        {
            return new TicketDto
            {
                Id = ticket.Id,
                Status = ticket.Status,
                City = ticket.City,
                District = ticket.District,
                Governorate = ticket.Governorate,
                PhoneNumber = ticket.PhoneNumber,
                Color = MapColor(ticket.CreatedDateTime, ticket.Status)
            };
        }

        private string MapColor(DateTime dateTime, TicketStatus status)
        {
            if (status == TicketStatus.Handled)
                return "red";
            if (DateTime.UtcNow.AddMinutes(-15) < dateTime)
                return "yellow";
            if (DateTime.UtcNow.AddMinutes(-30) < dateTime)
                return "green";
            if (DateTime.UtcNow.AddMinutes(-45) < dateTime)
                return "blue";
           
            return "red";
        }

        #endregion
    }
}
