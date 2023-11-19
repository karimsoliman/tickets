using MediatR;
using TicketsHandler.Data.Common;

namespace TicketsHandler.Data.Commands
{
    public class AddTicketCommand : IRequest<CommandResult<AddTicketCommand>>
    {
        #region Constructor

        public AddTicketCommand(string phoneNumber, string governorate, string city, string district)
        {
            PhoneNumber = phoneNumber;
            Governorate = governorate;
            City = city;
            District = district;
        }

        #endregion

        #region Properties

        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        #endregion
    }
}
