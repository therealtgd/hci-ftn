using System;

namespace isRail.Models
{
    public class TicketDetails
    {
        public Client Client { get; set; }
        public DateTime DateTimeBought { get; set; }

        public TicketDetails(Client client, DateTime dateTimeBought)
        {
            Client = client;
            DateTimeBought = dateTimeBought;
        }
    }
}