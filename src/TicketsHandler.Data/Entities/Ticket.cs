namespace TicketsHandler.Data.Entities
{
    public class Ticket
    {
        #region Constructor

        public Ticket(string phoneNumber, string governorate, string city, string district)
        {
            CreatedDateTime = DateTime.UtcNow;
            PhoneNumber = phoneNumber;
            Governorate = governorate;
            City = city;
            District = district;
            Status = TicketStatus.NotHandled;
        }

        #endregion


        #region Columns

        public int Id { get; set; }
        public DateTime CreatedDateTime { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Governorate { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public TicketStatus Status { get; private set; }

        #endregion

        #region Public methods

        public void Handle()
        {
            Status = TicketStatus.Handled;
        }

        #endregion
    }
}
